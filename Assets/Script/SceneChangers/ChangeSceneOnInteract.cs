using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneOnInteract : MonoBehaviour,Interactable
{
    public string sceneName = "Chapter1.2"; 

  public void Interact(){
    Debug.Log("Interact");
        ChangeScene();
}
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}