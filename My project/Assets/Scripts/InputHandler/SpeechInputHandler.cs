using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Whisper;
using Whisper.Utils;

public class SpeechInputHandler : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private List<string> _inputKeywords = new();
    
    public static SpeechInputHandler Instance;
    
    public WhisperManager whisper;
    public MicrophoneRecord microphoneRecord;
    
    public List<string> InputQueue = new();
    
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
        
        if (_startButton != null && _stopButton != null)
        {
            _startButton.onClick.AddListener(StartRecording);
            _stopButton.onClick.AddListener(StopRecording);
        }
        
        microphoneRecord.OnRecordStop += OnRecordStop;
    }

    private async void OnRecordStop(AudioChunk record)
    {
        var whisperRes = await whisper.GetTextAsync(record.Data, record.Frequency, record.Channels);
        var stringRes = whisperRes.Result;

        var splitString = stringRes.Split(" ");

        for (int i = 0; i < splitString.Length; i++)
        {
            Debug.Log(splitString[i]);
            
            if (_inputKeywords.Contains(splitString[i]))
            {
                AddInputToQueue(splitString[i]);
            }   
        }
    }

    private void AddInputToQueue(string keyword)
    {
        InputQueue.Add(keyword);
    }

    public string RetrieveNextInput()
    {
        if (InputQueue.Count >= 0)
        {
            var retrievedInput = InputQueue[0];
            InputQueue.RemoveAt(0);
            
            return retrievedInput;
        }
        
        return null;
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
