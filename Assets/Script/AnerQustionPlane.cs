using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
// Question data structure
public class QuestionTextData
{
    //Question content
    public string Connnet;

    //Options
    public string[] ChooseConnnet;

    //Correct answer indices
    public int[] anwerindex;
}

public class AnerQustionPlane : MonoBehaviour
{
    //Error tip UI
    public GameObject m_ErrorTip;

    //Question data (used to initialize UI)
    public QuestionTextData[] data;

    //Current question index
    [HideInInspector]
    public int index;

    //Back button
    public Button m_ExtBtn;

    //Next button
    public Button m_Ok;

    //Question text
    public Text m_Connet;

    // Option texts
    public Text[] m_ChooseConnet;

    //Toggle components
    public Toggle[] m_Toggles;

    private void OnEnable() {
        m_ExtBtn.gameObject.SetActive(true);
        m_Ok.gameObject.SetActive(true);
        for(int i=0;i<m_Toggles.Length;i++)
        {
            m_Toggles[i].gameObject.SetActive(true);
        }
        InitData(); 
    }

    private void Start() { 
        m_ExtBtn.onClick.AddListener(()=>{
            gameObject.SetActive(false);
        });

        //Submit answer
        m_Ok.onClick.AddListener(()=>{
            if(IsAnwerOk())
            {
                //Move to the next question
                index++;
                if(index>=data.Length)
                {
                    m_Connet.text = "Answer submitted successfully, congratulations on clearing the level";
                    for (int i = 0; i <m_ChooseConnet.Length; i++)
                    {
                        m_ChooseConnet[i].text = "";
                    }

                    for(int i=0;i<m_Toggles.Length;i++)
                    {
                        m_Toggles[i].gameObject.SetActive(false);
                    }

                    m_ExtBtn.gameObject.SetActive(false);
                    m_Ok.gameObject.SetActive(false);

                    Invoke("Hide", 3.0f);
                }
                else
                {
                    //Set next question
                    SetQesqionsText(data[index].Connnet,data[index].ChooseConnnet); 
                } 
            }
            else
            {
                //Show error tip
                m_ErrorTip.SetActive(true);
                //Delay executio
                Invoke("HideErrorTip",1.5f);
            }
            
        });

        InitData(); 
    }

    //Hide panel
    public void Hide()
    {
       gameObject.SetActive(false);
    }

    //Hide error tip
    public void HideErrorTip()
    {
        m_ErrorTip.SetActive(false);
    }

    //Check if answer is correct
    public bool IsAnwerOk()
    {
        //Record the indices of selected options
        int[] recodindex = new int[data[index].anwerindex.Length];
        int index1 = 0;
        for(int i=0;i<m_Toggles.Length;i++)
        {
            if(m_Toggles[i].isOn == true)
            { 
                 recodindex[index1] = i;
                 index1++;
            }
        }

        for(int j=0;j<recodindex.Length;j++)
        {
            if(recodindex[j] != data[index].anwerindex[j])
                return false;
        }

        return true; 
    }

    public void InitData()
    {
        index = 0;
        SetQesqionsText(data[index].Connnet,data[index].ChooseConnnet);
    }

    //Set question content
    public void SetQesqionsText(string _connet,string[] choosec)
    {
        m_Connet.text = _connet;
        for(int i=0;i<m_ChooseConnet.Length;i++)
        {
            m_ChooseConnet[i].text = choosec[i];
        }
    }
}
