using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        StartCoroutine(GameStart());

    }
    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Opening");
    }


    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit the game cunt");
    }

}
