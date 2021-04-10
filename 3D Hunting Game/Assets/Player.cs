using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float gravity = 9.81f;
    float velocity;
    public float jumpPower = 5;

    public float playerMoveSpeed = 5;
    private CharacterController controller;

    private bool isJump = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        if (controller.collisionFlags == CollisionFlags.Below)
        {
            velocity = 0;
            isJump = false;
        }
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            velocity = jumpPower;
        }
        velocity -= gravity * Time.deltaTime;

        dir.y = velocity;

        //dir = Camera.main.transform.TransformDirection(dir);

        controller.Move(dir * Time.deltaTime * playerMoveSpeed);
    }
}
