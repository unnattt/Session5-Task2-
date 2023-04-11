using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Joystick fixedJoystick;
    [SerializeField] Animator playerAnim;
    [SerializeField] Rigidbody playerRB;
    //[SerializeField] GameObject player;


    Vector3 direction;
    float hZInput;
    float vLInput;
    float MovementSpeed = 5f;

    void MovePlayerWithJoyStick()
    {
        hZInput = fixedJoystick.Horizontal;
        vLInput = fixedJoystick.Vertical;

        direction = Vector3.right * hZInput +Vector3.forward* vLInput;
        // player.transform.Translate(direction.normalized * Time.deltaTime * MovementSpeed);

        playerRB.velocity = new Vector3((direction * MovementSpeed).x, playerRB.velocity.y, (direction * MovementSpeed).z);
    }

    private void FixedUpdate()
    {
        MovePlayerWithJoyStick();
        SetMoveAnimation();
    }
    private void SetMoveAnimation()
    {
        playerAnim.SetFloat("hZInput", hZInput);
        playerAnim.SetFloat("vLInput", vLInput);
    }
}
