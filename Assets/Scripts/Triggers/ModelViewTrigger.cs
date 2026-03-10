using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class ModelViewTrigger : MonoBehaviour
{
    public GameObject UI;

    public Highlighter m_Highlighter;

    private void OnMouseDown()
    {
        UI.SetActive(true);    
    }

    private void OnMouseEnter()
    {
        m_Highlighter.ConstantOn();
    }

    private void OnMouseExit()
    {
        m_Highlighter.ConstantOff();
    }
}
