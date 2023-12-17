/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{

    
    Animator animator;
    public Transform cam;

    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public bool hasPowerup;


    private enum PlayerState{
        free,
        attacking,
        hurt,
        dead
    };
    private PlayerState state = PlayerState.free;

    void Start(){
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Powerup")) {
    hasPowerup = true;
    Destroy(other.gameObject); } }
    
    void Update()
    {
        applyGravity();
        switch(state){
            case PlayerState.free:
                movement();
                break;
            case PlayerState.attacking:
                break;
            default:
                break;
        }

        
    }

//gravity function

    private void applyGravity()
    {
        Vector3 gravityVector = Vector3.zero;

        if(controller.isGrounded == false)
        {
            gravityVector += Physics.gravity;
        }
        controller.Move(gravityVector * Time.deltaTime);
    }

    private void movement(){


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        direction.Normalize();

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);
            //gets angle player should face
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smooths roatation
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //rotate player in the direction currently moving
            transform.rotation = Quaternion.Euler(0f, angle, 0);
            
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
        else {
            animator.SetBool("isWalking", false);
        }
        
        if(Input.GetKey("space")){
            state = PlayerState.attacking;
            animator.SetBool("isWalking", false);
            animator.SetTrigger("isAttacking");
        }
    }

    private void endAttack(){
        state = PlayerState.free;
    }
}
*/