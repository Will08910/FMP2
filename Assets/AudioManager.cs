using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] clips;
    private AudioSource audioSource;
    private AudioSource audioSource2;

    public Slider volumeSlider;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        InitializeVolumeSlider();
        PlayAudioForScene(SceneManager.GetActiveScene().name);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void InitializeVolumeSlider()
    {
        if (volumeSlider == null)
        {
            volumeSlider = GameObject.FindGameObjectWithTag("VolumeSlider")?.GetComponent<Slider>();
        }

        if (volumeSlider != null)
        {
            float savedMusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.5f);
            volumeSlider.value = savedMusicVolume;
            audioSource.volume = savedMusicVolume;
            audioSource2.volume = savedMusicVolume;

            volumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Main Menu" && scene.name != "Act1" && scene.name != "Act3" && scene.name != "Act2")
        {
            StopClip();
        }

        PlayAudioForScene(scene.name);
        InitializeVolumeSlider();
    }

    void PlayAudioForScene(string sceneName)
    {
        if (sceneName == "Main Menu" || sceneName == "Act1" || sceneName == "Act3")
        {
            if (!audioSource.isPlaying)
            {
                PlayClip(0);
            }

            if (audioSource2.isPlaying)
            {
                audioSource2.Stop();
            }
        }
        else if (sceneName == "Act2")
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();  
            }

            if (!audioSource2.isPlaying)
            {
                PlayClip(1, audioSource2);  
            }
        }
    }

    public void PlayClip(int clipNumber, AudioSource source = null)
    {
        if (clipNumber < 0 || clipNumber >= clips.Length)
        {
            return;
        }

        if (source == null) source = audioSource;  

        if (!source.isPlaying)
        {
            source.PlayOneShot(clips[clipNumber], 1f);
        }
    }

    public void StopClip()
    {
        audioSource.Stop();
        audioSource2.Stop();
    }

    public void OnMusicVolumeChanged(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
        audioSource2.volume = Mathf.Clamp(volume, 0f, 1f);

        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }
}

