using UnityEngine;
using UnityEngine.UI;

public class SoundMgr : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle muteToggle;

    private float lastVolumeValue = 1f;
    private bool isMuted = false;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 1);
            Load();
        }
        else
        {
            Load();
        }

        // Set up mute toggle
        isMuted = PlayerPrefs.GetInt("IsMuted", 0) == 1;
        muteToggle.isOn = isMuted;
        if (isMuted)
        {
            Mute(true);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    public void Load()
    {
        float savedValue = PlayerPrefs.GetFloat("Music");
        Debug.Log("Loaded volume value: " + savedValue);
        volumeSlider.value = savedValue;
    }

    public void Save()
    {
        float currentValue = volumeSlider.value;
        Debug.Log("Saving volume value: " + currentValue);
        PlayerPrefs.SetFloat("Music", currentValue);
    }

    public void Mute(bool muted)
    {
        if (muted)
        {
            lastVolumeValue = volumeSlider.value;
            AudioListener.volume = 0;
            volumeSlider.interactable = false;
            isMuted = true;
        }
        else
        {
            AudioListener.volume = lastVolumeValue;
            volumeSlider.interactable = true;
            isMuted = false;
        }
        PlayerPrefs.SetInt("IsMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void Fullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}