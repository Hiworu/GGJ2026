using UnityEngine;
using UnityEngine.UI;

public class MaskHandler : MonoBehaviour
{
    public static MaskHandler Instance;
    [SerializeField] private string[] _maskTags;
    [SerializeField] private Image[] _maskImage;
    [SerializeField] private GameObject[] _masks;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

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
        var nextInput = SpeechInputHandler.Instance.RetrieveInputQueue();

        if (nextInput.Count != 0)
        {
            for (int i = 0; i < _maskTags.Length; i++)
            {
                if (nextInput[0] == _maskTags[i])
                {
                    _currentMaskTag = _maskTags[i];
                
                    SpeechInputHandler.Instance.RetrieveInputQueue().RemoveAt(0);

                    for (int c = 0; c < _masks.Length; c++)
                    {
                        if (_maskImage[c].name == _maskTags[i])
                        {
                            _maskImage[c].color = _activeColor;
                            _masks[c].SetActive(true);
                        }
                        else
                        {
                            _maskImage[c].color = _inactiveColor;
                            _masks[c].SetActive(false);
                        }
                    }
                }
            }
        }
    }
    
    public string GetCurrentMask()
    {
        return _currentMaskTag;
    }
}
