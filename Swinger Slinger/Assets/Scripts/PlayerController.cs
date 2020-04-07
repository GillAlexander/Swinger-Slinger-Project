using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
public class PlayerController : ButtonController
{
        [Header("Movement Settings")]
        [SerializeField] private float speed = default;

        [Header("Rotational Settings")]
        [SerializeField] private float rotationSpeed = default;
        [SerializeField] AnimationCurve rotationCurve = default;
        private float rotationTime = 0;


        private Rigidbody rigidBody = default;
        private Transform playerTransform = default;
        private Camera camera = default;
        private RaycastManager raycastManager = default;
        private int rotationDirection = 0;

        private float rotationValue = 0;
        public float RotationValue { get => rotationValue; set => rotationValue = value; }

        public float RotationSpeed { get => rotationSpeed; }

        void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            playerTransform = GetComponent<Transform>();
            camera = FindObjectOfType<Camera>();
            RaycastManager.objectToAttach += RotatePlayer;
        }

        private void OnDisable()
        {
            RaycastManager.objectToAttach -= RotatePlayer;
        }

        void FixedUpdate() // Lookover this shit
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

            RotateLeftButtonHeldDown = Input.GetKey(KeyCode.F) ? true : false;
            RotateRightButtonHeldDown = Input.GetButton("LeftRotation") ? true : false;

            RotateLeftButtonReleased = Input.GetKeyUp(KeyCode.F) ? true : false;
            RotateRightButtonReleased = Input.GetButtonUp("RightRotation") ? true : false;


            if (ForwardButtonHeldDown && RightButtonHeldDown)
            {
                rigidBody.velocity = Vector3.ProjectOnPlane(camera.transform.forward + camera.transform.right, playerTransform.up) *  speed ;
            }
            else if (ForwardButtonHeldDown && LeftButtonHeldDown)
            {
                rigidBody.velocity = Vector3.ProjectOnPlane(camera.transform.forward + (camera.transform.right * -1), playerTransform.up) * speed;
            }
            else if (ForwardButtonHeldDown)
            {
                rigidBody.velocity = Vector3.ProjectOnPlane(camera.transform.forward, playerTransform.up) * speed;
            }
            else if (BackwardButtonHeldDown && RightButtonHeldDown)
            {
                rigidBody.velocity = Vector3.ProjectOnPlane(camera.transform.forward + (camera.transform.right * -1), playerTransform.up) * -1 * speed;
            }
            else if (BackwardButtonHeldDown && LeftButtonHeldDown)
            {
                rigidBody.velocity = Vector3.ProjectOnPlane(camera.transform.forward + camera.transform.right, playerTransform.up) * -1 * speed;
            }
            else if (RightButtonHeldDown)
            {
                rigidBody.velocity = camera.transform.right * speed;
            }
            else if (LeftButtonHeldDown)
            {
                 rigidBody.velocity = camera.transform.right * -1 * speed;
            }
            else if (BackwardButtonHeldDown)
            {
                rigidBody.velocity = Vector3.ProjectOnPlane(camera.transform.forward, playerTransform.up) * -1 * speed;
            }

            if (RotateRightButtonHeldDown)
            {
                rotationDirection = 1;
            }
            else if (RotateLeftButtonHeldDown)
            {
                rotationDirection = -1;
            }
            else
            {
                if (rotationTime < 0)
                {
                    rotationDirection = 1;
                }
                else if (rotationTime > 0)
                {
                    rotationDirection = -1;
                }
                else
                rotationDirection = 0;
            }

            rotationTime = Mathf.Clamp(rotationTime, -1, 1);
            var evaluate = Mathf.Clamp(rotationTime += Time.deltaTime * rotationDirection, -1, 1);
            rotationValue = rotationCurve.Evaluate(evaluate);

            transform.rotation *= Quaternion.Euler(0, -1 * rotationSpeed * rotationValue, 0);

        }

        private void RotatePlayer(GameObject position)
        {
            if (position != null)
            {
                var pos = position.transform.position;
                transform.LookAt(new Vector3(pos.x, 1, pos.z));
            }
        }

    }
}