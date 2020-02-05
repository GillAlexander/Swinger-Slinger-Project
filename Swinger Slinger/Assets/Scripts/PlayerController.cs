using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class PlayerController : ButtonController
{
        [SerializeField] private float speed = default;
        private Rigidbody playerRb = default;
        private Transform playerTransform = default;
        private Camera camera = default;


        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            playerTransform = GetComponent<Transform>();
            camera = FindObjectOfType<Camera>();
        }

        void Update() // Lookover this shit
        {
            if (Input.GetButton("Forward"))
            {
                playerRb.velocity = Vector3.ProjectOnPlane(camera.transform.forward, playerTransform.up) * speed;
            }
            else if (Input.GetButton("Backward"))
            {
                playerRb.velocity = Vector3.ProjectOnPlane(camera.transform.forward, playerTransform.up) * -1 * speed;
            }
            else if (Input.GetButton("Left"))
            {
                playerRb.velocity = camera.transform.right * -1 * speed;
            }
            else if (Input.GetButton("Right"))
            {
                playerRb.velocity = camera.transform.right * speed;
            }

            

            leftMouseButtonHeldDown = Input.GetMouseButton(0) ? true : false;
            leftMouseButonPressed = Input.GetMouseButtonDown(0) ? true : false;
            leftMouseButtonReleased = Input.GetMouseButtonUp(0) ? true : false;
            rightMouseButtonHeldDown = Input.GetMouseButton(1) ? true : false;
            rightMouseButtonPressed = Input.GetMouseButtonDown(1) ? true : false;
            rightMouseButtonReleased = Input.GetMouseButtonUp(1) ? true : false;
        }
    }
}