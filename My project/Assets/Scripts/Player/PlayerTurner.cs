using UnityEngine;

public class PlayerTurner : MonoBehaviour
{
    [SerializeField] private string _turnDirection;

    private enum _myTags
    {
        LEFT = -90,
        RIGHT = 90
    };
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var retrievedInput = SpeechInputHandler.Instance.RetrieveInputQueue()[0];

            if (retrievedInput == _turnDirection)
            {
                if (_turnDirection == "left")
                {
                    other.transform.rotation = Quaternion.Euler(0, transform.rotation.y + (float)_myTags.LEFT, 0);
                }
                else if (_turnDirection == "right")
                {
                    other.transform.rotation = Quaternion.Euler(0, transform.rotation.y + (float)_myTags.RIGHT, 0);
                }
            }
        }
    }
}
