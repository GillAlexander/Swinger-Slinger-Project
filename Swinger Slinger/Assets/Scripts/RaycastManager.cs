using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class RaycastManager : MonoBehaviour
    {
        private Camera mainCamera = default;
        private Ray ray = default;
        private RaycastHit raycastHit = default;

        void Start()
        {
            mainCamera = GetComponent<Camera>();
        }

        void Update()
        {
            UpdateRay();
            if (Physics.Raycast(ray))
            {
                Debug.Log($"Raycast hit {ray}");
            }
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue);
        }

        private void UpdateRay()
        {
            //if (true)
            //{
                ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //}
        }
    }
}