using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            if(GameManager.Instance.hasShield){
                GameObject.FindGameObjectWithTag("ForceField").transform.GetChild(0).gameObject.SetActive(false);
                gameObject.GetComponent<Collider2D>().enabled = false;
                GameManager.Instance.hasShield = false;
                return;
            }
            GameManager.Instance.gameIsRunning = false;
            GameManager.Instance.GameOver();
        }
    }
}
