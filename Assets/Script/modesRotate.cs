using UnityEngine;

public class modesRotate : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speedrotate = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, speedrotate*Time.deltaTime, 0));
    }
}
