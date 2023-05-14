using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public AudioSource missSound;

    public bool startPlaying;

    public NotePhysics veggies;
    public NotePhysics sweets;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int missCounter = 50;
    public int veggieCounter = 0;
    public int candyCounter = 0;

    int sceneIndex;

    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;
    public Text missText;
    public Text veggieText;
    public Text candyText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Points: 0";
        missText.text = "50";
        currentMultiplier = 1;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                veggies.hasStarted = true;
                sweets.hasStarted = true;

                theMusic.Play();
            }
        }

    }

    public void NoteHit()
    {
        // Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Streak: x" + currentMultiplier;

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Points: " + currentScore;
      
        if (missCounter < 49){
        missCounter = missCounter + 2;
        }

        if(currentScore >= 6000 && candyCounter >= 5 && veggieCounter >= 10)
        {
            SceneManager.LoadScene("Win");
        }

        if (missCounter != 0)
        {
            missCounter--;
            missText.text = missCounter.ToString();
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown("x"))
        {
            veggieCounter++;
            veggieText.text = " " + veggieCounter;
        }

        if (Input.GetKeyDown("z"))
        {
            candyCounter++;
            candyText.text = " " + candyCounter;
        }

    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentMultiplier = 1;
        multiplierTracker = 0;

        if (missCounter > 0)
        {
            missCounter--;
            missText.text = missCounter.ToString();

            // Play miss sound effect
            missSound.PlayOneShot(missSound.clip);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }

        multiText.text = "Streak: x" + currentMultiplier;
    }
}