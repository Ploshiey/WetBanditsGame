using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CameraScript : MonoBehaviour
{
    private Vector3 camPos;
    
    [SerializeField] Vector3 area0;
    [SerializeField] Vector3 area1;
    [SerializeField] Vector3 area2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CamChange(int value)
    {
        switch (value)
        {
            case 0:
                camPos = area0;
                this.transform.position = camPos;
                break;

            case 1:
                camPos = area1;
                this.transform.position = camPos;
                break;

            case 2:
                camPos = area2;
                this.transform.position = camPos;
                break;

            default:
                break;
        }
    }
}
