using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopterScript : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.won = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
