using System;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject pict;
    public void Trigger(){
        if(pict.activeInHierarchy == true){
            pict.SetActive(false);
    }
    else{
        Console.WriteLine("PopUp is already inactive.");
    }
}
}
