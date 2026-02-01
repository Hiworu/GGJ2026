using UnityEngine;

public class IntroPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    private void Awake()
    {
        StartCoroutine(StartLevel());
    }

    private IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(_audioSource.clip.length);

        SceneManager.Instance.LoadScene(1);
    }
}
