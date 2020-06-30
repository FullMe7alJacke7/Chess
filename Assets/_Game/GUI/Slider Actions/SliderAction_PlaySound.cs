using PhantomDragonStudio.AudioManagement;
using UnityEngine;
using UnityEngine.UI;

public class SliderAction_PlaySound : MonoBehaviour
{
    [SerializeField] private AudioCollection audioClipCollection;
    private AudioSourceHandler _audioSourceHandler;

    private void Awake()
    {
        SetupButton();
    }

    private void SetupButton()
    {
        Slider slider = transform.GetComponent<Slider>();
        slider.onValueChanged.AddListener(PlaySound);
        _audioSourceHandler = new AudioSourceHandler(GetComponents<AudioSource>());
    }

    private void PlaySound(float val)
    {
        if (!audioClipCollection) return;
        _audioSourceHandler.SpecialEffectsSource.clip = audioClipCollection.GetRandomClip();
        _audioSourceHandler.SpecialEffectsSource.loop = false;
        _audioSourceHandler.SpecialEffectsSource.Play();
    }
}
