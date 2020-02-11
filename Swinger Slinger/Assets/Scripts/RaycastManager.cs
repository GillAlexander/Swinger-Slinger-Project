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
        private ButtonController controller = default;
        void Start()
        {
            mainCamera = GetComponent<Camera>();
            controller = FindObjectOfType<ButtonController>();
        }

        void Update()
        {
            if (Time.frameCount % 8 == 0) // Optimera mera
            {
                if (controller.RightMouseButtonHeldDown)
                {
                    UpdateRay();
                    if (Physics.Raycast(ray, out raycastHit))
                    {
                        Debug.Log(raycastHit.transform.GetComponent<IInteractable>());
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue);
        }

        private void UpdateRay() => ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}