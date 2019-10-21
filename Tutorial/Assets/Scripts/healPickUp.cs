using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPickUp : MonoBehaviour
{
    [SerializeField] int healAmount;
    bool canHeal = true;
    AudioSource audioSrc;
    [SerializeField] AudioClip healSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Visible()
    {
        GetComponent<MeshRenderer>().enabled = true;
        canHeal = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.GetComponent<Health>();
        if(health != null&&canHeal)
        {
            if (healAmount > 0)
            {
                if (collider.tag == "Player")
                {
                    GetComponent<MeshRenderer>().enabled = false;
                    canHeal = false;
                    health.Damage(healAmount);
                    Invoke("Visible", 5.0f);
                }
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = false;
                canHeal = false;
                health.Damage(healAmount);
                audioSrc.clip = healSound;
                audioSrc.Play();
                Invoke("Visible", 5.0f);
            }
        }
    }
}
