using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public string[] lines; // Array of dialogue lines
    public float textSpeed; // Speed of text appearing
    private int index; // Current index of the dialogue line
    public string sceneName; // Name of the scene to load

    void Start()
    {
        textComponent.text = string.Empty; // Clear the text component
        StartDialogue(); // Start the dialogue
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for mouse button click
        {
            if (textComponent.text == lines[index]) // If the current line is fully displayed
            {
                NextLine(); // Go to the next line
            }
            else
            {
                StopAllCoroutines(); // Stop typing coroutine
                textComponent.text = lines[index]; // Display the full line immediately
            }
        }
    }

    void StartDialogue()
    {
        index = 0; // Initialize index
        StartCoroutine(TypeLine()); // Start typing the first line
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) // Iterate through each character in the current line
        {
            textComponent.text += c; // Append character to text
            yield return new WaitForSeconds(textSpeed); // Wait for the specified text speed
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1) // Check if there are more lines
        {
            index++; // Move to the next line
            textComponent.text = string.Empty; // Clear the text component
            StartCoroutine(TypeLine()); // Start typing the next line
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}