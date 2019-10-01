using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    [SerializeField] int damageDealt = 20;
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        layerMask |= Physics.IgnoreRaycastLayer;
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&&Time.timeScale!=0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if(Physics.Raycast (mouseRay,out hitInfo,100,layerMask))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 0.5f);
                Health enemyHealth = hitInfo.transform.GetComponent<Health>();
                if(enemyHealth != null)
                {
                    enemyHealth.Damage(damageDealt);
                }
            }
        }
    }
}
