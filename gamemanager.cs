using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
   
    public int score = 0;
    public static gamemanager instance;
    bool timerstarted = false;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public GameObject wonpanel;
    public GameObject lostpanel;
    public GameObject questContinuePanel;
    public GameObject questStartPanel;
    public GameObject scoreandtimecanvas;
    public GameObject pausepanel;
    public GameObject treasures;
    bool npcInteracted =false;
    float timer = 150;
    bool paused = false;
    bool lostgame = false;
    bool wongame = false;
    


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Cursor.visible = false;
            Screen.lockCursor = true;
        }

        if (paused || lostgame || wongame)
        {
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
        Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.Escape)&paused ==false)
        {
            paused = true;
            soundManager.instance.buttonSound();
            pause();
        }
        if (Input.GetKey(KeyCode.O))
        {
            won();
        }
        if (Input.GetKey(KeyCode.P))
        {
            lost();
        }
        scoreText.text = score + "/9";
        if (score == 9)
        {
            if (wongame == false)
            {
                won();
                wongame = true;
            }

            //won
        }
        if (timer <= 0)
        {
            if (lostgame == false)
            {
                lost();
                lostgame = true;
            }


            //lost


        }
        if (timerstarted & timer >0)
        {
            timer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            if(timer<=0)
                timerText.text = "0:00";
            else
            timerText.text = minutes + ":" + seconds;

        }

    }
    public void startTimer()
    {
        timerstarted = true;
    }
    public void restartGame()
    {
        Cursor.visible = false;
        Screen.lockCursor = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void showQuest()
    {
        if (npcInteracted == false)
        {
            npcInteracted = true;
            questContinuePanel.SetActive(true);
        }
    }
    public void continueButton()
    {
        questContinuePanel.SetActive(false);
        questStartPanel.SetActive(true);

    }
    public void startButton()
    {
        treasures.SetActive(true);
        questStartPanel.SetActive(false);
        scoreandtimecanvas.SetActive(true);
        timerstarted = true;

    }
    public void pause()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
        timerstarted = false;
        Time.timeScale = 0f;
        pausepanel.SetActive(true);
    }
    public void resume()
    {
        paused = false;
        Cursor.visible = false;
        Screen.lockCursor = true;
        timerstarted = true;
        Time.timeScale = 1f;
        pausepanel.SetActive(false);
    }
    public void won()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
        timerstarted = false;
        Time.timeScale = 0f;
        wonpanel.SetActive(true);
    }
    public void lost()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
        Time.timeScale = 0f;
        lostpanel.SetActive(true);
    }
}
