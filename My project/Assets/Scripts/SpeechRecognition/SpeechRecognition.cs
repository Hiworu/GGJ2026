using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechRecognitionWorking : MonoBehaviour
{
    private KeywordRecognizer _keywordRecognizer;
    private string[] _words =
    {
        "up"
    };
    
    private void Awake()
    {
        _keywordRecognizer = new KeywordRecognizer(_words);
        _keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        
        _keywordRecognizer.Start();
    }
    
    private void Update()
    {
        Debug.Log(_keywordRecognizer.IsRunning);
        foreach (var keyword in _keywordRecognizer.Keywords)
        {
            Debug.Log(keyword);
        }
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
    }
}