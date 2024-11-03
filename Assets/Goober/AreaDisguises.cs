using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AreaDisguises : MonoBehaviour
{
    [SerializeField] Goober goob;
    [SerializeField] GameObject goober;
    [SerializeField] GameObject AllGoober;
    [SerializeField] GameObject phoney;
    [SerializeField] GameObject shadow;
    [SerializeField] Sprite[] sprites;
    private Sprite curSprite;
    private int DisObj;
    [SerializeField] float[] xmin;
    [SerializeField] float[] xmax;
    private float x;
    [SerializeField] float[] zmin;
    [SerializeField] float[] zmax;
    private float z;
    [SerializeField] float[] y;
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
                hidableSettings();
                tileHiding(0, 0);
                break;
            case 1:
                hidableSettings();
                tileHiding(1, 0);
                break;
            case 2:
                hidableSettings();
                tileHiding(2, 0);
                break;
            case 3:
                hidableSettings();
                tileHiding(3, 0);
                break;
            case 4:
                hidableSettings();
                tileHiding(0, 1);
                break;
            case 5:
                hidableSettings();
                tileHiding(1, 1);
                break;
            case 6:
                hidableSettings();
                tileHiding(2, 1);
                break;
            case 7:
                hidableSettings();
                tileHiding(3, 1);
                break;
            case 8:
                hidableSettings();
                tileHiding(0, 2);
                break;
            case 9:
                hidableSettings();
                tileHiding(1, 2);
                break;
            case 10:
                hidableSettings();
                tileHiding(2, 2);
                break;
            case 11:
                hidableSettings();
                tileHiding(3, 2);
                break;
            case 12:
                hidableSettings();
                tileHiding(0, 3);
                break;
            case 13:
                hidableSettings();
                tileHiding(1, 3);
                break;
            case 14:
                hidableSettings();
                tileHiding(2, 3);
                break;
            case 15:
                hidableSettings();
                tileHiding(3, 3);
                break;

            default:
                 
                break;
        }
    }

    private void hidableSettings()
    {
        DisObj = Random.Range(0, 8);
        curSprite = sprites[DisObj];
        phoney.GetComponent<SpriteRenderer>().sprite = curSprite;
        if (DisObj < 3)
        {
            shadow.SetActive(true);
        }
        else if (3 < DisObj)
        {
            shadow.SetActive(false);
            if (DisObj == 8)
            {
            }
        }
    }

    private void tileHiding(int X, int Z)
    {
        x = Random.Range(xmin[X], xmax[X]);
        z = Random.Range(zmin[Z], zmax[Z]);
        AllGoober.transform.position = new Vector3(x, y[Z], z);
    }
}
