using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game cunt");
    }

}
