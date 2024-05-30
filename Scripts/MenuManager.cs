using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelect"); // Загрузка сцены с выбором уровня
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Quit()
    {
        // Ойыннан шығу
        Application.Quit();
        // Егер ойын редакторда жұмыс істеп тұрса, ойыннан шығуды имитациялау
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
