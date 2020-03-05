using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Jonathan
{
    public class RaycastManager : MonoBehaviour
    {
        private Camera mainCamera = default;
        private Ray ray = default;
        private RaycastHit raycastHit = default;
        private ButtonController controller = default;
        private Player player = default;
        public static event Action playerIsInsideRange = default;
        public static event Action<GameObject> objectToLift = default;

        void Start()
        {
            mainCamera = GetComponent<Camera>();
            controller = FindObjectOfType<ButtonController>();
            player = FindObjectOfType<Player>();
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
                        if (raycastHit.transform.GetComponent<IInteractable>() != null && raycastHit.transform.GetComponent<Player>() == null)
                        {
                            var distance = player.transform.position - raycastHit.transform.position;
                            Debug.Log(distance.magnitude);
                            if (distance.magnitude < 3)
                            {
                                playerIsInsideRange?.Invoke();
                            }
                        }
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue);
        }

        private void UpdateRay() => ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}