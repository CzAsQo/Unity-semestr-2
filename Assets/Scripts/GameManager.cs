using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] int timeToEnd;

    bool gamePaused = false;
    bool endGame = false;
    bool win = false;
    public int points = 0;

    public int redKey = 0;
    public int greenKey = 0;
    public int goldKey = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        if (timeToEnd <= 0)
        {
            timeToEnd = 100;
        }
        Debug.Log("Time " + timeToEnd + " s");
        InvokeRepeating("Stopper", 2, 1);


    }
    // Update is called once per frame
    void Update()
    {

        PauseCheck();
        PickUpCheck();

    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P)) // sprawdzanie czy przycisk (P) jest klikniety
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time" + timeToEnd + "s");
        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            endGame = true;
        }
        if (endGame)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void EndGame()
    {
        CancelInvoke("Stopper");
        if (win)
        {
            Debug.Log("Wygra³eœ!!! Grasz jeszcze raz?");
        }
        else
        {
            Debug.Log("Przegra³êœ!!! Grasz jeszcze raz?");
        }
    }

    public void AddPoints(int point)
    {
        points += point;
    }

    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }
   
    public void FreezeTime(int freez)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freez, 1);
    }

    public void AddKey(KeyColor color)
    {
        if(color == KeyColor.Gold)
        {
            goldKey++;
        }
        else if (color == KeyColor.Green)
        {
            greenKey++;
        }
        else if(color == KeyColor.Red)
        {
            redKey++;
        }
    }

    void PickUpCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Actual Time: " + timeToEnd);
            Debug.Log("Key red:" + redKey + ". Key green: " + greenKey + ". Key gold:" + goldKey + ".");
            Debug.Log("Point:" + points);
        }
    }

}
