using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float playerMoveSpeed;
    public float playerBackwardSpeed=3f;
    [SerializeField]
    public float turnSpeed;
    Animator anim;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");
        var playerMovement = new Vector3(horizontalMovement, 0, verticalMovement);
        anim.SetFloat("Speed", playerMovement.magnitude);
        transform.Rotate(Vector3.up, horizontalMovement * turnSpeed * Time.deltaTime);
        if (verticalMovement != null)
        {
            float moveSpeed = verticalMovement > 0 ? playerMoveSpeed : playerBackwardSpeed;
            characterController.SimpleMove(transform.forward * verticalMovement * moveSpeed);

        }
        //Quaternion newDirection = Quaternion.LookRotation(playerMovement);
        //transform.rotation = Quaternion.Slerp(transform.rotation,newDirection,Time.deltaTime*turnSpeed);
    }
}
