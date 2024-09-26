using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionText : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
    }
}
