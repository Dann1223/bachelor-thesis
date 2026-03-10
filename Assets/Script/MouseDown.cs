using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDown : MonoBehaviour
{

    public GameObject obj;
    public void OnMouseDown()
    {
        obj.SetActive(true);
        BoxCol.insBoxCol.start_box();
    }
    public void TextureExit()
    {
        obj.SetActive(false);
        BoxCol.insBoxCol.exit_Box();
    }

}

