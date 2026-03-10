using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSetPanel : MonoBehaviour
{
    public Scrollbar m_Scrollbar;

    public AudioSource m_As;

    public Button m_OkBtn;
    
    void Start()
    {
        float valu = PlayerPrefs.GetFloat("M");
        
        m_Scrollbar.value = valu;

        m_OkBtn.onClick.AddListener(() =>
        {
            PlayerPrefs.SetFloat("M", m_As.volume);
        });
    }

    
    void Update()
    {
        m_As.volume = m_Scrollbar.value;
    }
}
