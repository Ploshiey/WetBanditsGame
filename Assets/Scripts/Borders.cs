using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{

    [SerializeField] Vector3 newPos;
    [SerializeField] Vector3 newGoobPos;
    public GameObject Player;
    [SerializeField] CameraScript cams;
    [SerializeField] int poz;
    public Goober Goober;
    [SerializeField] GameObject gooberWhole;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            Player.transform.position = newPos;
            cams.CamChange(poz);
            Goober.playerPozUpdater(poz);
        }
        else if (other.gameObject.tag == "Goober" && (Goober.discovered || Goober.goobOnTheMove))
        {
            Debug.Log("Activated");
            gooberWhole.transform.position = newGoobPos;
            Goober.gooberPozUpdater(poz);
        }
    }
}
