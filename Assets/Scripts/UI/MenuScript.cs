using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup[] menus;

    bool isSomeOpen;

    public void OnMenuSwitch()
    {
        if (Keyboard.current.tabKey.isPressed)
        {
            Open(0);
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
        Debug.Log("asdasdasd");
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
}
