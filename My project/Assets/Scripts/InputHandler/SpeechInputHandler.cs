using UnityEngine;
using UnityEngine.UI;
using Whisper;
using Whisper.Utils;

public class SpeechInputHandler : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _stopButton;
    
    public static SpeechInputHandler Instance;
    
    public WhisperManager whisper;
    public MicrophoneRecord microphoneRecord;
    
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
        
        _startButton.onClick.AddListener(StartRecording);
        _stopButton.onClick.AddListener(StopRecording);
        
        microphoneRecord.OnRecordStop += OnRecordStop;
    }

    private async void OnRecordStop(AudioChunk record)
    {
        var res = await whisper.GetTextAsync(record.Data, record.Frequency, record.Channels);
        
        var text = res.Result;
        
        Debug.Log(text);
    }

    public void StartRecording()
    {
        microphoneRecord.StartRecord();
    }

    public void StopRecording()
    {
        microphoneRecord.StopRecord();
    }
}
