using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DogController : MonoBehaviour
{
    CharacterController cc;
    public float speed;
    public float jumpHeight;
    bool canMove;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    Animator[] animators;
    float horizontal, vertical;
    public Scent scent;
    public GameObject button;
    public AudioClip bark, death, powerup;
    public AudioSource source;
    bool active;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        animators = GetComponentsInChildren<Animator>();
        canMove = true;
        source = GetComponent<AudioSource>();
        active = true;
    }

    private void Update()
    {
        // Character Movement


        if (active) CheckRay();
        if(!active) button.SetActive(true);

        vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
            
            Vector3 direction = new Vector3(horizontal, 0, vertical);

            if (direction.magnitude >= 0.1f && canMove)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0);
                Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            cc.Move(moveDir.normalized * speed * Time.deltaTime);
            }
        cc.Move(new Vector3(0, Physics.gravity.y, 0));

        UpdateAnimations();
        


        if (Input.GetButtonDown("Sniff"))
        {
            foreach (Animator a in animators)
            {
                a.SetTrigger("SniffTrigger");
                direction.x = 0;
                direction.z = 0;
                canMove = false;
                Invoke("SetCanMove", 1.0f);
                scent.PlayParticles();
                
            }
        }
    }


    

    void UpdateAnimations()
    {
        // Set walking animation if the dog is moving along the x or z axis. Revert back to idle if not.
       
        if(horizontal != 0 || vertical != 0)
        {
            foreach(Animator a in animators)
            {
                a.SetBool("Walking", true);
            }
        }

        if(horizontal == 0 && vertical == 0)
        {
            foreach (Animator a in animators)
            {
                a.SetBool("Walking", false);
            }
        }

        foreach (Animator a in animators)
        {
            a.SetBool("Grounded", cc.isGrounded);
        }

    }

    public void SetCanMove()
    {
        canMove = true;
    }

    public void Death()
    {
        foreach(Animator a in animators)
        {
            a.SetTrigger("DeathTrigger");
        }
        source.clip = death;
        source.Play();
        canMove = false;
    }

   void CheckRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3.0f))
        {
            if(hit.collider.gameObject.tag == "Goal")
            {
                foreach(Animator a in animators)
                {
                    a.SetTrigger("Win");
                }
                source.clip = bark;
                source.Play();
                canMove = false;
                FindObjectOfType<Timer>().ticking = false;
                active = false;


            }
        }
    }

  
}
