using System.Collections;
using System.Collections.Generic;
using TMPro;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Inv;
    private string type;
    public TextMeshProUGUI leaf;
    public TextMeshProUGUI rock;
    public TextMeshProUGUI stick;
    public TextMeshProUGUI moss;
    private int Leaf = 0;
    private int Rock = 0;
    private int Stick = 0;
    private int Moss = 0;
    public AudioSource source;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collectable"))
        {
            type = other.gameObject.name;
            Collecting(type);
            Destroy(other.gameObject);
            source.Play();
        }
    }

    private void Collecting(string arg)
    {
        if(arg == "Leaf")
        {
            Leaf++;
            leaf.text = Leaf.ToString();
        }
        else if (arg == "Rock")
        {
            Rock++;
            rock.text = Rock.ToString();
        }
        else if(arg == "Stick")
        {
            Stick++;
            stick.text = Stick.ToString();
        }
        else if(arg == "Moss")
        {
            Moss++;
            moss.text = Moss.ToString();
        }
        else
        {
            Debug.Log("How did u manage this???");
        }
    }
}
