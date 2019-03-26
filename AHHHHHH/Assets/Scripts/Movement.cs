using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {
    [Header("Player Speed")]
    public float moveSpeed = 5;
    public float crouchSpeed = 2.5f, walkSpeed  = 5, runSpeed = 10, jumpSpeed = 8;

    private float gravity = 20;
    private Vector3 moveDir;
    private CharacterController charController;
	// Use this for initialization
	void Start () {
        charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (charController.isGrounded)
        {
            if (Input.GetButton("Sprint"))
            {
                moveSpeed = runSpeed;
            }
            else if (Input.GetButton("Crouch"))
            {
                moveSpeed = crouchSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }
            moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * Time.timeScale);
            if (Input.GetButton("Jump"))
            {
                moveDir.y = jumpSpeed;
            }

        }
        moveDir.y -= gravity*Time.deltaTime;
        charController.Move(moveDir * Time.deltaTime);
	}
}
