using PhantomDragonStudio.LevelManagement;
using UnityEngine.UI;

namespace App.UI
{
    using UnityEngine;

    public class ButtonAction_LoadLevel : MonoBehaviour
    {
        [SerializeField] private int sceneIndexToLoad = default;
        private LevelManager levelManager;
        
        void Awake()
        {
            levelManager = LevelManager.instance;
            SetupButton();
        }
        
        private void SetupButton () {
            Button button = transform.GetComponent<Button>();
            button.onClick.AddListener(ButtonClicked);
        }
 
        private void ButtonClicked () {
            levelManager.LoadLevel(sceneIndexToLoad);
        }
    }
}