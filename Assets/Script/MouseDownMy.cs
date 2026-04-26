using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDownMy : MonoBehaviour
{

    public GameObject obj;
    public void OnMouseDown()
    {
        obj.SetActive(true);
    }
    public void TextureExit()
    {
        obj.SetActive(false);
    }

}

