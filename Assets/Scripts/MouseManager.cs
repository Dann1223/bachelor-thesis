using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;   
using UnityEngine.EventSystems;
//鼠标管理器
//游戏中所有的管理器都是单例
public class MouseManager :  MonoBehaviour
{   
    //声明鼠标贴图
    public Texture2D  arrow;

    private void Start()
    {
        Cursor.SetCursor(arrow, new Vector2(16, 16), CursorMode.Auto);

    } 

}
 
