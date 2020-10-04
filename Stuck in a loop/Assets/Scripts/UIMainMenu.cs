using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void NewGamePressed()
    {
        SceneManager.LoadScene("Level1");
    }
    public void HowToPlayPressed()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
