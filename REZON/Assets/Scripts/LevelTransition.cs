using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private Animator _animatior;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        Time.timeScale = 1;
        _animatior.SetTrigger("Transition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
