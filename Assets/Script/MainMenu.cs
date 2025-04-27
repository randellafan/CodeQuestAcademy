using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuCutscene");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
