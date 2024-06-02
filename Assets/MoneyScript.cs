using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoneyScript : MonoBehaviour
{
    public AudioSource audioSource;
    public Light2D light2D;
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
            GameManager.Instance.AddMoney();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            light2D.enabled = false;
            audioSource.Play();
            Destroy(this.gameObject, 0.7f);
        }
    }
}
