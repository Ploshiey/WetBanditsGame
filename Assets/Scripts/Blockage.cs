using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    [SerializeField] private GameObject blockage;
    public Inventory Inv;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && Inv.inv.Contains("Axe"))
        {
            Destroy(blockage);
            Inv.inv.Remove("Axe");
        }
    }
}
