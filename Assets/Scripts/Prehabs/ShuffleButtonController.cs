using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShuffleButtonController : MonoBehaviour
{
    private AudioSource audioSourceSe;
    public AudioClip rollSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceSe = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        audioSourceSe.PlayOneShot(rollSound);
        FadeManager.FadeOut("MainScene", 2f);
    }
}
