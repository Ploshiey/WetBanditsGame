using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    public TextMeshProUGUI torchOnScreen;

    public GameObject invTorch;
    public GameObject invRope;
    public GameObject invSharpenedRock;
    public GameObject invAxe;

    public GameObject torchUX;

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


    #region Tutorial
    public bool tutorialCompleted = false;
    public GameObject Tutorial;
    public TextMeshProUGUI TutorialText;
    public GameObject arrow1;
    public GameObject arrow2;
    public int tutorialStage = 1;
    public GameObject arrowStick;
    public GameObject arrowMoss;
    #endregion
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(journal.activeSelf == true)
            {
                journal.SetActive(false);
                if(tutorialCompleted == false)
                {
                    Tutorial.SetActive(true);
                }
            }
            else
            {
                journal.SetActive(true);
                Tutorial.SetActive(false);
            }
        }

        if (Stick == 1 && tutorialCompleted == false && tutorialStage == 1)
        {
            arrowStick.SetActive(false);
        }
        if (Moss == 1 && Moss == 1 && tutorialCompleted == false && tutorialStage == 1)
        {
            arrowMoss.SetActive(false);
        }

        if (Stick == 1 && Moss == 1 && tutorialCompleted == false && tutorialStage == 1)
        {
            TutorialText.text = "Press TAB to open Journal";
            tutorialStage += 1;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && tutorialCompleted == false && tutorialStage == 2)
        {
            arrow1.SetActive(true);
            tutorialStage += 1;
        }
        if (tutorialStage == 5)
        {
            tutorialCompleted = true;
        }
        
        if (tutorialCompleted == true)
        {
            Tutorial.SetActive(false);
            arrowStick.SetActive(false);
            arrowMoss.SetActive(false);
            arrow1.SetActive(false);
            arrow2.SetActive(false);
        }
    }

    public void buttonArrow()
    {
        if (tutorialCompleted == false && tutorialStage == 3)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(true);
            tutorialStage += 1;
        }
    }

    public void craftArrow()
    {
        if (tutorialCompleted == false && tutorialStage == 4)
        {
            arrow2.SetActive(false);
            tutorialStage += 1;
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
                other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
            Torch = Torch + 20;
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
        torchOnScreen.text = Torch.ToString();
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
            torchUX.SetActive(true);
            yield return new WaitForSeconds(2);
            Torch--;
            TorchCount();
        }
        if (Torch == 0)
        {
            torchUX.SetActive(false);
        }
        PhysicalTorch.gameObject.SetActive(false);
    }
}
