using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetSText(string text)
    {
        var m_Text = GetComponent<HyphenationJpn>();
        m_Text.GetText(text);
    }
}
