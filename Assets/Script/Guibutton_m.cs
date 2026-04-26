using UnityEngine;
using UnityEngine.SceneManagement;

public class Guibutton_m : MonoBehaviour
{
    public GUIStyle a;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        a.fontSize = 50;
        a.normal.textColor = Color.red;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 50), "Press M to skip this scene",a))
        {
            SceneManager.LoadScene(2);
        }
    }
}
