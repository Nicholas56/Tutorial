using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    [SerializeField] int damageDealt = 20;
    [SerializeField] LayerMask layerMask;
    [SerializeField] GameObject bloodHit;
    [SerializeField] GameObject bloodHitAlt;
    Animator anim;
    AudioSource audioSrc;
    [SerializeField] AudioClip shootclip;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
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
            anim.SetTrigger("Fire");
            audioSrc.clip = shootclip;
            audioSrc.Play();
            audioSrc.Play();
            GetComponentInChildren<ParticleSystem>().Play();
            if(Physics.Raycast (mouseRay,out hitInfo,100,layerMask))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 0.5f);
                Health enemyHealth = hitInfo.transform.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(damageDealt);
                    Vector3 bloodHitPos = hitInfo.point;
                    Quaternion bloodHitRot = Quaternion.FromToRotation(Vector3.forward, hitInfo.normal);
                    if (hitInfo.transform.tag == "Mutant")
                    {
                        bloodHitPos -= ((hitInfo.transform.position - gameObject.transform.position).normalized)*2;
                        Instantiate(bloodHitAlt, bloodHitPos, bloodHitRot);
                    }
                    else
                    {
                        Instantiate(bloodHit, bloodHitPos, bloodHitRot);
                    }
                }
            }
        }
    }
}
