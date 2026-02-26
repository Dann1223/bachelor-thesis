using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LanguageTextGet : MonoBehaviour
{
    public LanguageText Text;

    public TMP_Text[] Text_shows;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Text.index)
        {
            case 0:
                Text_shows[0].text = "Start";
                Text_shows[1].text = "Exhibition Hall Description";
                Text_shows[2].text = "Exit";
                break;

            case 1:
                Text_shows[0].text = "开始";
                Text_shows[1].text = "展馆说明";
                Text_shows[2].text = "退出";
                break;

        }
    }
}
