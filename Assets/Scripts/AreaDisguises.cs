using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class AreaDisguises : MonoBehaviour
{
    [SerializeField] Goober goob;
    [SerializeField] GameObject goober;
    [SerializeField] GameObject AllGoober;
    [SerializeField] GameObject phoney;
    [SerializeField] Material[] mats;
    private Material curMat;
    private int DisObj;
    private float x;
    private float z;
    public int temp;

    private void Start()
    {
        temp = Random.Range(1, 5);
        areaHidables(temp);
        goobystarter(temp);
    }

    public void goobystarter(int value)
    {
        goob.gooberPozUpdater(value);
    }
    public void areaHidables(int area)
    {
        phoney.SetActive(true);
        switch (area)
        {
            case 0:
                 
                break;
            case 1:
                DisObj = Random.Range(0, 3);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-2.5f, 15.5f);
                z = Random.Range(0.5f, 6f);
                AllGoober.transform.position = new Vector3(x, 1, z);
                break;
            case 2:
                DisObj = Random.Range(0, 3);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(27.5f, 45.5f);
                z = Random.Range(0.5f, 6f);
                AllGoober.transform.position = new Vector3(x, 1, z);
                break;
            case 3:
                DisObj = Random.Range(0, 3);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-32.5f, -14.5f);
                z = Random.Range(31f, 37.5f);
                AllGoober.transform.position = new Vector3(x, 1, z);
                break;
            case 4:
                DisObj = Random.Range(0, 3);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-2.5f, 15.5f);
                z = Random.Range(31f, 37.5f);
                AllGoober.transform.position = new Vector3(x, 1, z);
                break;
            case 5:
                DisObj = Random.Range(0, 3);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(27.5f, 45.5f);
                z = Random.Range(31f, 37.5f);
                AllGoober.transform.position = new Vector3(x, 1, z);
                break;


            default:
                 
                break;
        }
    }
}
