using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Animation_UI : MonoBehaviour
{
    public GameObject OBJ;

    public void move_X(float posmove)
    {
        OBJ.transform.DOLocalMoveX(posmove, 0.5f);
    }
}
