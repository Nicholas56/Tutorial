using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    public GameObject dropDown;

    // Start is called before the first frame update
    void Start()
    {
        dropDown.SetActive(false);
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
            }
            else
            {
                Time.timeScale = 1;
                dropDown.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
