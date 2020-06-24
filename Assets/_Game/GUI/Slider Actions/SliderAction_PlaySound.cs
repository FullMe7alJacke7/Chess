using PhantomDragonStudio.AudioManagement;
using UnityEngine;
using UnityEngine.UI;

public class SliderAction_PlaySound : MonoBehaviour
{
    private void Awake()
    {
        SetupButton();
    }

    private void SetupButton()
    {
        Slider slider = transform.GetComponent<Slider>();
        slider.onValueChanged.AddListener(SliderMoved);
    }

    private void SliderMoved(float value)
    {
        // AudioManager.instance.PlayClickedSound();
    }
}
