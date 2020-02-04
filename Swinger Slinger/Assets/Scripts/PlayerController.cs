using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody playerRb = default;
        private Transform playerTransform;
        private Camera camera = default;

        private bool leftMouseButtonHeldDown = false;
        private bool leftMouseButonPressed = false;
        private bool leftMouseButtonReleased = false;
        private bool rightMouseButtonHeldDown = false;
        private bool rightMouseButtonPressed = false;
        private bool rightMouseButtonReleased = false;

        public bool LeftMouseButtonHeldDown { get => leftMouseButtonHeldDown; set => leftMouseButtonHeldDown = value; }
        public bool LeftMouseButonPressed { get => leftMouseButonPressed; set => leftMouseButonPressed = value; }
        public bool LeftMouseButtonReleased { get => leftMouseButtonReleased; set => leftMouseButtonReleased = value; }
        public bool RightMouseButtonHeldDown { get => rightMouseButtonHeldDown; set => rightMouseButtonHeldDown = value; }
        public bool RightMouseButtonPressed { get => rightMouseButtonPressed; set => rightMouseButtonPressed = value; }
        public bool RightMouseButtonReleased { get => rightMouseButtonReleased; set => rightMouseButtonReleased = value; }

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