using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public int[] langHolder;
    public int lang;
    public float vol;
    public int sound;
    public AudioSource[] audioSources;
    

    private void Start()
    {
        langChange(0);
        volChange(-1, 1f);
    }
    public void langChange(int i)
    {
        
        lang = langHolder[i];
    }

    public void volChange(int p, float v)
    {
        switch (p)
        {
            case 0:
            {
                audioSources[p].volume = v;
                break;
            }
            case 1:
            {
                audioSources[p].volume = v;
                break;
            }
            default:
            {
                audioSources[0].volume = v;
                audioSources[1].volume = v;
                break;
                }
        }
    }
}
