using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;
        void Start()
        {
            mainCamera = FindObjectOfType<Camera>(); 
        }
        void Update()
        {

        }
    }
}
