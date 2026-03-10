using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuanYiNUI : MonoBehaviour
{
    public AudioSource m_As;

    public AudioClip clip;
 
    void Start()
    {
        m_As.clip = clip;
        m_As.Play();
    }

   
}
