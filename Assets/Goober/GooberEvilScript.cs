using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GooberEvilScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Goober Goober;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Goober.discovered == true)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Update()
    {
        
    }
}
