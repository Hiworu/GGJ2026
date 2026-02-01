using UnityEngine;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private int _winningSceneIndex;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.Instance.LoadScene(_winningSceneIndex);
        }
    }
}
