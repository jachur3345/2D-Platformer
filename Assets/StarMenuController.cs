using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenuController : MonoBehaviour
{
   public void OnStartClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
