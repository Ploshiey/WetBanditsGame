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
        temp = Random.Range(1, 16);
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
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-101f, -78f);
                z = Random.Range(-2f, 11f);
                AllGoober.transform.position = new Vector3(x, -48, z);
                break;
            case 2:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-1f, 22f);
                z = Random.Range(-2f, 11f);
                AllGoober.transform.position = new Vector3(x, -48, z);
                break;
            case 3:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(99f, 116.5f);
                z = Random.Range(-2f, 11f);
                AllGoober.transform.position = new Vector3(x, -48, z);
                break;
            case 4:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-198f, -178f);
                z = Random.Range(98f, 111f);
                AllGoober.transform.position = new Vector3(x, 2, z);
                break;
            case 5:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-101f, -42f);
                z = Random.Range(98f, 111f);
                AllGoober.transform.position = new Vector3(x, 2, z);
                break;
            case 6:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-1f, 22f);
                z = Random.Range(98f, 111f);
                AllGoober.transform.position = new Vector3(x, 2, z);
                break;
            case 7:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(99f, 116.5f);
                z = Random.Range(98f, 111f);
                AllGoober.transform.position = new Vector3(x, 2, z);
                break;
            case 8:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-198f, -178f);
                z = Random.Range(198f, 211f);
                AllGoober.transform.position = new Vector3(x, 52, z);
                break;
            case 9:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-101f, 42f);
                z = Random.Range(198f, 211f);
                AllGoober.transform.position = new Vector3(x, 52, z);
                break;
            case 10:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-1f, 22f);
                z = Random.Range(198f, 211f);
                AllGoober.transform.position = new Vector3(x, 52, z);
                break;
            case 11:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(99f, 116.5f);
                z = Random.Range(198f, 211f);
                AllGoober.transform.position = new Vector3(x, 52, z);
                break;
            case 12:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-198f, -178f);
                z = Random.Range(298f, 311f);
                AllGoober.transform.position = new Vector3(x, 102, z);
                break;
            case 13:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-101f, 42f);
                z = Random.Range(298f, 311f);
                AllGoober.transform.position = new Vector3(x, 102, z);
                break;
            case 14:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-1f, 22f);
                z = Random.Range(298f, 311f);
                AllGoober.transform.position = new Vector3(x, 102, z);
                break;
            case 15:
                DisObj = Random.Range(0, 4);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(99f, 116.5f);
                z = Random.Range(298f, 311f);
                AllGoober.transform.position = new Vector3(x, 102, z);
                break;

            default:
                 
                break;
        }
    }
}
