using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Erstelle eine statische Instanz des Game Managers, um auf sie von überall im Spiel zugreifen zu können.
    public static GameManager Instance { get; private set; }

    // Hier kannst du globale Spielvariablen und -zustände speichern.
    public int money = 0;
    public int leben = 3;
    public bool isGameOver = false;
    public bool gameIsRunning = false;
    public float playerGeschwindigkeit = 5f; 
    public float distance = 0f;
    public Vector3 startposition;
    public Transform player;

    public bool goldenDollar = false;
    public bool hasShield = false;

    private void Awake()
    {
        // Stelle sicher, dass es nur eine Instanz des Game Managers gibt.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Damit der GameManager beim Szenenwechsel nicht zerstört wird.
        }
        else
        {
            Destroy(gameObject);
        }

        gameIsRunning = true;
        //player = GameObject.FindWithTag("Player").gameObject.transform;
    }

    private void Update() {
        if(player == null) player = GameObject.FindWithTag("Player").gameObject.transform;
        distance = player.position.x - startposition.x;
        playerGeschwindigkeit += 0.08f * Time.deltaTime;
    }
    
    public void DecreaseLeben(){
        leben --;
        if(leben == 0) GameOver();
    }

    public void GameOver()
    {
        player.gameObject.GetComponent<Animator>().SetTrigger("dead");
        // GameObject.FindGameObjectWithTag("FinalMoney").transform.GetChild(0).gameObject.SetActive(true);
        // GameObject.FindGameObjectWithTag("FinalDistanc").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindGameObjectWithTag("GameOver").transform.GetChild(0).gameObject.SetActive(true);
        isGameOver = true;
        // Hier kannst du den Spielende-Code hinzufügen, wie das Anzeigen eines Game-Over-Bildschirms oder Neustarts.
    }

    public void AddMoney(){
        if(goldenDollar) money += 2;
        else money++;
    }
}