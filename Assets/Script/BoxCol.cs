using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCol : MonoBehaviour
{
    public static BoxCol insBoxCol;

    public SphereCollider[] collider_my;
    
    void Start()
    {
        insBoxCol = this;
    }

    // Update is called once per frame
    public void start_box()
    {
        for (int a = 0; a < collider_my.Length; a++)
        {
            collider_my[a].enabled = false;
        }
    }
    public void exit_Box()
    {
        for (int a = 0; a < collider_my.Length; a++)
        {
            collider_my[a].enabled = true;
        }
    }
}
