using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("BetaScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Guide()
    {
        SceneManager.LoadScene("Guide Menu");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
