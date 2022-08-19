using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Oyundan çýkýþ yapýldý");
        Application.Quit();
    }
}
