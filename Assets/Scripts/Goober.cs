using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

/*
    [p12, p13, p14, p15, p8, p9, p10, p11, p4, p5, p6, p7, p0, p1, p2, p3]
 
 
 
*/



public class Goober : MonoBehaviour
{
    public AreaDisguises areaDisguises;
    public CameraScript camscript;
    public Borders border;
    private int gooberPos;
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
            if (locat - GoobLocat == 1 && GoobLocat != 2)
            {
                Vector3 localPosition = goToPoz[GoobLocat + 1] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            else if (GoobLocat - locat - 3 == 0 && GoobLocat != 4)
            {
                Vector3 localPosition = goToPoz[GoobLocat - 3] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            else if (GoobLocat - locat == 1 && GoobLocat != 3)
            {
                Vector3 localPosition = goToPoz[GoobLocat - 1] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
                
            else if(locat - GoobLocat - 3 == 0 && GoobLocat != 1)
            {
                Vector3 localPosition = goToPoz[GoobLocat + 3] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
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
