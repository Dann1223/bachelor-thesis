using UnityEngine;

public class AudioCol : MonoBehaviour
{
    public AudioSource MySource;
    public AudioClip E;
    public AudioClip C;
    void Awake()
    {
        switch (PlayerPrefs.GetInt("dropdoenText"))
        {
            case 0:
                MySource.GetComponent<AudioSource>().clip = E;
                MySource.Play();
                break;
            case 1:
                MySource.GetComponent<AudioSource>().clip = C;
                MySource.Play();
                break;
        }
        
    }


    void Update()
    {
        
    }
}
