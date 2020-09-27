using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleButtonController : MonoBehaviour
{
    private AudioSource audioSourceSe;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        FadeManager.FadeIn(0.5f);
        audioSourceSe = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        audioSourceSe.PlayOneShot(clickSound);
        FadeManager.FadeOut("TitleScene", 0.5f);
    }
}
