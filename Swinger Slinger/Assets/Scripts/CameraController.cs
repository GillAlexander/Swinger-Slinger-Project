using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        [SerializeField] Vector3[] cameraPositions = new Vector3[4];
        [SerializeField] int placement = default;
        public GameObject cube;

        [SerializeField] AnimationCurve animationCurve = default;
        void Start()
        {
            mainCamera = FindObjectOfType<Camera>();
            mainCamera.transform.LookAt(cube.transform.position);
        }

        void Update()
        {
            CameraPositionSwitcher();
        }

        private void CameraPositionSwitcher()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                placement++;
                if (placement == cameraPositions.Length)
                {
                    placement = 0;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                placement--;
                if (placement == -1)
                {
                    placement = 0;
                }
            }

            mainCamera.transform.position = cameraPositions[placement];
            mainCamera.transform.LookAt(cube.transform.position);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < cameraPositions.Length; i++)
            {
                Gizmos.DrawCube(cameraPositions[i], Vector3.one / 2);
            }
        }
    }
}
