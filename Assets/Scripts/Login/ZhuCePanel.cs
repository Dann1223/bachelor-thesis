using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//注册界面
public class ZhuCePanel : MonoBehaviour
{
    //用户名输入
    public InputField m_UserNameInput;
    //用户密码输入 
    public InputField m_UserPassWordInput;

    //用户密码再次输入
    public InputField m_ReUserPassWorInput;

    //确认注册
    public Button m_OkBtn;

    //返回
    public Button m_ReturnBtn; 

    //登入界面
    public GameObject m_LoginPlane;
     
      //提示
    public TipPanel m_TipPanel;

    void Start()
    {
        m_OkBtn.onClick.AddListener(()=>{
             //注册成功
             if(IsSamePassword() &&! UserDataMgr.GetInstance().IsHaveUser(m_UserNameInput.text,m_UserPassWordInput.text))
             {
                Debug.Log("密码一致，可以注册");
                 m_TipPanel.SetStr("注册成功!");
                UserDataMgr.GetInstance().Save(m_UserNameInput.text,m_UserPassWordInput.text);
                m_LoginPlane.SetActive(true);
                gameObject.SetActive(false);
             }
             else
             {
                
                m_TipPanel.SetStr("密码不一致或者已经注册过");
             } 
        });
    }

    
    void Update()
    {
        
    }

    //判断第一次密码和第二次密码是一样得
    public bool IsSamePassword()
    {
        if(m_UserPassWordInput.text == m_ReUserPassWorInput.text)
        {
            return true;
        }

        return false;
    }
}
