using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerNuber : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SceneInt(int a)
    {
        SceneManager.LoadScene(a);
    }
    public void ExitUI()
    {
        Application.Quit();
    }
}
