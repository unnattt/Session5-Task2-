using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementStateManger : MonoBehaviour
{
    public float moveSpeed = 5f;
    [HideInInspector] public Vector3 dir;
    [SerializeField] Animator playerAnim;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float gravity = -9.81f;
    Vector3 velocity;
    Vector3 Pos;
    float hzInput, vlInput;
    [SerializeField] float GroundOffSets;
    CharacterController controller;

    float hZInput;
    float vLInput;
    //[SerializeField] float VlSpeed = 2f;
    //[SerializeField] float HlSpeed = 2f;
    [SerializeField] Joystick fixedJoystick;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //GetDireactionAndMove();
        
        PlayerMovement();
        SetMoveAnimation();
        Gravity();
    }

    void GetDireactionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vlInput = Input.GetAxis("Vertical");
        

        dir = transform.forward * vlInput + transform.right * hzInput;

        controller.Move(dir * moveSpeed * Time.deltaTime);
    }
    private void SetMoveAnimation()
    {
        playerAnim.SetFloat("hZInput", hZInput);
        playerAnim.SetFloat("vLInput", vLInput);
    }

    bool IsGrounded()
    {
        Pos = new Vector3(transform.position.x, transform.position.y - GroundOffSets, transform.position.z);
        if(Physics.CheckSphere(Pos,controller.radius - 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Gravity()
    {
        if(!IsGrounded())
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y<0)
        {
            velocity.y = -2;
        }
        controller.Move(velocity * Time.deltaTime);
    }

    public void PlayerMovement()
    {
        hZInput = fixedJoystick.Horizontal;
        vLInput = fixedJoystick.Vertical;

            dir = transform.forward * vLInput + transform.right * hZInput;
            controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
    }
       
}
