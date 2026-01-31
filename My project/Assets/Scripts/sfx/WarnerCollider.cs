using UnityEngine;

public class WarnerCollider : MonoBehaviour
{
    [SerializeField] private string _audioTag;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.PlayCorrespondingSound(_audioTag);
            
            SpeechInputHandler.Instance.StartRecording();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpeechInputHandler.Instance.StopRecording();
        }
    }
}
