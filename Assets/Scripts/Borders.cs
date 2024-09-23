using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{

    [SerializeField] Vector3 newPos;
    public GameObject Player;
    [SerializeField] CameraScript cams;
    [SerializeField] int poz;
    public Goober Goober;
    [SerializeField] GameObject goober;
    [SerializeField] GameObject gooberWhole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            Player.transform.position = newPos;
            cams.CamChange(poz);
        }
        else if (other.gameObject.tag == "Goober" && Goober.discovered == true)
        {
            Debug.Log("Activated");
            gooberWhole.transform.position = newPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
