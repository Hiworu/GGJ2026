using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    
    private void Update()
    {
        transform.position += transform.forward * (_movementSpeed * Time.deltaTime);
    }
}
