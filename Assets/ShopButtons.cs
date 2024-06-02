using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyShield(){
        if(GameManager.Instance.money < 800) return;
        GameManager.Instance.money -= 800;
        GameManager.Instance.hasShield = true;
        GameObject.FindGameObjectWithTag("ForceField").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Instance.gameIsRunning = true;
    }

    public void BuySlowDown(){
        if(GameManager.Instance.money < 1500) return;
        GameManager.Instance.money -= 1500;
        GameManager.Instance.playerGeschwindigkeit = GameManager.Instance.playerGeschwindigkeit - (GameManager.Instance.playerGeschwindigkeit/100 * 20);
        GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Instance.gameIsRunning = true;
    }

    public void BuyGoldenDollar(){
        if(GameManager.Instance.money < 3000) return;
        GameManager.Instance.money -= 3000;
        GameManager.Instance.goldenDollar = true;
        GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Instance.gameIsRunning = true;
    }

    public void Exit(){
        GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject.SetActive(false);
        GameManager.Instance.gameIsRunning = true;
    }
}
