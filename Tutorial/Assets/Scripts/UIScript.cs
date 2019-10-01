using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public Health healthScript;
    public TMP_Text healthTxt;
    public Slider healthBar;

    public TMP_Text scoreNum;
    public TMP_Text timeNum;
    static int score;

    public GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum = manager.score;
        timeNum = manager.timeTxt;

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health:" + healthScript.getHealth();

        losePanel.SetActive(false);

        StartCoroutine("updateUI");
    }

    IEnumerator updateUI()
    {
        yield return new WaitForSeconds(0.5f);
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health:" + healthScript.getHealth();

        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";

        if (healthScript.IsDead&&(int)Time.time>1)
        {
            losePanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        StartCoroutine("updateUI");
    }

    public static void updateScore(int amount)
    {
        score += amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
