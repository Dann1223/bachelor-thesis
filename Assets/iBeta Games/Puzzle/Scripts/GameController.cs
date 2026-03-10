using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace iBetaGames
{
    public class GameController : MonoBehaviour
    {
        public LevelController lvControl;

        public Explorer explorer;

        public Animator canvasAnim;

        public Image[] places;

        public GameObject[] fragments;

        public int[] tmp;

        public int[] randoms;

        public GameObject fragmentPrefab;

        public GameObject scrollRandoms;

        public GameObject panelPuzzle;

        public Transform contentFragments;

        public Color defoultFragmentColor;

        public Color grayFragmentColor;

        public Color grayYellowColor;

        public int level;

        public int selectedNumber;

        public bool passed;

        public GameObject showScrollBtn;

        public GameObject passedImg;

        public GameObject panelLevelSelect;

        public Text topLevelTxt;

        private void Awake()
        {
            if(!panelLevelSelect.activeSelf)
            {
                panelLevelSelect.SetActive(true);
            }
        }

        public void StartPlay()
        {
            ChechData();
            ClearTmp();
            RandomizeFragments();
        }

        void ChechData()
        {
            panelLevelSelect.SetActive(false);
            passedImg.SetActive(passed);
            selectedNumber = -1;
        }

        void ClearTmp()
        {
            for(int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = -1;
            }
            for (int i = 0; i < randoms.Length; i++)
            {
                randoms[i] = -1;
            }
            foreach (GameObject item in fragments)
            {
                Destroy(item);
            }
            foreach (Image imj in places)
            {
                imj.sprite = null;
                imj.color = grayFragmentColor;
            }
            panelPuzzle.GetComponent<Image>().color = grayYellowColor;
            HideScroll(false);
            topLevelTxt.text = "Level: " + (level + 1);
        }

        public void RandomizeFragments()
        {
            // Create a list of puzzle indices
            List<int> indices = new List<int>();
            for (int i = 0; i < explorer.images[level].puzzles.Length; i++)
            {
                indices.Add(i);
            }

            // Shuffle the list of indices
            for (int i = 0; i < indices.Count; i++)
            {
                int j = UnityEngine.Random.Range(i, indices.Count);
                int temp = indices[i];
                indices[i] = indices[j];
                indices[j] = temp;
            }

            // Create the fragments
            for (int i = 0; i < explorer.images[level].sum; i++)
            {
                GameObject obj = Instantiate(fragmentPrefab, contentFragments) as GameObject;
                fragment ft = obj.GetComponent<fragment>();

                ft.level = level;
                ft.myNumber = indices[i];
                ft.explorer = explorer;
                ft.controller = this;

                fragments[i] = obj;
                randoms[i] = indices[i];

                ft.GetComponent<Image>().sprite = explorer.images[level].puzzles[indices[i]];
            }
        }


        public void SelectFragment(int num, Image s)
        {
            foreach(Transform t in contentFragments)
            {
                t.gameObject.GetComponent<Image>().color = defoultFragmentColor;
            }

            s.color = grayFragmentColor;
            selectedNumber = num;
        }

        public void Placement(int n)
        {
            if(selectedNumber != -1)
            {
                if (tmp[n] == -1)
                {
                    places[n].sprite = explorer.images[level].puzzles[selectedNumber];

                    places[n].color = defoultFragmentColor;

                    tmp[n] = selectedNumber;

                    selectedNumber = -1;

                    SetChange(n, false);

                    foreach (Transform t in contentFragments)
                    {
                        t.gameObject.GetComponent<Image>().color = defoultFragmentColor;
                    }

                    CheckGameWinn();
                }
                else
                {
                    places[n].sprite = null;

                    places[n].color = grayFragmentColor;

                    SetChange(n, true);

                    tmp[n] = -1;

                    selectedNumber = -1;

                    foreach (Transform t in contentFragments)
                    {
                        t.gameObject.GetComponent<Image>().color = defoultFragmentColor;
                    }

                    CheckGameWinn();
                }
            }
            else
            {
                if(tmp[n] != -1)
                {
                    places[n].sprite = null;

                    places[n].color = grayFragmentColor;

                    SetChange(n, true);

                    tmp[n] = -1;

                    selectedNumber = -1;

                    foreach (Transform t in contentFragments)
                    {
                        t.gameObject.GetComponent<Image>().color = defoultFragmentColor;
                    }

                    CheckGameWinn();
                }
            }
            CheckScroolRandoms();
        }

        void SetChange(int n, bool set)
        {
            for(int i = 0; i < randoms.Length; i++)
            {
                if(randoms[i] == tmp[n])
                {
                    Debug.Log(i);
                    fragments[i].SetActive(set);
                }
            }
        }

        void CheckScroolRandoms()
        {
            bool h = false;
            for(int i = 0; i < explorer.images[level].sum; i++)
            {
                if (!h)
                {
                    if (fragments[i].activeSelf)
                    {
                        h = true;
                    }
                }
            }

            Image scrollImage = scrollRandoms.GetComponent<Image>();
            if (h)
            {
                scrollImage.color = defoultFragmentColor;
            }
            else
            {
                scrollImage.color = grayFragmentColor;
            }
        }

        void CheckGameWinn()
        {
            bool win = true;
            for (int i = 0; i < explorer.images[level].sum; i++)
            {
                if(win)
                {
                    if(i != tmp[i])
                    {
                        win = false;
                    }
                }
            }

            if(win)
            {
                panelPuzzle.GetComponent<Image>().color = defoultFragmentColor;

                if(!showScrollBtn.activeSelf)
                {
                    HideScroll(true);
                }
                
                if (!passed)
                {
                    passed = true;
                    passedImg.SetActive(true);
                    level++;
                    lvControl.level++;
                    lvControl.SaveLevel();

                    passedImg.SetActive(true);
                }

            }
            else
            {
                panelPuzzle.GetComponent<Image>().color = grayYellowColor;
            }
        }


        public void HideScroll(bool hide)
        {
            if(hide)
            {
                canvasAnim.Play("changeView", 0, 0f);
            }
            else
            {
                canvasAnim.Play("changeViewBack", 0, 0f);
            }
        }
        
        public void ExitTolevelSelecter()
        {
            panelLevelSelect.SetActive(true);
            lvControl.Awake();
        }

    }
}