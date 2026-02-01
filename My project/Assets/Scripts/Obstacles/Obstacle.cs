using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Obstacle_Data _data;
    [SerializeField] private float _vaultingSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var arcHeight = gameObject.transform.position.y + 2;
            var startPoint = other.transform.position;
            var endPoint = transform.position + (other.transform.forward * 3);
            
            var currentMaskTag = MaskHandler.Instance.GetCurrentMask();

            if (currentMaskTag == _data.ObstacleTag)
            {
                var playerMovement = other.gameObject.GetComponent<PlayerMovement>();
                playerMovement.GetJumpParameters(startPoint, endPoint, arcHeight);
            }
            else
            {
                SceneManager.Instance.LoadScene(2);
            }
        }
    }
}
