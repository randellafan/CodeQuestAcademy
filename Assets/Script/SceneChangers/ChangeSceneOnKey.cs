using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnKey : MonoBehaviour
{
    public string sceneName; 

    void Update()
    {
        // Check if the B key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }
}