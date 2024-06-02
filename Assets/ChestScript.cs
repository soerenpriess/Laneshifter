using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            GameManager.Instance.gameIsRunning = false;
            GameObject.FindGameObjectWithTag("Shop").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
