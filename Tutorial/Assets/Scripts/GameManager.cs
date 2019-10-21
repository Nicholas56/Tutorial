using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Slider playerHealth;
    public TMP_Text score;
    public TMP_Text playerHealthTxt;
    public TMP_Text timeTxt;
    public TMP_Text scoreMessage;
    public TMP_Text livesTxt;

    public GameObject winPanel;
    public GameObject losePanel;

    public GameObject helicopter;

    public static int amountKilled;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        amountKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 180)
        {
            won = true;
        }
        if (won==true)
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            scoreMessage.text = "Your Score was: " + score;
        }else if (amountKilled > 30)
        {
            helicopter.GetComponent<Animation>()["CopterArrive"].wrapMode = WrapMode.ClampForever;
            helicopter.GetComponent<Animation>().Play("CopterArrive");
        }
    }
}
