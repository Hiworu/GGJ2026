using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private bool _isJumping;

    private Vector3 _startPoint;
    private Vector3 _endPoint;
    private float _arcHeight;
    private float _t;
    
    private void Update()
    {
        if (!_isJumping)
        {
            transform.position += transform.forward * (_movementSpeed * Time.deltaTime);
        }
        else
        {
            _t = Mathf.Clamp01(Time.deltaTime * _movementSpeed);

            EntityJump(_startPoint, _endPoint, _arcHeight, _t);
            
            if (transform.position == _endPoint)
            {
                _isJumping = false;
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, Mathf.Infinity))
        {
            SceneManager.Instance.LoadScene(2);
        }
    }

    public void GetJumpParameters(Vector3 startPoint, Vector3 endPoint, float arcHeight)
    {
        _startPoint = startPoint;
        _endPoint = endPoint;
        _arcHeight = arcHeight;
        _t = 0;
        
        _isJumping = true;
    }
    
    private Vector3 EntityJump(Vector3 startPoint, Vector3 endPoint, float arcHeight, float percentage)
    {
        float x = Mathf.Lerp(startPoint.x, endPoint.x, percentage);
        float z = Mathf.Lerp(startPoint.z, endPoint.z, percentage);

        float parabola = 1f - Mathf.Pow(2f * percentage - 1f, 2f);
        float y = Mathf.Lerp(startPoint.y, endPoint.y, percentage) + parabola * arcHeight;

        return new Vector3(x, y, z);
    }
}
