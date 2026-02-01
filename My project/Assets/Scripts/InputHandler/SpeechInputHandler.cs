using System;
using System.Collections.Generic;
using UnityEngine;
using Whisper;
using Whisper.Utils;

public class SpeechInputHandler : MonoBehaviour
{
    [SerializeField] private string[] _inputKeywords;

    private char[] _separators =
    {
        ' ',
        '.',
        ',',
        '!',
        '?',
        ';',
        ':',
        '<',
        '>'
    };
    
    public static SpeechInputHandler Instance;
    
    public WhisperManager whisper;
    public MicrophoneRecord microphoneRecord;
    
    public List<string> InputQueue = new();
    
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
        
        microphoneRecord.OnRecordStop += OnRecordStop;
    }

    private async void OnRecordStop(AudioChunk record)
    {
        var whisperRes = await whisper.GetTextAsync(record.Data, record.Frequency, record.Channels);
        var stringRes = whisperRes.Result;

        var splitString = stringRes.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < _inputKeywords.Length; i++)
        {
            for (int c = 0; c < splitString.Length; c++)
            {
                if (string.Equals(_inputKeywords[i], splitString[c], StringComparison.CurrentCultureIgnoreCase))
                {
                    AddInputToQueue(splitString[c]);
                }   
            }
        }
        
        MaskHandler.Instance.SetCurrentMaskTag();
    }

    private void AddInputToQueue(string keyword)
    {
        InputQueue.Add(keyword.ToLower());
    }

    public List<string> RetrieveInputQueue()
    {
        if (InputQueue.Count >= 0)
        {
            return InputQueue;
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
