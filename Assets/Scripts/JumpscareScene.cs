using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareScene : MonoBehaviour
{
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jumpscare());
    }
    private IEnumerator Jumpscare()
    {
        yield return new WaitForSeconds(2.5f);
        gameOverScreen.SetActive(true);
    }
}
