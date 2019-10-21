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
    public TMP_Text scoreMessage;
    static int score;

    public GameObject losePanel;
    public GameObject winPanel;
    public ControlScript control;

    AudioSource audioSrc;
    [SerializeField] AudioClip loseClip;
    musicController music;

    // Start is called before the first frame update
    void Start()
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum = manager.score;
        timeNum = manager.timeTxt;
        scoreMessage = manager.scoreMessage;
        winPanel = manager.winPanel;
        losePanel = manager.losePanel;

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health:" + healthScript.getHealth();
        
        losePanel.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
        music = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<musicController>();

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

            music.StopSound();
            audioSrc.clip = loseClip;
            audioSrc.Play();
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            control.UnFreeze(false);
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
