using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public bool isTop;
    public bool isBottom;

    public float bottomYCoordinate;
    public float topYCoordinate;

    public bool isDemo = false;
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
            if(isTop){
                Vector3 playerPosition = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(playerPosition.x, bottomYCoordinate, playerPosition.z);
                //other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(GameManager.Instance.playerGeschwindigkeit, other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 6, ForceMode2D.Impulse);
            }

            if(isBottom){
                Vector3 playerPosition = other.gameObject.transform.position;
                if(isDemo) other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
                else other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(GameManager.Instance.playerGeschwindigkeit, 0f);
                other.gameObject.transform.position = new Vector3(playerPosition.x, topYCoordinate, playerPosition.z);
            }
        }
    }
}
