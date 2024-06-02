 using System.Collections;
using UnityEngine;

public class SpielerDemo : MonoBehaviour
{
    public int aktuelleBahn = 1; // Die aktuelle Bahn des Spielers (0 = unterste Bahn, 1 = mittlere Bahn, 2 = oberste Bahn)
    private Rigidbody2D rb;

    private Animator anim;
    public bool _playerOnPlatform;

    public bool canJump = true;

    public float sprungkraft = 10.0f;

    public bool takeNextCollision = false;

    public bool jumpCd = false; 

    public AudioSource audioSource;

    private void Start()
    {
        // _collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    bool coroutineRunning = false;
    private void Update()
    {
        //if(!GameManager.Instance.gameIsRunning) return;

        // Bewege den Spieler automatisch nach rechts
        Vector2 bewegung = new Vector2(5, rb.velocity.y);
        rb.velocity = bewegung;

        if(!coroutineRunning) StartCoroutine(GeneriereZufallsWerte());

        // Erfasse die Scroll-Richtung
        // float scrollDelta = Input.mouseScrollDelta.y;

        // if (scrollDelta > 0 && _playerOnPlatform && canJump && !jumpCd)
        // {
        //     SpringeHoch();
        //     audioSource.Play();
        // }
        // else if (scrollDelta < 0 && _playerOnPlatform)
        // {
        //     SpringeRunter();
        //     audioSource.Play();
        // }
    }

    private IEnumerator GeneriereZufallsWerte()
    {
        while (true)
        {
            // Warte 3 Sekunden
            coroutineRunning = true;
            yield return new WaitForSeconds(3f);

            // Generiere einen zufälligen Wert zwischen 0 und 3
            float zufallsWert = Random.Range(0, 3);
            Debug.Log(zufallsWert);
            if (zufallsWert == 2)
            {
                SpringeHoch();
                audioSource.Play();

            }
            else if (zufallsWert == 0)
            {
                SpringeRunter();
                audioSource.Play();
            }
            coroutineRunning = false;
        }
    }

    private void SpringeHoch()
    {
        rb.AddForce(Vector2.up * sprungkraft, ForceMode2D.Impulse);
        anim.SetBool("jumping", true);
        jumpCd = true;
        canJump = false;
        takeNextCollision = true;
        StartCoroutine("JumpCooldown");
        //aktuelleBahn--;
    }

    IEnumerator JumpCooldown(){
        yield return new WaitForSeconds(1f);
        jumpCd = false;
    }

    private void SpringeRunter()
    {
        // Finde alle GameObjects mit dem Tag "Bahn1"
        GameObject[] bahn1Objekte = GameObject.FindGameObjectsWithTag("Bahn" + aktuelleBahn);
        //aktuelleBahn++;
        // Deaktiviere die Collider2D-Komponenten auf diesen GameObjects
        foreach (GameObject obj in bahn1Objekte)
        {
            if(obj != null){
                Collider2D collider = obj.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }
        }
        anim.SetBool("jumping", true);
       // _collider.enabled = false;
        StartCoroutine(EnableCollider());
    }

    private IEnumerator EnableCollider(){
        yield return new WaitForSeconds(0.5f);
        // _collider.enabled = true;
        // _collider = null;
         // Finde alle GameObjects mit dem Tag "Bahn1"
        GameObject[] bahn1Objekte = GameObject.FindGameObjectsWithTag("Bahn" + aktuelleBahn);

        // Deaktiviere die Collider2D-Komponenten auf diesen GameObjects
        foreach (GameObject obj in bahn1Objekte)
        {
            if(obj != null){
                Collider2D collider = obj.GetComponent<Collider2D>();
                if (collider != null)
                {
                    collider.enabled = true;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        _playerOnPlatform = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // if(takeNextCollision){
        //     takeNextCollision = false;
        //     return;
        // }
        anim.SetBool("jumping", false);
        canJump = true;
        switch (other.gameObject.tag)
        {
        case "Bahn1":
            aktuelleBahn = 1;
            break;
        case "Bahn2":
            aktuelleBahn = 2;
            break;
        case "Bahn3":
            aktuelleBahn = 3;
            break;
        default:
            print ("Incorrect intelligence level.");
            break;
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        string otherTag = other.gameObject.tag;
        _playerOnPlatform = true;
        switch (otherTag)
        {
        case "Bahn1":
            aktuelleBahn = 1;
            break;
        case "Bahn2":
            aktuelleBahn = 2;
            break;
        case "Bahn3":
            aktuelleBahn = 3;
            break;
        default:
            print ("Incorrect intelligence level.");
            break;
        }
        //if(_collider != null) return;
        //_collider = other.gameObject.GetComponent<Collider2D>();
    }
}
