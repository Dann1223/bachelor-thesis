using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class buttonAnimation : MonoBehaviour
{
    public int index = 0;
    public GameObject[] obj;
    public TextMeshProUGUI text;
    public Animator[] ani;
    public GameObject parentObj;  // 父物体（在Inspector拖入）
    public GameObject childObj;   // 子物体
    public bool a = false;
    public void myobj()
    {
        obj[2].SetActive(false);
     
    }
    public void GongDoBri()
    {
        a = true;
    }
    public void buttomindex()
    {
        index++;

        switch (index)
        {
            case 1:

                obj[0].SetActive(true);
                text.text = "Put the tea leaves into the teapot";
                //2将茶叶放入茶壶
                break;

            case 2:
                ani[0].enabled = true;
                text.text = "Pour boiling water into the teapot";
                //3将开水注入茶壶
                break;
            case 3:
                ani[1].enabled = true;
                obj[0].SetActive(false);
                obj[1].SetActive(false);//烟雾
                text.text = "4.Filter the tea and place it in a fair cup";
                //4将茶滤放入公道杯
                break;
            case 4:
                ani[2].enabled = true;
                obj[1].SetActive(false);//烟雾
                text.text = "Pour the teapot water into a fair cup";
                //5将茶壶水倒入公道杯
                Invoke("myobj",10F);
                break;

            case 5:
                ani[3].enabled = true;
                obj[1].SetActive(true);//烟雾
                text.text = "Pour the fair cup of water into the teacup";
                //6将公道杯水倒入茶杯
                break;
            case 6:
                ani[4].enabled = true;
                childObj.transform.SetParent(parentObj.transform);
                ani[2].enabled = false;
                text.text = "Close End Simulation";
                //关闭结束模拟
                Invoke("GongDoBri", 11f);
             
                break;
            case 7:
             
                obj[9].SetActive(false);
                obj[10].SetActive(false);
                obj[11].SetActive(true);
                obj[12].SetActive(false);
                obj[13].SetActive(false);

                break;

        }
    }
    void Update()
    {
        if (a)
        {
            obj[3].SetActive(true);
            obj[4].SetActive(true);
            obj[5].SetActive(true);
            obj[6].SetActive(true);
            obj[7].SetActive(false);
            obj[8].SetActive(false);
        }
    }
}
