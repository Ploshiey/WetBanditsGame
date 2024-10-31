using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Goober gooberScript;
    public GameObject journal;
    public GameObject craftingError;
    public GameObject[] tileCollectables;
    #region Inventory
    [Header("Inventory")]
    public TextMeshProUGUI leaf;
    public TextMeshProUGUI rock;
    public TextMeshProUGUI stick;
    public TextMeshProUGUI moss;
    public TextMeshProUGUI torch;
    public TextMeshProUGUI rope;
    public TextMeshProUGUI sharpenedRock;
    public TextMeshProUGUI axe;

    public GameObject invTorch;
    public GameObject invRope;
    public GameObject invSharpenedRock;
    public GameObject invAxe;

    public Sprite[] mossStone;
    private int temp;
    #endregion
    #region Crafting
    [Header("Crafting")]
    [SerializeField] private GameObject torchGrid;
    [SerializeField] private GameObject ropeGrid;
    [SerializeField] private GameObject sharpenedRockGrid;
    [SerializeField] private GameObject axeGrid;
    #endregion
    public GameObject PhysicalTorch;
    public AudioSource source;
    #region Counters
    private string type;
    private int Leaf = 0;
    private int Rock = 0;
    private int Stick = 0;
    private int Moss = 0;
    public int Torch = 0;
    private int Rope = 0;
    private int SharpenedRock = 0;
    public int Axe = 0;
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
            if (other.gameObject.name == "Moss" && other.gameObject.GetComponent<SpriteRenderer>().sprite == mossStone[0])
            {
                other.gameObject.GetComponent<SpriteRenderer>().sprite = mossStone[1];
                other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                Collecting(type);
            }
            else
            {
                other.gameObject.SetActive(false);
                Collecting(type);  
            }
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
            Torch = Torch + 15;
            TorchCount();
            PhysicalTorch.gameObject.SetActive(true);
            StartCoroutine(torchDeminish());
            
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
        }
        else
        {
            axeGrid.SetActive(false);
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
    #endregion

    public IEnumerator torchDeminish()
    {
        while (Torch > 0)
        {
            yield return new WaitForSeconds(2);
            Torch--;
            TorchCount();
        }
        PhysicalTorch.gameObject.SetActive(false);
    }
}
