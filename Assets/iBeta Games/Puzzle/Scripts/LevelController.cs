using UnityEngine;

namespace iBetaGames
{
    public class LevelController : MonoBehaviour
    {
        public int level; // level unlocked
        public string password = "level";

        public GameController gameControl;

        public Transform pointWarning;

        public GameObject prefabLock;

        public GameObject[] passed;

        public void Awake()
        {
            if (PlayerPrefs.HasKey(password))
            {
                level = PlayerPrefs.GetInt(password);
            }
            else
            {
                level = 1;
                PlayerPrefs.SetInt(password, level);
                PlayerPrefs.Save();
            }
            CheckData();
        }

        void CheckData()
        {
            for (int i = 1; i < level; i++)  
            {
                passed[i - 1].SetActive(true);
            }
        }

        public void SaveLevel()
        {
            PlayerPrefs.SetInt(password, level);
            PlayerPrefs.Save();
        }

        public void SelectLevel(int ln)
        {
            if(ln < level)
            {
                gameControl.level = ln;
                if (level > (ln + 1))
                {
                    gameControl.passed = true;
                }
                else
                {
                    gameControl.passed = false;
                }
                gameControl.StartPlay();
            }
            else
            {
                //----------- < Show error > ---------\\
                Instantiate(prefabLock, pointWarning);
            }
        }    
    }
}