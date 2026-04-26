using UnityEngine;

public class BearScript : MonoBehaviour
{
    private Animator ani;
    public int roatatespeed = 1;
    public int movespeed = 1;
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ani.SetBool("Bear Walk", true);
            this.transform.Translate(new Vector3(0, 0, movespeed*Time.deltaTime));
        }
        else
        {
            ani.SetBool("Bear Walk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(new Vector3(0, -roatatespeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(new Vector3(0, roatatespeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            ani.SetBool("back", true);
            this.transform.Translate(new Vector3(0, 0, -movespeed * Time.deltaTime));
        }
        else
        {
            ani.SetBool("back", false);
        }






    }

    
}
