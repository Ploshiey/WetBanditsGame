using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class CameraScript : MonoBehaviour
{
    private Vector3 camPos;
    [SerializeField] Vector3[] currArea;


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
                camPos = currArea[value];
                this.transform.position = camPos;
                break;
                
            case 1:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;
                
            case 2:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;
                
            case 3:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;
                
            case 4:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;
                
            case 5:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 6:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 7:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 8:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 9:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 10:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 11:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 12:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 13:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            case 14:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;
            
            case 15:
                camPos = currArea[value];
                this.transform.position = camPos;
                break;

            default:
                break;
        }
    }
}
