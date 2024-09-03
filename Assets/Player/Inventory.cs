using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Inv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(Inv.activeSelf == true)
            {
                Inv.SetActive(false);
            }
            else
            {
                Inv.SetActive(true);
            }
        }
    }
}
