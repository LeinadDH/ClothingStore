using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void ChangeScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
