using UnityEngine;

namespace App
{
    public class GameStateManager : MonoBehaviour {

        public static GameStateManager instance = null;

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;
        }
    }

}