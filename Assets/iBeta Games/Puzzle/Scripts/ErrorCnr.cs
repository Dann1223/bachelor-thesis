using UnityEngine;
namespace iBetaGames
{
    public class ErrorCnr : MonoBehaviour
    {
        public float timer = 2f;
        void Start()
        {
            Invoke("Destroy", timer);
        }

        void Destroy()
        {
            Destroy(gameObject);
        }
    }
}