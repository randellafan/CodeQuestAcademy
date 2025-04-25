using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<QnA> QuestionAndAnswers; // List of questions and answers
    public GameObject[] options; // UI options for answers
    public int currentQuestion; // Index of the current question
    public TextMeshProUGUI QuestionTxt; // Text component for displaying the question
    public string sceneName = "Main2"; // Scene to load when questions are finished
    public List<int> wrongAnswerIndices; // List to store indices of wrong answers
    public Text scoreText;
    public int score;
    public int multi = 0;


    private void Start()
{
    generateQuestion(); // Start by generating the first question
    score = 0;

    scoreText.text = "Score: " + score;

    // Load Gems from PlayerPrefs, defaulting to 50 if no value is saved
}

    public void correct()
    {
        if (currentQuestion >= 0 && currentQuestion < QuestionAndAnswers.Count)
        {
            // Remove the current question
            QuestionAndAnswers.RemoveAt(currentQuestion);
            // Generate a new question
            generateQuestion();
            // Set all options active
            SetOptionsActive(true);
            
            score += 250 + multi*25;
            PlayerPrefs.SetInt("score",score);
            scoreText.text = "Score: " + score;

            multi += 1;

        }
    }

    public void wrong()
    {
        if (currentQuestion >= 0 && currentQuestion < QuestionAndAnswers.Count)
        {    
            score -= 200;
            PlayerPrefs.SetInt("score",score);
            scoreText.text = "Score: " + score;
            
            multi = 0;
        }
    }

    public void SkipQuestion()
{
    if (currentQuestion >= 0 && currentQuestion < QuestionAndAnswers.Count)
    {

        // Remove the current question from the list
        QuestionAndAnswers.RemoveAt(currentQuestion);

        // Generate a new question
        generateQuestion();

        // Set all options active
        SetOptionsActive(true);

        multi = 0;

        score += 250 + multi * 25;
        PlayerPrefs.SetInt("score", score);
        scoreText.text = "Score: " + score;
    }
    else
    {
        Debug.Log("Not enough gems to skip the question.");
    }
}

    void setAnswers()
    {
        wrongAnswerIndices = new List<int>(); // Initialize the list

        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false; // Reset the isCorrect flag
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QuestionAndAnswers[currentQuestion].Answers[i];

            if (QuestionAndAnswers[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Answers>().isCorrect = true; // Mark the correct answer
            }
            else
            {
                wrongAnswerIndices.Add(i); // Collect wrong answer indices
            }
        }
    }

    void generateQuestion()
    {
        if (QuestionAndAnswers.Count > 0)
        {
            currentQuestion = Random.Range(0, QuestionAndAnswers.Count); // Select a random question
            QuestionTxt.text = QuestionAndAnswers[currentQuestion].Question; // Display the question
            setAnswers(); // Set the answers for the current question
            // Set all options active when a new question is generated
            SetOptionsActive(true);
        }
        else
        {
            ChangeScene(); // Change scene if no questions are left
        }
    }

    void SetOptionsActive(bool isActive)
    {
        foreach (GameObject option in options)
        {
            option.SetActive(isActive); // Set the active state of each option
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // Load the specified scene
    }
}