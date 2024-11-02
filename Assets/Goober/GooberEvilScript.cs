using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GooberEvilScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Goober Goober;
    public GameObject leGame;
    public GameObject leJumpscare;
    public GameObject leCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Goober.discovered == true)
        {
            leJumpscare.SetActive(true);
            leCamera.SetActive(false);
            leGame.SetActive(false); 
        }
    }

    private void Update()
    {
        
    }
}
