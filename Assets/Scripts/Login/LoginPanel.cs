using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//登入界面
public class LoginPanel : MonoBehaviour
{  
    //用户名
    public InputField m_UserNameInput;

    //密码
    public InputField m_UserPassWordInput;

    //登入
    public Button m_OKBtn;

    //注册
    public Button m_ZhuCeBtn;

    //注册界面
    public GameObject m_ZhuCePnale;

    //开始菜单
    public GameObject m_StartPlane;

    //提示
    public TipPanel m_TipPanel;

    void Start()
    {
        //注册
        m_ZhuCeBtn.onClick.AddListener(()=>{
            m_ZhuCePnale.SetActive(true);
            gameObject.SetActive(false);
        });

        //登入
        m_OKBtn.onClick.AddListener(()=>{
                if(UserDataMgr.GetInstance().IsHaveUser(m_UserNameInput.text,m_UserPassWordInput.text))
                {
                    Debug.Log("登入成功!");
                   
                    gameObject.SetActive(false);
                    m_TipPanel.SetStr("登入成功!");
                    SceneManager.LoadScene("Game");
                }
                else
                { 
                    m_TipPanel.SetStr("登入失败!");
                }
                 
        });

    } 
}
