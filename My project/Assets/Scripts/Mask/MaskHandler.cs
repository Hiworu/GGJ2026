using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskHandler : MonoBehaviour
{
    public static MaskHandler Instance;
    [SerializeField] private string[] _maskTags;

    private string _currentMaskTag;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentMaskTag()
    {
        for (int i = 0; i < _maskTags.Length; i++)
        {
            var nextInput = SpeechInputHandler.Instance.RetrieveInputQueue();
            
            if (nextInput.Contains(_maskTags[i]))
            {
                _currentMaskTag = _maskTags[i];
                
                nextInput.Remove(_maskTags[i]);
            }
        }
    }
    
    public string GetCurrentMask()
    {
        return _currentMaskTag;
    }
}
