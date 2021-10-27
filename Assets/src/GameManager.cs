using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerControls player;

    public Image loseScreen;
    public Image winScreen;

    // Start is called before the first frame update
    public void Start()
    {
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        player.canMove = false;
        loseScreen.gameObject.SetActive(true);
    }

    public void Retry()
    {
        //Load the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinLevel()
    {
        player.canMove = false;
        winScreen.gameObject.SetActive(true);
    }
}
