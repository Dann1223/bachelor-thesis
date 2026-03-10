using UnityEngine;
using UnityEngine.UI;

namespace iBetaGames {
    public class fragment : MonoBehaviour
    {
        public Image me;

        public Explorer explorer;

        public GameController controller;

        public int level;

        public int myNumber;

        public void Start()
        {
            me = gameObject.GetComponent<Image>();
        }

        public void SelectMe()
        {
            controller.SelectFragment(myNumber, me);
        }
    }
}