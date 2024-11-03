using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    [SerializeField] private GameObject blockage;
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private AudioSource AudioSource;
    public Inventory Inv;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (Inv.Axe >= 1)
            {
                Destroy(blockage);
                Inv.Axe--;
                AudioSource.Play();

            }
            else if (Inv.Axe < 1)
            {
                Text.text = "Maybe Try Making\nAn Axe";
            }
        }
        else if (other.gameObject.tag == "Player" && !Input.GetKey(KeyCode.E))
        {
            Text.text = "Press E To\nUse Axe";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
