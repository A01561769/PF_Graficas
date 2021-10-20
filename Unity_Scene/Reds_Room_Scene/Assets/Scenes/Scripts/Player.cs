using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;

    [SerializeField]
    private float speed;
    [SerializeField]
    public float jumpSpeed;
    [SerializeField]
    public float gravity;

    private Vector3 moveXY = Vector3.zero;
    private Vector3 moveY = Vector3.zero;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {

        if(controller.isGrounded && moveY.y < 0) {
            moveY.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveXY = transform.right * x + transform.forward * z;
        controller.Move(moveXY * speed * Time.deltaTime);

        if (controller.isGrounded && Input.GetButton("Jump")) {
            moveY.y = jumpSpeed;
        }

        moveY.y += gravity * Time.deltaTime;
        controller.Move(moveY * Time.deltaTime);
        
    }
}