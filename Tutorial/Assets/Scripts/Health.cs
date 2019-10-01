using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maximumHealth = 100;
    [SerializeField] int scoreValue = 50;
    int currentHealth = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                UIScript.updateScore(scoreValue);
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
