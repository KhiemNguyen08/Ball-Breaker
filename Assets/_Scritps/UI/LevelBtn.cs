using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public int levelGoto;
    public bool isUnlocked;
    public GameObject levelState;
    public Image icon;
    public Text levelText;
    public Sprite chackmark;
    public Sprite lockIcon;
    Button m_btnComp;
    private void Start()
    {
        if (levelText)
        {
            levelText.text = (levelGoto+1).ToString("00");
        }
        m_btnComp = GetComponent<Button>();
        if (m_btnComp)
        {
            m_btnComp.onClick.AddListener(() => GotoLevel());
        }
        if (!Prefs.IsgameEnter())
        {
            Prefs.SetLevelUnlocked(levelGoto,isUnlocked);
        }
        if (Prefs.isLevelUnlocked(levelGoto))
        {
            if (levelState)
            {
                levelState.SetActive(false);
            }
            if (Prefs.isLevelpassed(levelGoto))
            {
                if (levelState)
                {
                    levelState.SetActive(true);
                }
                if(icon && chackmark)
                {
                    icon.sprite = chackmark;
                }
            }
        }
        else
        {
            if (levelState)
            {
                levelState.SetActive(true);
            }
            if(icon && lockIcon)
            {
                icon.sprite = lockIcon;
            }
        }
    }
    public void GotoLevel()
    {
        if (Prefs.isLevelUnlocked(levelGoto))
        {
            LevelManager.Ins.CurLevel = levelGoto;
            SceneManager.LoadScene(SceneConst.GAMEPLAY);
        }
    }
}
