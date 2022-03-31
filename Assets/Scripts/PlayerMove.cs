using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Vector3 currentPosition;
    private bool isSpaceAttackStarted;
    private float speed;
    private float shiftSpeed;
    public Camera camera;
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        speed = 20f;
        shiftSpeed = 15f;
    }

    private void FixedUpdate()
    {
        RotationLogic();
        MovementLogic();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isSpaceAttackStarted = true;
            Vector3 speedUp = new Vector3(0f, 0f, 50f);
            Vector3 startPoint = transform.position;
            Vector3 endPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 15f);
            currentPosition = transform.position;
            //playerRigidBody.MovePosition(endPoint);
            //playerRigidBody.AddRelativeForce(Vector3.forward * 1000f, ForceMode.VelocityChange);
            
            //playerRigidBody.AddRelativeForce(Vector3.back * 1000f, ForceMode.VelocityChange);
            //playerRigidBody.AddForce(Vector3.forward * 50f, ForceMode.Force);
            //playerRigidBody.GetPointVelocity(endPoint);
            //playerRigidBody.AddForceAtPosition(speedUp, endPoint);
            //playerRigidBody.AddForceAtPosition(speedUp, startPoint);

            //playerRigidBody.AddRelativeForce(endPoint, ForceMode.VelocityChange);
            //playerRigidBody.AddRelativeForce(startPoint, ForceMode.VelocityChange);

            //playerRigidBody.MovePosition(endPoint);
            //playerRigidBody.MovePosition(startPoint);
        }

        if (isSpaceAttackStarted)
        {
            SpaceAttack();
        }
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
         //playerRigidBody.AddRelativeForce(movement * speed, ForceMode.Impulse);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerRigidBody.velocity = movement * (speed + shiftSpeed);
        }
        else
        {
            playerRigidBody.velocity = movement * speed;
        }
    }

    private void SpaceAttack()
    {
        Vector3 endPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10000f);
        if (transform.position == currentPosition)
        {
            playerRigidBody.AddRelativeForce(transform.forward * 100f, ForceMode.VelocityChange);
            //playerRigidBody.AddRelativeForce(Vector3.forward * 500f, ForceMode.Impulse);
        }

        if (transform.position == endPoint)
        {
            //playerRigidBody.AddRelativeForce(Vector3.back * 500f, ForceMode.Impulse);
            isSpaceAttackStarted = false;
        }
    }
}
