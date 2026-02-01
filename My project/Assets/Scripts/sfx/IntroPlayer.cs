using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPlayer : MonoBehaviour
{
    [SerializeField] private string _introClipTag;
    [SerializeField] private AudioSource _audioSource;
    
    private void Update()
    {
        if (!_audioSource.isPlaying)
        {
            SceneManager.Instance.LoadScene(1);
        }
    }
}
