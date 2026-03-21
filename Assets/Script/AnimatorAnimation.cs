using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimation : MonoBehaviour
{
    public Animator a;
    public Animator b;
    public bool myloop;
    public void OnMouseDown()
    {
        myloop = !myloop;
        AnimationMen();
    }

    private void Awake()
    {
        myloop = true;
    }
    public void AnimationMen()
    {
        if (myloop == true)
        {
            a.Play("2");
            b.Play("0222");
        }
        else if (myloop == false)
        {
          

            a.Play("1");
            b.Play("022");
        }
        else
        {
            
        }
    }
}
