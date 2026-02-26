using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LanguageTextSave : MonoBehaviour
{
    public int Manager_Int;

    private TMP_Text myText;

    public string MyEnglish;

    public string MyChinese;
    void Start()
    {
        Manager_Int = PlayerPrefs.GetInt("dropdoenText");

        myText = this.GetComponent<TMP_Text>();

        if (Manager_Int == 0)
        {
            myText.text = MyEnglish;
        }
        else if (Manager_Int == 1)
        {
            myText.text = MyChinese;
        }
        else
        {
            print("нч");
        }
    }


    
}
