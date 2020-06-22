using PhantomDragonStudio.AudioManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction_PlaySound : MonoBehaviour
{
    private void Awake()
    {
        SetupButton();
    }

    private void SetupButton()
    {
        Button button = transform.GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        AudioManager.instance.PlayClickedSound();
    }
}
