using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
        GameManager.Instance.money = 0;
        GameManager.Instance.isGameOver = false;
        GameManager.Instance.gameIsRunning = true;
        GameManager.Instance.playerGeschwindigkeit = 5f;
        GameManager.Instance.goldenDollar = false;
        GameManager.Instance.hasShield = false;
    }

    public void Menue(){
        SceneManager.LoadScene(0);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
