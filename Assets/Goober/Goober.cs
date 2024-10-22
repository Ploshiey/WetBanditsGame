using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;
public class Goober : MonoBehaviour
{
    public AreaDisguises areaDisguises;
    public CameraScript camscript;
    public Borders border;
    [SerializeField] GameObject phoney;
    public bool discovered;
    [SerializeField] GameObject player;
    [SerializeField] GameObject goober;
    [SerializeField] private int speed = 3;
    [SerializeField] private Vector3[] goToPoz;
    [SerializeField] private AudioSource Audable;
    private int GoobLocat;
    private int locat;
    // Start is called before the first frame update
    void Start()
    {
        goober.GetComponent<SpriteRenderer>().enabled = false;
        
    }

    public void playerPozUpdater(int value)
    {
        locat = value;
    }
    public void gooberPozUpdater(int value)
    {
        GoobLocat = value;
    }


    void Update()
    {
        
        if (discovered == true && locat == GoobLocat)
        {
            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        else if(discovered == true && GoobLocat != locat )
        {
            //if player is in the tile to the left of the Goober
            if (locat - GoobLocat == 1 && (GoobLocat != 3 || GoobLocat != 7 || GoobLocat != 11 || GoobLocat != 15))
            {
                Vector3 localPosition = goToPoz[GoobLocat + 1] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            //if player is in the tile below the Goober
            else if (GoobLocat - locat - 4 == 0 && (GoobLocat != 0))
            {
                Vector3 localPosition = goToPoz[GoobLocat - 4] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            //if the player is in the tile to the right of the Goober
            else if (GoobLocat - locat == 1 && (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12))
            {
                Vector3 localPosition = goToPoz[GoobLocat - 1] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            //if the player is in the tile above the Goober
            else if(locat - GoobLocat - 4 == 0 && GoobLocat != 1)
            {
                Vector3 localPosition = goToPoz[GoobLocat + 4] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            
            else
            {
                
                
                
                
                
                
                
                
                discovered = false;
                Audable.enabled = false;
                goober.GetComponent<SpriteRenderer>().enabled = false;
                areaDisguises.areaHidables(GoobLocat);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && discovered == false)
        {
            phoney.SetActive(false);
            goober.GetComponent<SpriteRenderer>().enabled = true;
            discovered = true;
            Audable.enabled = true;
            Audable.Play();
        }
    }
}
