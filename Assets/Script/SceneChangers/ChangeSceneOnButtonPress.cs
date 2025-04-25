using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneOnButtonPress : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
