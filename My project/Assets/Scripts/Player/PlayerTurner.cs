using UnityEngine;

public class PlayerTurner : MonoBehaviour
{
    [SerializeField] private string _turnDirection;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var retrievedInput = SpeechInputHandler.Instance.RetrieveInputQueue()[0];

            if (retrievedInput == _turnDirection)
            {
                if (_turnDirection == "left")
                {
                    other.transform.parent.rotation = Quaternion.LookRotation(Vector3.left);
                }
                else if (_turnDirection == "right")
                {
                    other.transform.parent.rotation = Quaternion.LookRotation(Vector3.right);
                }
            }
        }
    }
}
