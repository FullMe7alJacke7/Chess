using UnityEngine;
using UnityEngine.Serialization;

namespace PhantomDragonStudio.AudioManagement
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance = null;

        private AudioSourceHandler _audioSourceHandler;
        private AudioSource[] audioSources;

        //TODO Seperate these into their own ScriptableObject collections
        [SerializeField] private AudioCollection musicCollection;

        public float MusicVolume
        {
            get => _audioSourceHandler.MusicSource.volume;
            set => _audioSourceHandler.MusicSource.volume = value;
        }
        
        public float EffectsVolume
        {
            get => _audioSourceHandler.SpecialEffectsSource.volume;
            set => _audioSourceHandler.SpecialEffectsSource.volume = value;
        }

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;

            _audioSourceHandler = new AudioSourceHandler(GetComponents<AudioSource>());
            _audioSourceHandler.AutoAssignSourcesByPriority(audioSources);
            PlayMusic(0);
        }

        public void PlayMusic(int indexToPlay)
        {
            Debug.Log("Playing this level music track: " + musicCollection);
            if (!musicCollection) return;
            _audioSourceHandler.MusicSource.clip = musicCollection.GetRandomClip();
            _audioSourceHandler.MusicSource.loop = true;
            _audioSourceHandler.MusicSource.Play();
        }

        public void PlayEffectsClip(AudioClip clipToPlay)
        {
            if (_audioSourceHandler == null) return;
            _audioSourceHandler.SpecialEffectsSource.clip = clipToPlay;
            _audioSourceHandler.SpecialEffectsSource.loop = false;
            _audioSourceHandler.SpecialEffectsSource.Play();
        }
    }
}