using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;   

public class PopUpLogics : MonoBehaviour
{
    public string popUp;

    void Start()
    {
        PopUp pop = GameObject.FindGameObjectWithTag("PopUpManager").GetComponent<PopUp>();
        pop.PopUps(popUp);
    }
}
