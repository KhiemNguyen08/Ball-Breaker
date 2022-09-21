using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : Singleton<GameGUI>
{
    public Text scoreText;
    public Text timeCountingdownText;
    public pauseDialog pauseDialog;
   public WinDialog winDialog;
    public GameoverDialog gameoverDialog;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void UpdateScore(int score)
    {
        if (scoreText)
        {
            scoreText.text = "Score: " + score.ToString("n0");
        }
    }
    public void UpdateTimeCountdown(int time)
    {
        if (timeCountingdownText)
        {
            timeCountingdownText.text = time.ToString("00");
        }
        if( time <= 0)
        {
            if (timeCountingdownText)
            {
                timeCountingdownText.gameObject.SetActive(false);
            }
        }
        
    }
    public void BackToHomeBtn()
    {
        SceneManager.LoadScene(SceneConst.MAIN);
    }
    public void Pausegame()
    {
        if (pauseDialog)
            pauseDialog.Show(true);
    }
    
}
