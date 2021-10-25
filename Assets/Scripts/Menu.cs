using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    void Exit()
    {
        if (Input.GetKeyDown("escape")) Application. Quit();
    }
}
