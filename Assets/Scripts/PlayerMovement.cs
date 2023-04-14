using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Joystick fixedJoystick;
    [SerializeField] Animator playerAnim;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] float VlSpeed = 2f;
    [SerializeField] float HlSpeed = 2f;
    [SerializeField] GameObject player;
    Vector3 direction;
    float hZInput;
    float vLInput;

    private void FixedUpdate()
    {
        MovePlayerWithJoyStick();
        SetMoveAnimation();
    }

    void MovePlayerWithJoyStick()
    {
        hZInput = fixedJoystick.Horizontal;
        vLInput = fixedJoystick.Vertical;

        if (vLInput > 0.5f)
        {
            VlSpeed = 5f;
        }
        else if (vLInput < 0.5f)
        {
            VlSpeed = 2f;
        }

        if (hZInput > 0.5f)
        {
            HlSpeed = 5f;
        }
        else if (hZInput < 0.5f)
        {
            HlSpeed = 2f;
        }
        if (hZInput < -0.5f)
        {
            HlSpeed = 5f;
        }

        direction = Vector3.right * hZInput + Vector3.forward * vLInput;
        playerRB.velocity = new Vector3((direction * HlSpeed).x, playerRB.velocity.y, (direction * VlSpeed).z);
    }

    private void SetMoveAnimation()
    {
        playerAnim.SetFloat("hZInput", hZInput);
        playerAnim.SetFloat("vLInput", vLInput);
    }
}
