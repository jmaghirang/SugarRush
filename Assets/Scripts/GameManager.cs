using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variable to keep track of the playback position of the audio clip
    private float audioClipPosition = 0f;
    public AudioSource theMusic;
    public AudioSource missSound;

    public bool startPlaying;

    public FoodPhysics veggies;
    public FoodPhysics sweets;

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

    public int veggiesToWin = 10;
    public int sweetsToWin = 6;
    public int scoreToWin = 6000;

    public GameObject pauseMenuPanel;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "0/" + scoreToWin.ToString();
        missText.text = "50";
        veggieText.text = "0/" + veggiesToWin.ToString();
        candyText.text = "0/" + sweetsToWin.ToString();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        // code that didn't work
        /*if (veggies.foodCount == 0 && sweets.foodCount == 0)
        {
            if (currentScore < scoreToWin || veggieCounter < veggiesToWin || candyCounter < sweetsToWin)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                SceneManager.LoadScene("Win");
            }
        }*/

        // also didn't work
        /*
        // Check if there are no more entities in the scene
        if (veggies.GetActiveEntities().Count == 0 && sweets.GetActiveEntities().Count == 0)
        {
            // Check if the player met the winning conditions
            if (currentScore >= scoreToWin && candyCounter >= sweetsToWin && veggieCounter >= veggiesToWin)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        */

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
        scoreText.text = currentScore.ToString() + "/" + scoreToWin.ToString();
      
        if (missCounter < 49){
        missCounter = missCounter + 2;
        }

        if(currentScore >= scoreToWin && candyCounter >= sweetsToWin && veggieCounter >= veggiesToWin)
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
            veggieText.text = veggieCounter.ToString() + "/" + veggiesToWin.ToString();
        }

        if (Input.GetKeyDown("z"))
        {
            candyCounter++;
            candyText.text = candyCounter.ToString() + "/" + sweetsToWin.ToString();
        }

    }

    public void NoteMissed()
    {
        // Debug.Log("Missed Note");

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

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenuPanel.SetActive(true);

        audioClipPosition = theMusic.time;
        theMusic.Pause();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuPanel.SetActive(false);

        theMusic.time = audioClipPosition;
        theMusic.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}