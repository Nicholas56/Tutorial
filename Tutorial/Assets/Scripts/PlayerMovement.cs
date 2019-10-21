using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController charController;

    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;

    [SerializeField] float moveSpeed = 5.0f;
    public int playerNum;

    public float h;
    public float v;
    Animator anim;
    AudioSource audioSrc;
    [SerializeField] AudioClip leftStep;
    [SerializeField] AudioClip rightStep;
    bool isWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();
        InvokeRepeating("Footsteps", 0.0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("JoystickX" );
        //float X = Input.GetAxis("JoystickX" + playerNum);
        Vector3 rot = transform.localEulerAngles;
        rot.y += X * 5;
        transform.localEulerAngles = rot;

        h = Input.GetAxis("Horizontal" );
        //h = Input.GetAxis("Horizontal" + playerNum);
        v = Input.GetAxis("Vertical");
        //v = Input.GetAxis("Vertical" + playerNum);
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        if (charController.isGrounded)
        {
            anim.SetBool("Grounded", true);
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("Jump");
                yVelocity = jumpSpeed;
            }
        }
        else
        {
            anim.SetBool("Grounded", false);
            yVelocity -= gravity;
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        charController.Move(velocity * Time.deltaTime);
        if (v>0.1f) { isWalk=true; } else { isWalk = false; }
    }

    void Footsteps()
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                audioSrc.clip = leftStep;
                break;
            case 1:
                audioSrc.clip = rightStep;
                break;
            default:
                audioSrc.clip = null;
                break;
        }
        
        if (isWalk && charController.isGrounded)
        {
            audioSrc.Play();
        }

    }
}
