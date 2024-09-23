using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Goober : MonoBehaviour
{
    public AreaDisguises areaDisguises;
    public CameraScript camscript;
    private int gooberPos;
    [SerializeField] GameObject phoney;
    private bool discovered;
    [SerializeField] GameObject player;
    [SerializeField] GameObject goober;
    [SerializeField] private int speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        areaDisguises.areaHidables(0);
        goober.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (discovered == true)
        {
            Vector3 localPosition = player.transform.position - transform.position;
            localPosition = localPosition.normalized;
            transform.Translate(localPosition.x * Time.deltaTime * speed, localPosition.y * Time.deltaTime * speed, localPosition.z * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        phoney.SetActive(false);
        goober.GetComponent<SpriteRenderer>().enabled = true;
        discovered = true;

    }
}
