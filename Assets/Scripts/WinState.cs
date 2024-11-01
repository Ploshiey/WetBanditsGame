using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public GameObject leGame;
    public GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            leGame.SetActive(false);
            winScreen.SetActive(true);
        }
    }
}
