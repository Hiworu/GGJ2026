using System;
using System.Collections;
using UnityEngine;

public class IntroPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _startScene;
    
    private void Awake()
    {
        StartCoroutine(StartLevel());
    }

    private void Update()
    {
        if (_startScene)
        {
            SceneManager.Instance.LoadScene(1);
        }
    }

    private IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(44);

        _startScene = true;
    }
}
