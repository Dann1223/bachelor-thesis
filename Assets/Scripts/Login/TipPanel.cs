using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipPanel : MonoBehaviour
{
    public Text m_Str;
    
    public void SetStr(string _str)
    {
        m_Str.text = _str;

        gameObject.SetActive(true);
        
        Invoke("HideMe",1.5f);
    }

    public void HideMe()
    {
        gameObject.SetActive(false);
    }
}
