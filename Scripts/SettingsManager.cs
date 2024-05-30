using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Button saveButton;
    public Button backButton;

    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            volumeSlider.value = 1.0f; // Значение по умолчанию, если настройка не была сохранена
        }
    }
    public void SaveSettings()
    {
        if (volumeSlider != null)
        {
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
            PlayerPrefs.Save(); // Сохраняем изменения
        }
        else
        {
            Debug.LogError("Volume slider is not assigned!"); // Вывод ошибки, если слайдер не назначен
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
