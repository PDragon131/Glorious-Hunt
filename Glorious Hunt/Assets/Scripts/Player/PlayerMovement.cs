using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 6f;  // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    //Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Camera mCamera;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        //floorMask = LayerMask.GetMask("Floor");

        // Set up references.
       // anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        mCamera = FindObjectOfType<Camera>();

    }

    Vector3 GetMousePos()
    {
        Plane p = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
        float dis;
        if (p.Raycast(ray, out dis))
            return ray.GetPoint(dis);
        else
            return Vector3.zero;
    }


    void FixedUpdate()
    {
        // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Move the player around the scene.
        Move(h, v);

        // Turn the player to face the mouse cursor.
        Turning();

        // Animate the player.
        // Animating(h, v);


    }

        void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
    void Turning()
    {
       
        Vector3 mousePos = GetMousePos();
        transform.LookAt(mousePos);

        Vector3 rotation = transform.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;
        transform.eulerAngles = rotation;
    }

        /*
        void Animating(float h, float v)
        {
            // Create a boolean that is true if either of the input axes is non-zero.
            bool walking = h != 0f || v != 0f;

            // Tell the animator whether or not the player is walking.
            anim.SetBool("IsWalking", walking);
        }
        */
    }

