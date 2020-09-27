using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetSText(string text)
    {
        this.GetComponent<Text>().text = text;
    }
}
