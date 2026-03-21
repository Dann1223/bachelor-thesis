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
                Text_shows[3].text = "Welcome to the online digital exhibition hall The Charm of Tea.Here, you will find exquisite tea sets, which are not only material carriers of tea culture but also treasures of Chinese civilization. In the online digital exhibition hall The Charm of Tea, let us step into the world of tea sets together and experience the charm and elegance that have transcended thousands of years. Whether it is the accumulation of history or the innovation of art, tea sets, with their unique allure, tell the moving stories of Chinese tea culture. We welcome you to visit The Charm of Tea again and continue to explore more mysteries of tea culture";
                Text_shows[4].text = "Virtual Reality Tea Culture Exhibition Hall";
                break;

            case 1:
                Text_shows[0].text = "开始";
                Text_shows[1].text = "展馆说明";
                Text_shows[2].text = "退出";
                Text_shows[3].text = "欢迎来到线上数字展馆《茶之韵》，这里有精美的茶具，这些都是茶文化的物质载体，更是中华文明的瑰宝。在《茶之韵》线上数字展馆，让我们一同走进茶具的世界，感受那份跨越千年的韵味与雅致。无论是历史的沉淀，还是艺术的创新，茶具都以其独特的魅力，讲述着属于中华茶文化的动人故事。欢迎您再次光临《茶之韵》，继续探索更多茶文化的奥秘！";
                Text_shows[4].text = "虚拟现实茶文化展厅";
                break;

        }

     
    }
}
