using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameSettings : MonoBehaviour
{
    public Slider backgroundVolumeSlider;
    public Slider soundEffectVolumeSlider;

    public Text backgroundVolumeText;
    public Text soundEffectVolumeText;
    
    private const string BackgroundVolumeKey = "BackgroundVolume";
    private const string SoundEffectVolumeKey = "SoundEffectVolume";


    void Start()
    {
        // ������ �ҷ��ͼ� �����̴��� �ݿ��մϴ�.
        LoadSettings();

        // �����̴��� �̺�Ʈ�� �����մϴ�.
        backgroundVolumeSlider.onValueChanged.AddListener(delegate { SaveBackgroundVolume(); });
        soundEffectVolumeSlider.onValueChanged.AddListener(delegate { SaveSoundEffectVolume(); });


        backgroundVolumeText.text = ((int)(backgroundVolumeSlider.value * 100)).ToString() + "%";
        soundEffectVolumeText.text = ((int)(soundEffectVolumeSlider.value * 100)).ToString() + "%";
    }

    
    public void SaveBackgroundVolume()
    {
        PlayerPrefs.SetFloat(BackgroundVolumeKey, backgroundVolumeSlider.value);
        backgroundVolumeText.text = ((int)(backgroundVolumeSlider.value*100)).ToString()+"%";
        ApplyBackgroundVolume();
    }

    public void SaveSoundEffectVolume()
    {
        PlayerPrefs.SetFloat(SoundEffectVolumeKey, soundEffectVolumeSlider.value);
        soundEffectVolumeText.text = ((int)(soundEffectVolumeSlider.value*100)).ToString()+"%";
        
        ApplySoundEffectVolume();
    }


    public void LoadSettings()
    {
        backgroundVolumeSlider.value = PlayerPrefs.GetFloat(BackgroundVolumeKey, 1f);
        soundEffectVolumeSlider.value = PlayerPrefs.GetFloat(SoundEffectVolumeKey, 1f);

        ApplySettings();
    }

    private void ApplySettings()
    {
        ApplyBackgroundVolume();
        ApplySoundEffectVolume();
    }

    private void ApplyBackgroundVolume()
    {
        AudioListener.volume = backgroundVolumeSlider.value;
    }

    private void ApplySoundEffectVolume()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            if (source.CompareTag("SoundEffect"))
            {
                source.volume = soundEffectVolumeSlider.value;
            }
        }
    }
}
