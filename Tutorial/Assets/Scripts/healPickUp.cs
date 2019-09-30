using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPickUp : MonoBehaviour
{
    [SerializeField] int healAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.GetComponent<Health>();
        if(health != null)
        {
            if (healAmount < 0)
            {
                if (collider.tag == "Player")
                {
                    GetComponent<MeshRenderer>().enabled = false;
                    health.Damage(healAmount);
                }
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = false;
                health.Damage(healAmount);
            }
        }
    }
}
