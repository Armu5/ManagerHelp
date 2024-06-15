using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        // Initialize volume slider
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Initialize volume text
        UpdateVolumeText(volumeSlider.value);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        UpdateVolumeText(volume);
    }

    void UpdateVolumeText(float volume)
    {
        volumeText.text = (volume * 100).ToString("0");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
