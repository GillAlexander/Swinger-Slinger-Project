using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class PlayerControler : MonoBehaviour
    {
        private Rigidbody playerRb;
        private Transform playerTransform;
        [SerializeField] private float speed;
        private Camera camera;
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
        }
    }
}