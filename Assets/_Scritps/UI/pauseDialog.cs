using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseDialog : Dialog
{
    public Text bestScoreText;
    public override void Show(bool isShow)
    {
        Time.timeScale = 0;
        base.Show(isShow);
        if (Prefs.hasNewBest)
        {
            if (bestScoreText)
            {
                bestScoreText.text = "New best: " + Prefs.bestScore.ToString("n0");
            }
            else
            {
                if (bestScoreText)
                {
                    bestScoreText.text = "Best score :" + Prefs.bestScore.ToString("n0");
                }
            }
        }
    }
    public void HomeBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneConst.MAIN);
    }
    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        Close();
    }
    public void ReplayBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneConst.GAMEPLAY);
    }
}
