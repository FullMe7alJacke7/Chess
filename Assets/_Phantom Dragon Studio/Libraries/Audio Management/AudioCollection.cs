namespace PhantomDragonStudio.AudioManagement
{
    using System.Collections.Generic;
    using UnityEngine;
    using Random = UnityEngine.Random;

    [CreateAssetMenu(fileName = "New Audio Collection",
        menuName = "Phantom Dragon Studio/Audio Management/Audio Collection", order = 0)]
    public class AudioCollection : ScriptableObject
    {
        [SerializeField] private List<AudioClip> clips = default;
        private int _currentTrackIndex = -1;
        private int _randomTrackIndex = -1;

        public int CurrentTrackIndex => _currentTrackIndex;

        private AudioClip currentlySelectedClip;

        public AudioClip GetRandomClip()
        {
            _randomTrackIndex = Random.Range(0, clips.Count);
            _currentTrackIndex = _randomTrackIndex;
            currentlySelectedClip = clips[_currentTrackIndex];
            return currentlySelectedClip;
        }

        public AudioClip GetNextClip()
        {
            _currentTrackIndex++;
            if (_currentTrackIndex > clips.Count)
                _currentTrackIndex = 0;
            return currentlySelectedClip = clips[_currentTrackIndex];
        }
    }
}