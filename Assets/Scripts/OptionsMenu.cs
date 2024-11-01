using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public int[] langHolder;
    public int lang;
    public AudioSource[] audioSources;
    

    private void Start()
    {
        langChange(0);
        volChange(0.5f);
    }
    public void langChange(int i)
    {
        
        lang = langHolder[i];
    }

    
    public void volChange(float v)
    {
        for (int i = 0; i <= audioSources.Length; i++)
        {
            audioSources[i].volume = this.gameObject.GetComponent<Slider>().value;
        }
    }
}
