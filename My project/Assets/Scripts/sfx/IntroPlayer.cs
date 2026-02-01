using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPlayer : MonoBehaviour
{
    [SerializeField] private string _introClipTag;

    private void Start()
    {
        SoundManager.Instance.PlayCorrespondingSound(_introClipTag);
    }

    private void Update()
    {
        if (!SoundManager.Instance.GetAudioSource().isPlaying)
        {
            SceneManager.Instance.LoadScene(1);
        }
    }
}
