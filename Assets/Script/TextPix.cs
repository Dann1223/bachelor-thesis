using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextPix : MonoBehaviour
{
    public TMP_InputField TextInput;
    public string Text;
    public TMP_Text TextSave;

    public void TextInex()
    {
        Text =  TextInput.text;
        TextSave.text = Text;
        PlayerPrefs.SetString("MyText", Text);
    }
    void Update()
    {
       
        TextSave.text =  PlayerPrefs.GetString("MyText");
    }
}
