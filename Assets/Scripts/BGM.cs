using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float value = PlayerPrefs.GetFloat("M");
        GetComponent<AudioSource>().volume = value;
    }

  
}
