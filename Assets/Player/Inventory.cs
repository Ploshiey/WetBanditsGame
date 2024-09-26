using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject journal;
    public GameObject craftingError;
    #region Inventory
    [Header("Inventory")]
    public List<string> inv;
    public TextMeshProUGUI leaf;
    public TextMeshProUGUI rock;
    public TextMeshProUGUI stick;
    public TextMeshProUGUI moss;
    public TextMeshProUGUI torch;
    public TextMeshProUGUI rope;
    public TextMeshProUGUI sharpenedRock;
    public TextMeshProUGUI trap;
    public TextMeshProUGUI axe;

    public GameObject invTorch;
    public GameObject invRope;
    public GameObject invSharpenedRock;
    public GameObject invTrap;
    public GameObject invAxe;
    
    private int temp;
    #endregion
    #region Crafting
    [Header("Crafting")]
    [SerializeField] private GameObject torchGrid;
    [SerializeField] private GameObject ropeGrid;
    [SerializeField] private GameObject sharpenedRockGrid;
    [SerializeField] private GameObject axeGrid;
    [SerializeField] private GameObject trapGrid;
    #endregion
    public AudioSource source;
    [SerializeField] private Vector2[] pozits;
    #region Counters
    private string type;
    private int Leaf = 0;
    private int Rock = 0;
    private int Stick = 0;
    private int Moss = 0;
    private int Torch = 0;
    private int Rope = 0;
    private int SharpenedRock = 0;
    private int Trap = 0;
    private int Axe = 0;
    #endregion    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(journal.activeSelf == true)
            {
                journal.SetActive(false);
            }
            else
            {
                journal.SetActive(true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Collectable") && Input.GetKey(KeyCode.E))
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
            LeafCount();
        }
        else if (arg == "Rock")
        {
            Rock++;
            RockCount();
        }
        else if(arg == "Stick")
        {
            Stick++;
            StickCount();
        }
        else if(arg == "Moss")
        {
            Moss++;
            MossCount();
        }
        else
        {
            Debug.Log("How did u manage this???");
        }
    }
    #region Crafting
    public void CraftingTorch()
    {
        if (Stick >= 1 && Moss >= 1)
        {
            Stick--;
            StickCount();
            Moss--;
            MossCount();
            Torch++;
            TorchCount();
            if (!inv.Contains("Torch"))
            {
                inv.Add("Torch");
                temp = inv.IndexOf("Torch");
                invTorch.transform.localPosition = pozits[temp];
                invTorch.SetActive(true);

            }
        }
        else
        {
            torchGrid.SetActive(false);
            craftingError.SetActive(true);
        }
    }
    public void CraftingRope()
    {
        if (Leaf >= 3 && Moss >= 1)
        {
            Leaf = Leaf - 3;
            LeafCount();
            Moss--;
            MossCount();
            Rope++;
            RopeCount();
            if (!inv.Contains("Rope"))
            {
                inv.Add("Rope");
                temp = inv.IndexOf("Rope");
                invRope.transform.localPosition = pozits[temp];
                invRope.SetActive(true);
            }
        }
        else
        {
            ropeGrid.SetActive(false);
            craftingError.SetActive(true);
        }
    }
    public void CraftingSharpenedRock()
    {
        if (Rock >= 2)
        {
            Rock = Rock - 2;
            RockCount();
            SharpenedRock++;
            SharpenedRockCount();
            if (!inv.Contains("SharpenedRock"))
            {
                inv.Add("SharpenedRock");
                temp = inv.IndexOf("SharpenedRock");
                invSharpenedRock.transform.localPosition = pozits[temp];
                invSharpenedRock.SetActive(true);
            }
        }
        else
        {
            sharpenedRockGrid.SetActive(false);
            craftingError.SetActive(true);
        }
    }
    public void CraftingAxe()
    {
        if (SharpenedRock >= 1 && Rope >= 1 && Stick >= 1)
        {
            SharpenedRock--;
            SharpenedRockCount();
            Rope--;
            RopeCount();
            Stick--;
            StickCount();
            Axe++;
            AxeCount();
            if (!inv.Contains("Axe"))
            {
                if(Rope == 0)
                {
                    inv.Remove("Rope");
                    invRope.SetActive(false);
                }
                if(SharpenedRock == 0)
                {
                    inv.Remove("SharpenedRock");
                    invSharpenedRock.SetActive(false);
                }
                inv.Add("Axe");
                temp = inv.IndexOf("Axe");
                invAxe.transform.localPosition = pozits[temp];
                invAxe.SetActive(true);
                
            }
        }
        else
        {
            axeGrid.SetActive(false);
            craftingError.SetActive(true);
        }
    }
    public void CraftingTrap()
    {
        if (SharpenedRock >= 4 && Rope >= 2 && Stick >= 2)
        {
            SharpenedRock = SharpenedRock - 4;
            SharpenedRockCount();
            Rope = Rope - 2;
            RopeCount();
            Stick = Stick - 2;
            StickCount();
            Trap++;
            TrapCount();
            if (!inv.Contains("Trap"))
            {
                if (Rope == 0)
                {
                    inv.Remove("Rope");
                    invRope.SetActive(false);
                }
                if (SharpenedRock == 0)
                {
                    inv.Remove("SharpenedRock");
                    invSharpenedRock.SetActive(false);
                }
                inv.Add("Trap");
                temp = inv.IndexOf("Trap");
                invTrap.transform.localPosition = pozits[temp];
                invTrap.SetActive(true);
                
            }
        }
        else
        {
            trapGrid.SetActive(false);
            craftingError.SetActive(true);
        }
    }
    #endregion
    #region Count Setters
    public void LeafCount()
    {
        leaf.text = Leaf.ToString();
    }
    public void RockCount()
    {
        rock.text = Rock.ToString();
    }
    public void StickCount()
    {
        stick.text = Stick.ToString();
    }
    public void MossCount()
    {
        moss.text = Moss.ToString();
    }
    public void TorchCount()
    {
        torch.text = Torch.ToString();
    }
    public void RopeCount()
    {
        rope.text = Rope.ToString();
    }
    public void SharpenedRockCount()
    {
        sharpenedRock.text = SharpenedRock.ToString();
    }
    public void AxeCount()
    {
        axe.text = Axe.ToString();
    }
    public void TrapCount()
    {
        trap.text = Trap.ToString();
    }
    #endregion
}
