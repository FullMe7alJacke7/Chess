using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;
        }
    }
}