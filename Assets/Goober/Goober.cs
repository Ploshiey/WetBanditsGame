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
    [SerializeField] GameObject phoneyGoob;
    [SerializeField] GameObject killerGoob;
    public bool discovered;
    public bool goobOnTheMove;
    private bool adj;
    private bool wait;
    [SerializeField] GameObject player;
    [SerializeField] GameObject goober;
    [SerializeField] private int speed = 3;
    [SerializeField] private Vector3[] goToPoz;
    [SerializeField] private AudioSource Audable;
    public int GoobLocat;
    private int GoobWanderLocat;
    public int locat;
    private int randMove;
    // Start is called before the first frame update
    void Start()
    {
        discovered = false;
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
        #region goober chasing in same tile
        if (discovered == true && locat == GoobLocat)
        {
            gooberPerfectChase();
        }
        #endregion

        #region goober follow to next tile
        if (discovered == true && GoobLocat != locat && goobOnTheMove == false && goobAdj(adj))
        {
            gooberChase();
        }
        #endregion

        #region goober loses the player
        if (discovered && GoobLocat != locat && goobOnTheMove == false && !goobAdj(adj))
        {
            discovered = false;
            Audable.Pause();
            Audable.enabled = false;
        }
        #endregion

        #region goober wandering around

        #region goober selecting new wander target
        if (!goobAdj(adj) && GoobLocat != locat && !discovered && !goobOnTheMove)
        {
            GoobWanderLocat = GoobLocat;
            gooberWanderSelection();
            if (GoobWanderLocat != GoobLocat)
            {
                Debug.Log("Direction has been selected successfully");
                goobOnTheMove = true;
            }
        }
        #endregion

        #region goober wandering towards random target tile
        if (GoobLocat != GoobWanderLocat && goobOnTheMove == true)
        {
            gooberWandering();
        }
        #endregion

        #region when goober reaches the wander target
        if (GoobLocat == GoobWanderLocat && goobOnTheMove && !wait)
        {
            Debug.Log("Should be once");
            gooberHiding();
            wait = true;
            StartCoroutine(waitForGoobMove());
        }
        #endregion

        #endregion

        #region goober hide
        if (GoobLocat == GoobWanderLocat && !discovered && !wait)
        {
            Debug.Log("Shouldn't be happening");
            gooberHiding();
            wait = true;
        }
        #endregion

        #region goober hiding when in adjacent tile
        if (goobAdj(adj) && !discovered && !wait)
        {
            goobOnTheMove = false;
            wait = true;
            gooberHiding();
            Debug.Log("Should defo not be happening");
        }
        #endregion
    }

    private IEnumerator waitForGoobMove()
    {
        yield return new WaitForSeconds(20);
        goobOnTheMove = false;
        wait = false;
    }
    private IEnumerator goobIFrames()
    {
        killerGoob.GetComponent<GooberEvilScript>().enabled = false;
        yield return new WaitForSeconds(2);
        killerGoob.GetComponent<GooberEvilScript>().enabled = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && discovered == false)
        {
            phoneyGoob.SetActive(false);
            goober.GetComponent<SpriteRenderer>().enabled = true;
            discovered = true;
            goobOnTheMove = false;
            wait = false;
            Audable.enabled = true;
            Audable.Play();
            StartCoroutine(goobIFrames());
        }
    }

    private void gooberPerfectChase()
    {
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }

    private void gooberChase()
    {
        //if player is in the tile to the right of the Goober
        if (locat - GoobLocat == 1 && (GoobLocat != 3 || GoobLocat != 7 || GoobLocat != 11 || GoobLocat != 15))
        {
            Vector3 localPosition = goToPoz[GoobLocat + 1] - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        //if player is in the tile below the Goober
        else if (GoobLocat - locat - 4 == 0)
        {
            Vector3 localPosition = goToPoz[GoobLocat - 4] - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        //if the player is in the tile to the left of the Goober
        else if (GoobLocat - locat == 1 && (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12))
        {
            Vector3 localPosition = goToPoz[GoobLocat - 1] - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        //if the player is in the tile above the Goober
        else if (locat - GoobLocat - 4 == 0)
        {
            Vector3 localPosition = goToPoz[GoobLocat + 4] - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
    }

    private void gooberHiding()
    {
        goober.GetComponent<SpriteRenderer>().enabled = false;
        areaDisguises.areaHidables(GoobLocat);
    }

    private void gooberWanderSelection()
    {
        randMove = Random.Range(0, 4);
        switch (randMove)
        {
            case 0:
                if (GoobLocat != 4 && GoobLocat != 8 && GoobLocat != 12 && GoobLocat != 0)
                {
                    GoobWanderLocat = GoobLocat - 1;
                }
                break;
            case 1:
                if (GoobLocat != 12 && GoobLocat != 13 && GoobLocat != 14 && GoobLocat != 15)
                {
                    GoobWanderLocat = GoobLocat + 4;
                }
                break;
            case 2:
                if (GoobLocat != 3 && GoobLocat != 7 && GoobLocat != 11 && GoobLocat != 15)
                {
                    GoobWanderLocat = GoobLocat + 1;
                }
                break;
            case 3:
                if (GoobLocat != 0 && GoobLocat != 1 && GoobLocat != 2 && GoobLocat != 3)
                {
                    GoobWanderLocat = GoobLocat - 4;
                }
                break;
            default:
                break;
        }
        if(GoobWanderLocat > 15)
        {
            GoobWanderLocat = GoobLocat;
        }
    }

    private void gooberWandering()
    {
        Vector3 localPosition = goToPoz[GoobWanderLocat] - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
    }

    private bool goobAdj(bool Bool)
    {
        if ((locat - GoobLocat == 1 && (GoobLocat != 3 || GoobLocat != 7 || GoobLocat != 11 || GoobLocat != 15)) || (GoobLocat - locat - 4 == 0) ||
        (GoobLocat - locat == 1 && (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12)) || (locat - GoobLocat - 4 == 0))
        {
            Bool = true;
        }
        else
        {
            Bool = false;
        }
            return Bool;
    }
}