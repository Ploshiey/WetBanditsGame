using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{

    [SerializeField] Vector3 newPos;
    public GameObject Player;
    [SerializeField] CameraScript cams;
    [SerializeField] int poz;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
