using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    float nextTimeAttackIsAllowed = -1.0f;
    float nextTimeShotIsAllowed = -1.0f;

    [SerializeField] float attackDelay = 1.0f;

    [SerializeField] int damageDealt = 5;

    Transform playerModel;
    [SerializeField] LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerModel = playerGameObject.transform;

        layerMask |= Physics.IgnoreRaycastLayer;
        layerMask = ~layerMask;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Time.time >= nextTimeAttackIsAllowed)
        {
            Health playerHealth = other.GetComponent<Health>();
            playerHealth.Damage(damageDealt);
            nextTimeAttackIsAllowed = Time.time + attackDelay;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerModel != null)
        {
            if (Time.time >= nextTimeShotIsAllowed)
            {
                float accuracy = Random.Range(-4, 4);
                Vector3 aimDirection = transform.forward + new Vector3(accuracy, 0, 0);

                Ray mouseRay = new Ray(transform.position, aimDirection);
                RaycastHit hitInfo;

                if (Physics.Raycast(mouseRay, out hitInfo, 5, layerMask))
                {
                    Debug.DrawLine(transform.position, hitInfo.point, Color.red, 0.5f);
                    Health enemyHealth = hitInfo.transform.GetComponent<Health>();
                    if (enemyHealth != null&&hitInfo.transform.tag=="Player")
                    {
                        enemyHealth.Damage(damageDealt);
                    }
                }

                nextTimeShotIsAllowed = Time.time + attackDelay;
            }
        }
    }
}
