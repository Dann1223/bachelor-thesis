using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;
public class ShowJieUITrigger : MonoBehaviour
{
    public GameObject ui;

    public Highlighter m_Highter;

    public AudioSource m_As;

    public AudioClip m_AClip;

    private void OnMouseDown()
    {
        ui.SetActive(true);

        m_As.clip = m_AClip;

        m_As.Play();
    }

    private void OnMouseEnter()
    {
        m_Highter.ConstantOn();
    }

    private void OnMouseExit()
    {
        m_Highter.ConstantOff();
    }
}
