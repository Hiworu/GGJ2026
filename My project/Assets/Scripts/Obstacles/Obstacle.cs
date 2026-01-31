using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Obstacle_Data _data;
    private Int16 _section;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckMaskTag();
        }
    }

    private void CheckMaskTag()
    {
        var currentMaskTag = MaskHandler.Instance.GetCurrentMask();

        if (currentMaskTag == _data.ObstacleTag)
        {
            Debug.Log("Obstacle passed");
        }
        else
        {
            Debug.Log("Obstacle failed");
        }
    }
}
