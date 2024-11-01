using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeOut : MonoBehaviour
{
    public AudioSource music;
    public float fadeOutAmount = 1;

    public void fadeOut()
    {
        if(fadeOutAmount == 0)
        {
            music.volume = 0;
            return;
        }
        StartCoroutine(_FadeSound());
    }

    IEnumerator _FadeSound()
    {
        float t = fadeOutAmount;
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
            music.volume = t/fadeOutAmount;
        }
        yield break;
    }
}
