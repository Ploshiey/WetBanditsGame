using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject brokenBridge;
    public GameObject fixedBridge;
    [SerializeField] GameObject canvas;
    public TextMeshProUGUI text;
    public Inventory inv;
    int stick;
    int rope;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (inv.Stick >= 10 && inv.Rope >= 4)
            {
                brokenBridge.SetActive(false);
                fixedBridge.SetActive(true);
                canvas.SetActive(false);
            }
            else if (inv.Stick < 10 || inv.Rope < 4)
            {
                stick = 10 - inv.Stick;
                rope = 4 - inv.Rope;
                text.text = "You still need:\n" + stick + " Sticks & " + rope + " Ropes!";
            }
        }
        else if (other.gameObject.tag == "Player" && !Input.GetKey(KeyCode.E))
        {
            text.text = "You can escape across this bridge... but it's broken.\nMaybe 16 Sticks and 8 Rope could repair it...";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
