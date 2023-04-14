using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManger : MonoBehaviour
{
    public float jumpForce = 6f;
    private Rigidbody rb;
    public Animator playerAnim;
    public Camera cam;
    public FixedJoystick fixedJoystick;
    float horizontalInput, verticalInput;
    bool jump = false;
    [SerializeField] float VlSpeed = 2f;
    [SerializeField] float HlSpeed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMovements();
        SetMoveAnimation();
    }

        //if (Input.GetKeyDown(KeyCode.Space) && verticalInput > 0f)
        //{
        //    animator.SetTrigger("RunningJump");
        //    Jump();

        //}


        //if (Input.GetKeyDown(KeyCode.Space) && verticalInput < 0f)
        //{
        //    animator.SetTrigger("BackwardsJump");
        //    //Jump();
        //}


        //// Jump
        //if (Input.GetKeyDown(KeyCode.Space) && verticalInput == 0 && horizontalInput == 0)
        //{
        //    StartCoroutine(JumpDelay());
        //    animator.SetTrigger("isJumping");
        //    //rb.velocity += Vector3.up * jumpForce;
        //}
    

    public void PlayerJump()
    {
        if (jump == false)
        {
            jump = true;
            playerAnim.SetTrigger("Jump");
            rb.velocity = Vector2.up * jumpForce;
        }
    }


    public void playerAttack()
    {
        playerAnim.SetTrigger("attack");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jump = false;
        }
    }


    public void PlayerMovements()
    {
        horizontalInput = fixedJoystick.Horizontal;
        verticalInput = fixedJoystick.Vertical;

        if (verticalInput > 0.5f)
        {
            VlSpeed = 6f;
        }
        else if (verticalInput < 0.5f)
        {
            VlSpeed = 2f;
        }

        if (horizontalInput > 0.5f)
        {
            HlSpeed = 6f;
        }
        else if (horizontalInput < 0.5f)
        {
            HlSpeed = 2f;
        }
        if (horizontalInput < -0.5f)
        {
            HlSpeed = 6f;
        }

        // Calculate movement direction based on camera
        Vector3 cameraForward = Vector3.Scale(cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveDirection = cameraForward * verticalInput + cam.transform.right * horizontalInput;
        // Move player
        rb.velocity = new Vector3((moveDirection * HlSpeed).x, rb.velocity.y, (moveDirection * VlSpeed).z);
    }
            
    private void SetMoveAnimation()
    {
        playerAnim.SetFloat("hZInput", horizontalInput);
        playerAnim.SetFloat("vLInput", verticalInput);
    }

    //IEnumerator JumpDelay()
    //{
    //    yield return new WaitForSeconds(JumpDelayduration);

    //    Jump();

    //    //animator.SetTrigger("Explosion");
    //}
}
      
