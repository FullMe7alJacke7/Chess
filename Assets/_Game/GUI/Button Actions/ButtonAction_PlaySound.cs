using PhantomDragonStudio.AudioManagement;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonAction_PlaySound : MonoBehaviour
{
    [SerializeField] private AudioCollection audioClipCollection;
    private AudioSourceHandler _audioSourceHandler;

    private void Awake()
    {
        SetupButton();
    }

    private void SetupButton()
    {
        Button button = transform.GetComponent<Button>();
        button.onClick.AddListener(PlayClickedSound);
        _audioSourceHandler = new AudioSourceHandler(GetComponents<AudioSource>());
    }

    private void PlayClickedSound()
    {
        Debug.Log("Playing this level music track: " + audioClipCollection);
        if (!audioClipCollection) return;
        _audioSourceHandler.MusicSource.clip = audioClipCollection.GetRandomClip();
        _audioSourceHandler.MusicSource.loop = true;
        _audioSourceHandler.MusicSource.Play();
    }
}
