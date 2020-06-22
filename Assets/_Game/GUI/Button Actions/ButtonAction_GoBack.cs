using PhantomDragonStudio.LevelManagement;
using UnityEngine.UI;

namespace App.UI
{
    using UnityEngine;

    public class ButtonAction_GoBack : MonoBehaviour
    {
        private LevelManager levelManager;

        void Awake()
        {
            levelManager = LevelManager.instance;
            SetupButton();
        }

        private void SetupButton()
        {
            Button button = transform.GetComponent<Button>();
            button.onClick.AddListener( ButtonClicked);
        }

        private void ButtonClicked()
        {
            levelManager.LoadPreviousScene();
        }
    }
}