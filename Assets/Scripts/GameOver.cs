using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Opening");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
