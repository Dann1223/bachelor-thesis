using System;
using System.Collections.Generic;
using UnityEngine;

namespace iBetaGames
{
    public class Explorer : MonoBehaviour 
    {

        [Serializable] public class ImageExplorer
        {
            public int sum;
            public Sprite[] puzzles;
        }
        public List<ImageExplorer> images = new List<ImageExplorer>();



    }
}