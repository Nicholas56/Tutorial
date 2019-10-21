using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievementScript : MonoBehaviour
{
    public GameObject deathBadge;
    public GameObject survuveBadge;

    // Start is called before the first frame update
    void Start()
    {
        deathBadge.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.StartListening("zombiesKilled", revealDeathBadge);
    }

    private void OnDisable()
    {
        EventManager.StopListening("zombieKilled", revealDeathBadge);
    }

    void revealDeathBadge()
    {
        deathBadge.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
