using UnityEngine;
using UnityEngine.SceneManagement;

public class KillVolume : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
