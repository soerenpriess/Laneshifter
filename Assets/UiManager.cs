using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    GameManager gameManager = null;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI distanceText;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = GameManager.Instance.money.ToString();
        distanceText.text = Mathf.RoundToInt(GameManager.Instance.distance) + " m";
    }
}
