using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using NaughtyAttributes;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    [BoxGroup("Audio")] [SerializeField] AudioMixer mixer;
    [BoxGroup("Audio")] [SerializeField] Slider volumeSlider;
    [BoxGroup("Audio")] [SerializeField] Slider sfxVolumeSlider;
    [BoxGroup("Audio")] [SerializeField] Slider musicVolumeSlider;
    [BoxGroup("Graphics")] [SerializeField] TMP_Dropdown resolutionDropdown,qualityDropdown,textureDropdown,aaDropdown;
    [BoxGroup("Tabs")]
    [SerializeField]Canvas currentTab;
    [BoxGroup("Warnigs")]
    [SerializeField]GameObject musicWarnig,musicWarnig2,SfxWarnig,SfxWarnig2,VolumeWarnig,VolumeWarnig2;
    [BoxGroup("Difficulty")][SerializeField] EnemyDificultyValuses difficulty;
    [SerializeField][BoxGroup("Difficulty")] TMP_Dropdown difficultyDropdown;
    float currentVolume;
    float currentSFXVolume;
    float currentMusicVolume;
    Resolution[] resolutions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + 
                            resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width 
                && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        
    }
    

    public void OpenTab(Canvas tab)
    {
        currentTab.gameObject.SetActive(false);
        currentTab = tab;
        currentTab.gameObject.SetActive(true);
    }
    public void SetVolume(float volume)
    {
        mixer.SetFloat("Master", volume);
        currentVolume = volume;
        if (currentVolume > 0)
        {
            VolumeWarnig.SetActive(true);
            VolumeWarnig2.SetActive(true);
            return;
        }

        if (currentVolume < 0)
        {
            VolumeWarnig.SetActive(false);
            VolumeWarnig2.SetActive(false);
        }
    }

    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("sfx", volume);
        currentSFXVolume = volume;
        if (currentSFXVolume > 0)
        {
            SfxWarnig.SetActive(true);
            SfxWarnig2.SetActive(true);
            return;
        }

        if (currentSFXVolume < 0)
        {
            SfxWarnig.SetActive(false);
            SfxWarnig2.SetActive(false);
        }
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("Music", volume);
        currentMusicVolume = volume;
        if (currentMusicVolume > 0)
        {
            musicWarnig.SetActive(true);
            musicWarnig2.SetActive(true);
            return;
        }

        if (currentMusicVolume < 0)
        {
            musicWarnig.SetActive(false);
            musicWarnig2.SetActive(false);
        }
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, 
            resolution.height, Screen.fullScreen);
    }
    /*
    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.globalTextureMipmapLimit = textureIndex;
        qualityDropdown.value = 6;
    }
    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex != 6) // if the user is not using 
            //any of the presets
            QualitySettings.SetQualityLevel(qualityIndex);
        switch (qualityIndex)
        {
            case 0: // quality level - very low
                textureDropdown.value = 3;
                aaDropdown.value = 0;
                break;
            case 1: // quality level - low
                textureDropdown.value = 2;
                aaDropdown.value = 0;
                break;
            case 2: // quality level - medium
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            case 3: // quality level - high
                textureDropdown.value = 0;
                aaDropdown.value = 0;
                break;
            case 4: // quality level - very high
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;
            case 5: // quality level - ultra
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;
        }
        
        qualityDropdown.value = qualityIndex;
    }
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
    } */
    public void SetDifficulty(int difficultyIndex)
    {
        difficulty.ChangeDificultyValues(difficultyIndex);
        difficulty.currentDificulty = difficultyIndex;
    }
    public void ExitGame()
    {
        SaveSettings();
        Application.Quit();
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference", textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference", aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
        PlayerPrefs.SetInt("Difficulty", difficulty.currentDificulty);
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        qualityDropdown.value = PlayerPrefs.HasKey("QualitySettingPreference") ? PlayerPrefs.GetInt("QualitySettingPreference") : 3;
        resolutionDropdown.value = PlayerPrefs.HasKey("ResolutionPreference") ? PlayerPrefs.GetInt("ResolutionPreference") : currentResolutionIndex;
        textureDropdown.value = PlayerPrefs.HasKey("TextureQualityPreference") ? PlayerPrefs.GetInt("TextureQualityPreference") : 0;
        aaDropdown.value = PlayerPrefs.HasKey("AntiAliasingPreference") ? PlayerPrefs.GetInt("AntiAliasingPreference") : 1;
        Screen.fullScreen = !PlayerPrefs.HasKey("FullscreenPreference") || Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        difficulty.currentDificulty = PlayerPrefs.GetInt("Difficulty");
        difficultyDropdown.value = difficulty.currentDificulty;
    }

    void OnDisable()
    {
        SaveSettings();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
