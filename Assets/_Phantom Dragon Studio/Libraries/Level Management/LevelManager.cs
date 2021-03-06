﻿using System;

namespace PhantomDragonStudio.LevelManagement
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Canvas splashCanvas = default; 
        [SerializeField] private float splashScreenDelay = default;
        [SerializeField] private int mainMenuIndex = default;
        [SerializeField] private bool autoLoad;
        
        
        public static LevelManager instance = null;
        private SceneLoad _sceneLoad;
        private SceneUnload _sceneUnload;
        private int lastSceneVisited;

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;

            _sceneLoad = new SceneLoad();
            _sceneUnload = new SceneUnload();
            
            if(autoLoad)
                StartCoroutine(DelayedAutoLoad(mainMenuIndex, splashScreenDelay));
        }
        
        private IEnumerator DelayedAutoLoad(int nextLevelIndex, float timeDelay)
        {
            yield return new WaitForSeconds(timeDelay);
            LoadLevel(nextLevelIndex);
            splashCanvas.enabled = false;
        }
    
        public void LoadLevel(int requestedSceneIndex)
        {
            lastSceneVisited = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(_sceneLoad.Load(requestedSceneIndex));           
            StartCoroutine(_sceneUnload.Unload(lastSceneVisited));
        }

        public void LoadPreviousScene()
        {
            LoadLevel(lastSceneVisited);
        }
    }
}