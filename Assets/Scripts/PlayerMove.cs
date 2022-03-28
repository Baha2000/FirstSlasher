using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private float speed;
    public Camera camera;
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        speed = 2f;
    }

    private void FixedUpdate()
    {
        RotationLogic();
        MovementLogic();
    }

    private void RotationLogic()
    {

        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit, 100);
            transform.LookAt(hit.point); 
        }
        
        //var direction = Input.mousePosition - camera.WorldToScreenPoint(transform.position);
        //Debug.Log(direction);
        //var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        // var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector3 difference = mousePosition - transform.position; 
        // difference.Normalize();
        // float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0f, rotation_z, 0f);
    }

    private void MovementLogic()
    {
        // Vector3 movement = new Vector3();
        //
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     movement += Vector3.forward;
        // }
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     movement += Vector3.left;
        // }
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     movement += Vector3.back;
        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     movement += Vector3.right;
        // }
        //
        // playerRigidBody.velocity = movement * speed;

         float moveHorizontal = Input.GetAxis("Horizontal");
        
         float moveVertical = Input.GetAxis("Vertical");
        
         Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
         playerRigidBody.AddRelativeForce(movement * speed, ForceMode.Impulse);

        //playerRigidBody.velocity += movement * speed;
    }
}
