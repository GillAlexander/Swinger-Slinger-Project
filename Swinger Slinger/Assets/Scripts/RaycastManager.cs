﻿using System.Collections;
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
        private SpawnRope spawnRope = null;
        private Player player = default;
        private bool objectIsAttached = false;
        public static event Action playerIsInsideRange = default;
        public static event Action<GameObject> objectToAttach = default;

        void Start()
        {
            mainCamera = GetComponent<Camera>();
            controller = FindObjectOfType<ButtonController>();
            spawnRope = FindObjectOfType<SpawnRope>();
            player = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (Time.frameCount % 8 == 0) // Optimera mera
            {
                if (controller.RightMouseButtonHeldDown && spawnRope.IsRopeActive == false)
                {
                    UpdateRay();
                    if (Physics.Raycast(ray, out raycastHit))
                    {
                        var transform = raycastHit.transform;
                        if (transform.GetComponent<IInteractable>() != null && transform.GetComponent<Player>() == null)
                        {
                            var distance = player.transform.position - transform.position;
                            objectToAttach?.Invoke(transform.gameObject);

                            if (distance.magnitude < 3)
                            {
                                playerIsInsideRange?.Invoke();
                                objectIsAttached = true;
                            }
                        }
                        else
                        {
                            objectToAttach?.Invoke(null);
                        }
                    }
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue);
        }

        private void UpdateRay() => ray = mainCamera.ScreenPointToRay(Input.mousePosition);
    }
}