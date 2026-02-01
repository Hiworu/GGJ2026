using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<string> _clipTags;
    [SerializeField] private List<AudioClip> _clips;
    [SerializeField] private AudioSource _audioSource;
    
    public static SoundManager Instance;
    
    private Dictionary<string, AudioClip> _clipMap;

    private void Awake()
    {
        _clipMap = new Dictionary<string, AudioClip>();
        
        for (int i = 0; i < _clipTags.Count; i++)
        {
            _clipMap.Add(_clipTags[i], _clips[i]);
            
            Debug.Log(_clipMap[_clipTags[i]]);
        }

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
            Destroy(gameObject);
    }
    
    public void PlayCorrespondingSound(string tag)
    {
        _clipMap.TryGetValue(tag, out AudioClip clip);
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
