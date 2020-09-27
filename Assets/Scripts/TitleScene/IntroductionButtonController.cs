using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionButtonController : MonoBehaviour
{
    private AudioSource audioSourceSe;
    public AudioClip clickSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceSe = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        audioSourceSe.PlayOneShot(clickSound);
        FadeManager.FadeOut("IntroductionScene", 0.5f);
    }
}
