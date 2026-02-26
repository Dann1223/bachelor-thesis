using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LanguageText : MonoBehaviour
{
    public TMP_Dropdown dropdoen;

    public int index;
    
    public void myText()
    {
        switch (dropdoen.value)
        {
            case 0:
                PlayerPrefs.SetInt("dropdoenText", 0);
                print("Ó¢ÎÄ");
                break;
            case 1:
                PlayerPrefs.SetInt("dropdoenText", 1);
                print("ÖÐÎÄ");
                break;
        }
        index = PlayerPrefs.GetInt("dropdoenText");
    }
    private void Start()
    {
        dropdoen.value = PlayerPrefs.GetInt("dropdoenText"); 
    }
}
