using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void goStartGame()
    {
        SceneManager.LoadScene("GameMap", LoadSceneMode.Single);
    }
    public void goExit()
    {
        Application.Quit();
    }
}
