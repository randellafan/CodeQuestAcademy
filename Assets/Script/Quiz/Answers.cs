using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Rendering;
using Unity.VisualScripting;

public class Answers : MonoBehaviour 
{
    public bool isCorrect = false;
    public bool hint = false;
    public bool skip = false; 
    public Manager quizManager; 
    private AudioManager audioManager;
    private int gems;
    [SerializeField]    
    private Text gemText;
    [SerializeField]    
    private int Price;
    [SerializeField]
    private Text PriceText;

   public int Gems {
    get {
        return gems; 
    }
    set {
        Debug.Log($"Gems being set. Old value: {gems}, New value: {value}"); // Log old and new values
        this.gems = value; 
        PlayerPrefs.SetInt("Gems", this.gems); // Save Gems to PlayerPrefs
        this.gemText.text = value.ToString() + " <color= #7FFFD4>Gems</color> "; // Update the UI text
    }
}

    void Start() {
    if (!PlayerPrefs.HasKey("Gems") || PlayerPrefs.GetInt("Gems") <= 0) {
        PlayerPrefs.SetInt("Gems", 50); // Set default value to 50 if no value exists or Gems is 0
        Debug.Log("No Gems found or Gems was 0. Setting default to 50.");
    }

    Gems = PlayerPrefs.GetInt("Gems");
    Debug.Log($"Gems loaded: {Gems}");

    PriceText.text = Price + " ( <color= #7FFFD4>Gems</color> ) ";
}

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Answer() 
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correct();
            audioManager.PlaySFX(audioManager.Correct);
        }
        else if (hint)
        {
            ProvideHint();
        }
        else if (skip)
        {
            SkipQuestion(); // Call the SkipQuestion method
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.wrong();
            audioManager.PlaySFX(audioManager.Incorrect);
        }   
    }

    private void ProvideHint() {
    if (quizManager.wrongAnswerIndices.Count > 2 && Gems >= Price) {
        Debug.Log($"Gems before deduction in ProvideHint: {Gems}");
        Gems -= Price; // Deduct gems
        Debug.Log($"Gems after deduction in ProvideHint: {Gems}");

        HashSet<int> indicesToRemove = new HashSet<int>();
        while (indicesToRemove.Count < 2) {
            int randomIndex = Random.Range(0, quizManager.wrongAnswerIndices.Count);
            indicesToRemove.Add(quizManager.wrongAnswerIndices[randomIndex]);
        }

        foreach (int index in indicesToRemove) {
            quizManager.options[index].SetActive(false); // Disable the option
        }
    } else if (Gems < Price) {
        Debug.Log("Not enough gems to use the hint.");
    } else {
        Debug.Log("Not enough wrong answers to remove.");
    }
}

   private void SkipQuestion() {
    if (Gems >= Price) {
        Debug.Log($"Gems before deduction in SkipQuestion: {Gems}");
        Gems -= Price; // Deduct gems
        Debug.Log($"Gems after deduction in SkipQuestion: {Gems}");
        quizManager.SkipQuestion();
    } else {
        Debug.Log("Not enough gems to skip the question.");
    }
}
}