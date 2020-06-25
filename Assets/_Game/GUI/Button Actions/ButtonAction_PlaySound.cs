namespace App.UI
{
    using PhantomDragonStudio.AudioManagement;
    using UnityEngine;
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
            Debug.Log("Setup....");
            Button button = transform.GetComponent<Button>();
            button.onClick.AddListener(PlayClickedSound);
            _audioSourceHandler = new AudioSourceHandler(GetComponents<AudioSource>());
        }

        private void PlayClickedSound()
        {
            if (audioClipCollection == null)
            {
                Debug.Log("NULL HANDLER");
                return;
            }
            Debug.Log(_audioSourceHandler.ToString());
            _audioSourceHandler.SpecialEffectsSource.clip = audioClipCollection.GetRandomClip();
            _audioSourceHandler.SpecialEffectsSource.loop = false;
            _audioSourceHandler.SpecialEffectsSource.Play();
        }
    }

}