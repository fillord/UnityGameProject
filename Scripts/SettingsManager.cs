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
            volumeSlider.value = 1.0f; // �������� �� ���������, ���� ��������� �� ���� ���������
        }
    }
    public void SaveSettings()
    {
        if (volumeSlider != null)
        {
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
            PlayerPrefs.Save(); // ��������� ���������
        }
        else
        {
            Debug.LogError("Volume slider is not assigned!"); // ����� ������, ���� ������� �� ��������
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
