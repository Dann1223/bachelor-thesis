using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ModleRoate : MonoBehaviour
{
    public float m_Speed;

    public float m_ScaleSpeed;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"), 0) * Time.deltaTime * m_Speed);

          
        }

        transform.localScale += Input.GetAxis("Mouse ScrollWheel") * Vector3.one * m_ScaleSpeed;
    }
}
