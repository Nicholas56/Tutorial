using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievementScript : MonoBehaviour
{
    public GameObject deathBadge;
    public GameObject surviveBadge;

    // Start is called before the first frame update
    void Start()
    {
        deathBadge.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.StartListening("zombiesKilled", revealDeathBadge);
        EventManager.StartListening("survived", revealSurviveBadge);
    }

    private void OnDisable()
    {
        EventManager.StopListening("zombiesKilled", revealDeathBadge);
        EventManager.StopListening("survived", revealSurviveBadge);
    }

    void revealDeathBadge()
    {
        deathBadge.SetActive(true);
    }

    void revealSurviveBadge()
    {
        surviveBadge.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
