using UnityEngine;
using PhantomDragonStudio.AudioManagement;

namespace App.UI
{
    public class UpdateAudioVolumeValue : MonoBehaviour
    {
        private OptionsController _controller;

        private void Start()
        {
            _controller = GetComponent<OptionsController>();
            AdjustAudio();
        }

        public void AdjustAudio()
        {
            if (_controller == null) return;

            AudioManager.instance.MusicVolume = _controller.MusicSlider.value;
            AudioManager.instance.EffectsVolume = _controller.SFX_Slider.value;
        }
    }
}