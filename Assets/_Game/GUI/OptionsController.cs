using PhantomDragonStudio.AudioManagement;
using UnityEngine;
using UnityEngine.UI;

namespace App.UI
{
    public class OptionsController : MonoBehaviour
    {
        [SerializeField] private Slider musicSlider = default;
        [SerializeField] private Slider sfxSlider = default;

        public Slider MusicSlider => musicSlider;
        public Slider SFX_Slider => sfxSlider;

        private void Awake()
        {
            ResetSliderToValue();
        }

        void ResetSliderToValue()
        {
            musicSlider.value = PlayerPrefsManager.GetMusicVolume();
            sfxSlider.value = PlayerPrefsManager.GetEffectsVolume();
        }

        public void ResetToDefaults()
        {
            PlayerPrefsManager.SetMusicVolume(100);
            PlayerPrefsManager.SetEffectsVolume(100);
            ResetSliderToValue();
        }

        public void SaveToPreferences()
        {
            PlayerPrefsManager.SetMusicVolume(musicSlider.value);
            PlayerPrefsManager.SetEffectsVolume(sfxSlider.value);
        }
    }
}