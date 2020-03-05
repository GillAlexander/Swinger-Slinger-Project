using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class SpawnRope : MonoBehaviour
    {
        [SerializeField] GameObject ropePrefab = default;
        [SerializeField] GameObject ropeParent = default;
        [SerializeField] CharacterJoint ropeJoint = default;
        [SerializeField] float ropePartDistance = 0.1f;
        [SerializeField] [Range(1, 50)] private int numberOfRopeParts = default;
        [SerializeField] bool spawn = default;
        private bool activeObject = false;
        private Vector3 ropePosition = default;

        private void Update()
        {
            if (spawn)
            {
                PickupInteractableObject();
                spawn = false;
            }
        }

        private void OnEnable()
        {
            RaycastManager.playerIsInsideRange += PickupInteractableObject;
        }

        private void  FetchPosition(Vector3 position)
        {
            ropePosition = position;
        }

        private void PickupInteractableObject()
        {
            if (!activeObject)
            {


                activeObject = true;
            }
        }
    }
}


//Spawn rope code
/*
            if (!isRopeActive)
            {
                for (int i = 0; i < numberOfRopeParts; i++)
                {
                    GameObject tmp;

                    tmp = Instantiate(ropePrefab, new Vector3(ropePosition.x,
                                                                         ropePosition.y + ropePartDistance * (i + 1),
                                                                         ropePosition.z), Quaternion.identity, ropeParent.transform);
                    tmp.transform.eulerAngles = new Vector3(180, 0, 0);

                    tmp.name = ropeParent.transform.childCount.ToString();

                    if (i == 0)
                    {
                        Destroy(tmp.GetComponent<CharacterJoint>());
                    }
                    else
                    {
                        tmp.GetComponent<CharacterJoint>().connectedBody =
                            ropeParent.transform.Find((ropeParent.transform.childCount - 1).ToString()).GetComponent<Rigidbody>(); ;
                    }
                }

                isRopeActive = true;
            }
 * 
*/