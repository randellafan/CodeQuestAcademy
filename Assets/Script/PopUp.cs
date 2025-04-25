using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;

public class PopUp : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUps(String text)
    {
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");
        popUpText.text = text;
    }
}
