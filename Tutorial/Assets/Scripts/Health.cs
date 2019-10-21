using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maximumHealth = 100;
    [SerializeField] int scoreValue = 50;
    int currentHealth = 0;
    Animator anim;
    public Renderer renderer;

    AudioSource audioSrc;
    [SerializeField] AudioClip damageclip;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        anim = GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();

        audioSrc = GetComponent<AudioSource>();
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
        if (damageValue > 0)
        {
            audioSrc.clip = damageclip;
            audioSrc.Play();
        }

        if (currentHealth <= 0)
        {
            if (gameObject.tag != "Player")
            {
                if (anim)
                {
                    anim.SetBool("Dead", true);
                }
                UIScript.updateScore(scoreValue);
                Destroy(GetComponent<EnemyNavMovement>());
                Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
                Destroy(GetComponent<CharacterController>());
                Destroy(GetComponentInChildren<EnemyAttack>());
                Destroy(GetComponent<AIScript>());

                SpawnScript.EnemyDie();
                GameManager.amountKilled++;
                //GameManager.amountKilled++;
                //Invoke("RemoveBody", 5.0f);
            }
            Destroy(GetComponent<Health>());
        }
    }

    void RemoveBody()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead &&!renderer.isVisible)
        {
            RemoveBody();
        }
    }
}
