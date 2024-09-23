using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class AreaDisguises : MonoBehaviour
{
    public Goober goob;
    [SerializeField] GameObject goober;
    [SerializeField] GameObject AllGoober;
    [SerializeField] GameObject phoney;
    [SerializeField] Material[] mats;
    private Material curMat;
    private int DisObj;
    private float x;
    private float z;
    public void areaHidables(int area)
    {
        phoney.SetActive(true);
        switch (area)
        {
            case 0:
                DisObj = Random.Range(0, 3);
                curMat = mats[DisObj];
                phoney.GetComponent<MeshRenderer>().material = curMat;
                x = Random.Range(-32.5f, -14.5f);
                z = Random.Range(31f, 37.5f);
                AllGoober.transform.position = new Vector3(x, 1, z);
                break;
             
            default:
                 
                break;
        }
    }
}
