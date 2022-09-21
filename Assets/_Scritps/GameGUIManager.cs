using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUIManager : MonoBehaviour
{
    public LevelSelectionDialog levelSelectionDialog;
    public void PlayGame()
    {
        if (levelSelectionDialog)
            levelSelectionDialog.Show(true);
    }
}
