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
    private int GoobWanderLocat;
    private int locat;
    private bool goobOnTheMove;
    private int randMove;
    // Start is called before the first frame update
    void Start()
    {
        goober.GetComponent<SpriteRenderer>().enabled = false;
        goobOnTheMove = false;

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
        if (discovered == true && locat == GoobLocat && goobOnTheMove == false)
        {
            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
        #endregion
        #region goober follow to next tile
        else if (discovered == true && GoobLocat != locat && goobOnTheMove == false)
        {
            //if player is in the tile to the right of the Goober
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
            //if the player is in the tile to the left of the Goober
            else if (GoobLocat - locat == 1 && (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12))
            {
                Vector3 localPosition = goToPoz[GoobLocat - 1] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            //if the player is in the tile above the Goober
            else if (locat - GoobLocat - 4 == 0 && GoobLocat != 1)
            {
                Vector3 localPosition = goToPoz[GoobLocat + 4] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            #endregion
        }
        #region goober wandering around
        #region goober selecting new wander target
        else if (!(locat - GoobLocat == 1 && (GoobLocat != 3 || GoobLocat != 7 || GoobLocat != 11 || GoobLocat != 15)) && !(GoobLocat - locat - 4 == 0 && (GoobLocat != 0)) &&
                !(GoobLocat - locat == 1 && (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12)) && !(locat - GoobLocat - 4 == 0 && GoobLocat != 1) && !discovered && goobOnTheMove)
        {
            StartCoroutine(waitForGoobMove());
            if (GoobLocat == GoobWanderLocat && goobOnTheMove == true)
            {
                randMove = Random.Range(0, 4);
                switch (randMove)
                {
                    case 0:
                        if (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12 || GoobLocat != 0)
                        {
                            GoobWanderLocat = GoobLocat - 1;
                        }
                        break;
                    case 1:
                        if (GoobLocat != 12 || GoobLocat != 13 || GoobLocat != 14 || GoobLocat != 15)
                        {
                            GoobWanderLocat = GoobLocat + 4;
                        }
                        break;
                    case 2:
                        if (GoobLocat != 3 || GoobLocat != 7 || GoobLocat != 11 || GoobLocat != 15)
                        {
                            GoobWanderLocat = GoobLocat + 1;
                        }
                        break;
                    case 3:
                        if (GoobLocat != 0 || GoobLocat != 1 || GoobLocat != 2 || GoobLocat != 3)
                        {
                            GoobWanderLocat = GoobLocat - 4;
                        }
                        break;
                    default:
                        break;
                }
            }
            #endregion
            #region goober wandering towards rendom target tile
            else if (GoobLocat != GoobWanderLocat && goobOnTheMove == true)
            {
                Vector3 localPosition = goToPoz[GoobWanderLocat] - transform.position;
                localPosition = localPosition.normalized;
                transform.Translate(localPosition.x * Time.deltaTime * speed, 0f * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
            }
            #endregion
            #endregion
        else if (!(locat - GoobLocat == 1 && (GoobLocat != 3 || GoobLocat != 7 || GoobLocat != 11 || GoobLocat != 15)) && !(GoobLocat - locat - 4 == 0 && (GoobLocat != 0)) &&
                !(GoobLocat - locat == 1 && (GoobLocat != 4 || GoobLocat != 8 || GoobLocat != 12)) && !(locat - GoobLocat - 4 == 0 && GoobLocat != 1) && !discovered)
            {
                discovered = false;
                Audable.enabled = false;
                goober.GetComponent<SpriteRenderer>().enabled = false;
                areaDisguises.areaHidables(GoobLocat);

            }




        }

    }

    private IEnumerator waitForGoobMove()
    {
        yield return new WaitForSeconds(20);
        goobOnTheMove = true;
        discovered = false;
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
