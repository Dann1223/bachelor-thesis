using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVTrigger : MonoBehaviour
{
    public GameObject TVUI;

    private bool m_IsPress;

    private void OnMouseDown()
    {
        m_IsPress = !m_IsPress;

        TVUI.SetActive(m_IsPress);
    }
}
