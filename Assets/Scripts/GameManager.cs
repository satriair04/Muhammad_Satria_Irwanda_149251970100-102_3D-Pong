using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Coba-coba tes singleton;
    public static GameManager Instance;

    private void CreateInstance()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Awake()
    {
        CreateInstance();
    }

    public void RestartGame()
    {
        //Tidak ada bedanya dengan memanggil langsung nama scene-nya; Sekedar tes-tes aja
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
