using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    
    private static MenuScript instance;

    public static MenuScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MenuScript>();
            }
            return instance;
        }
    }
    
    
    [SerializeField]
    private CanvasGroup[] menus;

    private List<Tuple<String, String>> _paperTextList;
    private int currentPaperIndex = -1;

    [SerializeField] private Text mainContent, keyContent;

    [SerializeField] private Button switchLeft, switchRight;

    private void Awake()
    {
        _paperTextList = new List<Tuple<String, String>>();
    }

    public void OnMenuSwitch()
    {
        if (Keyboard.current.tabKey.isPressed)
        {
            if (_paperTextList.Count > 0)
            {
                Open(0);
                currentPaperIndex = 0;
                mainContent.text = _paperTextList[currentPaperIndex].Item1;
                keyContent.text = _paperTextList[currentPaperIndex].Item2;
                if (_paperTextList.Count == 1)
                {
                    switchLeft.enabled = false;
                    switchRight.enabled = false;
                }
                else
                {
                    switchLeft.enabled = false;
                    switchRight.enabled = true;
                }
            }
        }
        if (Keyboard.current.escapeKey.isPressed)
        {
            Open(1);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        CloseAll();
    }

    public void Open(int id)
    {
        menus[id].alpha = 1;
        menus[id].blocksRaycasts = true;
        Pause();
    }

    public void CloseAll()
    {
        foreach (CanvasGroup canvas in menus)
        {
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
        }
    }

    public void goStartGame()
    {
        SceneManager.LoadScene("GameMap", LoadSceneMode.Single);
    }
    public void goMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void goExit()
    {
        Application.Quit();
    }

    public void PickUpAndAddPaper(Tuple<String, String> content)
    {
        _paperTextList.Add(content);
        Debug.Log(_paperTextList.Count);
    }

    public void SwitchPaperRight()
    {
        if (++currentPaperIndex == _paperTextList.Count-1)
        {
            switchRight.enabled = false;
        }

        mainContent.text = _paperTextList[currentPaperIndex].Item1;
        keyContent.text = _paperTextList[currentPaperIndex].Item2;
        
        switchLeft.enabled = true;
    }
    
    public void SwitchPaperLeft()
    {
        if (--currentPaperIndex == 0)
        {
            switchLeft.enabled = false;
        }
        
        mainContent.text = _paperTextList[currentPaperIndex].Item1;
        keyContent.text = _paperTextList[currentPaperIndex].Item2;
        
        switchRight.enabled = true;
    }
}
