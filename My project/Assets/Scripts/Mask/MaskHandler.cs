using System.Collections.Generic;
using UnityEngine;

public class MaskHandler : MonoBehaviour
{
    public static MaskHandler Instance;

    private List<string> _maskTags;
    private string _currentMaskTag;

    private SpeechInputHandler _speechInputHandler;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(Instance);
        
        _speechInputHandler = SpeechInputHandler.Instance;
    }

    private void SetCurrentMaskTag()
    {
        for (int i = 0; i < _maskTags.Count; i++)
        {
            var nextInput = _speechInputHandler.RetrieveNextInput();
            
            if (_maskTags.Contains(nextInput))
            {
                _currentMaskTag = nextInput;
            }
        }
        
        _currentMaskTag = tag;
    }
    
    public string GetCurrentMask()
    {
        return _currentMaskTag;
    }
}
