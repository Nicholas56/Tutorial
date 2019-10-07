using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public GameObject dropDown;
    LookX playerX;
    LookY playerY;

    // Start is called before the first frame update
    void Start()
    {
        dropDown.SetActive(false);
        playerX = GameObject.FindGameObjectWithTag("Player").GetComponent<LookX>();
        playerY = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LookY>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (dropDown.activeInHierarchy == false)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                Time.timeScale = 0;
                dropDown.SetActive(true);
                UnFreeze(false);
            }
            else
            {
                Time.timeScale = 1;
                dropDown.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                UnFreeze(true);
            }
        }
    }

    public void UnFreeze(bool state)
    {
        playerX.enabled = state;
        playerY.enabled = state;
    }
}
