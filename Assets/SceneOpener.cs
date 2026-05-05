using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen_Opener : MonoBehaviour
{
    public string sceneName;
    public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
