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
            LeftMouseButtonHeldDown = Input.GetMouseButton(0) ? true : false;
            LeftMouseButonPressed = Input.GetMouseButtonDown(0) ? true : false;
            LeftMouseButtonReleased = Input.GetMouseButtonUp(0) ? true : false;
            RightMouseButtonHeldDown = Input.GetMouseButton(1) ? true : false;
            RightMouseButtonPressed = Input.GetMouseButtonDown(1) ? true : false;
            RightMouseButtonReleased = Input.GetMouseButtonUp(1) ? true : false;

            ForwardButtonPressed = Input.GetButtonDown("Forward") ? true : false;
            ForwardButtonHeldDown = Input.GetButton("Forward") ? true : false;
            ForwardButtonReleased = Input.GetButtonUp("Forward") ? true : false;

            BackwardButtonPressed = Input.GetButtonDown("Backward") ? true : false;
            BackwardButtonHeldDown = Input.GetButton("Backward") ? true : false;
            BackwardButtonReleased = Input.GetButtonUp("Backward") ? true : false;

            LeftButtonPressed = Input.GetButtonDown("Left") ? true : false;
            LeftButtonHeldDown = Input.GetButton("Left") ? true : false;
            LeftButtonReleased = Input.GetButtonUp("Left") ? true : false;

            RightButtonPressed = Input.GetButtonDown("Right") ? true : false;
            RightButtonHeldDown = Input.GetButton("Right") ? true : false;
            RightButtonReleased = Input.GetButtonUp("Right") ? true : false;


            if (ForwardButtonHeldDown)
            {
                playerRb.velocity = Vector3.ProjectOnPlane(camera.transform.forward, playerTransform.up) * speed;
            }

            if (BackwardButtonHeldDown)
            {
                playerRb.velocity = Vector3.ProjectOnPlane(camera.transform.forward, playerTransform.up) * -1 * speed;
            }

            if (LeftButtonHeldDown)
            {
                playerRb.velocity = camera.transform.right * -1 * speed;
            }

            if (RightButtonHeldDown)
            {
                playerRb.velocity = camera.transform.right * speed;
            }
        }
    }
}