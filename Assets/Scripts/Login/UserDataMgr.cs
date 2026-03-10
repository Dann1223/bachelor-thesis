using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//用户数据
public class UserData
{
    //用户名
    public string m_UserName;

    //用户密码
    public string m_UserPassWord;

}

//用户数据管理
//存放所有用户名字和密码
public class UserDataMgr : BaseManager<UserDataMgr>
{
    public List<UserData> m_UserData = new List<UserData>(); 

    //当前用户名
    public string m_CurUserName;
    //当前密码
    public string m_CurPossward;

    //读取 
    public void Reader()
    {   
        if(! File.Exists(Application.dataPath + "/Resources/UserDatas.txt"))
        {
            Debug.Log("文件不存在!!");
            return;
        }
        m_UserData.Clear();
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/UserDatas.txt");
        
        string nexitLine;
        while((nexitLine = sr.ReadLine())!=null)
        {
            UserData temp = JsonUtility.FromJson<UserData>(nexitLine);
            m_UserData.Add(temp);
        } 
        sr.Close();

        Debug.Log("读取有几条:" +m_UserData.Count );
    } 

    //保存
    public void Save(string _name,string _possword)
    { 
        
        UserData data = new UserData();
        data.m_UserName = _name;
        data.m_UserPassWord = _possword; 
        m_UserData.Add(data); 
       
        Debug.Log("保存有几条:" +m_UserData.Count );
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/UserDatas.txt"); 
        Debug.Log("路径:" + Application.persistentDataPath);
        for(int i=0;i<m_UserData.Count;i++)
        {
            string temp = JsonUtility.ToJson(m_UserData[i]);
            sw.WriteLine(temp); 
        }
          
        sw.Close();
    }

    //保存-修改
    public void Save1()
    {
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/UserDatas.txt"); 

        for(int i=0;i<m_UserData.Count;i++)
        {
            string temp = JsonUtility.ToJson(m_UserData[i]);
            sw.WriteLine(temp); 
        }
          
        sw.Close();
    }

    //是否存在账户
    public bool IsHaveUser(string _name, string _password)
    {
        Reader();
        //没有用户数据
        if(m_UserData.Count == 0)
        {
            Debug.Log("没有数据");
            return false;
        }
        else    //有用户数据
        {
            //有账号
            if(iSCheckUserHave(_name,_password))
            {
                return true;
            }
            else //没有账号
            {
                return false;
            }
        } 
        
    } 
    

    //查找是否有该用户数据
    private bool iSCheckUserHave(string _name, string _password)
    {
        for(int i=0;i<m_UserData.Count;i++)
        {
            //有账号
            if(m_UserData[i].m_UserName == _name &&
                m_UserData[i].m_UserPassWord == _password)
                {
                    return true;
                }
        }

        //没有账号
        return false;
    }

    //原始密码是否正确
    public bool IsRightOrgCode(string _password)
    {
        for(int i=0;i<m_UserData.Count;i++)
        {   
            //先找到用户名
            if(m_UserData[i].m_UserName == m_CurUserName)
            {
                //判断原始密码是否输入正确
                if( m_UserData[i].m_UserPassWord == _password)
                {
                    return true;
                } 
            }
        }
        return false;
    }

    //修改账号密码
    public void ReSetUserData(string _password)
    {
        //找到当前用户名
        for(int i=0;i<m_UserData.Count;i++)
        {
            if(m_UserData[i].m_UserName == m_CurUserName)
            {
                //修改密码
                m_UserData[i].m_UserPassWord = _password;
                Save1();
                return;
            }
        }
    }
}
