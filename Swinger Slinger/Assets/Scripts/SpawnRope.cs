using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class SpawnRope : MonoBehaviour
    {
        [SerializeField] private GameObject ropePrefab = default;
        [SerializeField] private GameObject ropeParent = default;

        [SerializeField] [Range(1, 50)] private int numberOfRopeParts = default;
        [SerializeField] private ConfigurableJoint configurableJoint = default;
        private bool isRopeActive = false;
        private Vector3 ropePosition = default;
        private GameObject targetObject = null;

        private ConfigurableJoint ropeJoint = default;
        private SoftJointLimitSpring joint = default;

        private void Update()
        {

        }

        private void OnEnable()
        {
            RaycastManager.playerIsInsideRange += CreateRope;
            RaycastManager.objectToAttach += FetchObject;
        }

        private void FetchObject(GameObject target)
        {
            if (target != null)
                targetObject = target;
            else
                Debug.LogError($"The target you want to attach the rope to is null");
        }

        private void CreateRope()
        {
            if (!isRopeActive)
            {
                for (int i = 0; i < 1; i++)
                {
                    GameObject ropePart = Instantiate(ropePrefab, ropeParent.transform.position, ropeParent.transform.rotation);
                    if (i == 1)
                    {
                        ropePart.name = $"Rope {i}";
                        ropePart.transform.LookAt(transform);
                    }
                    else
                    {

                    }
                }

                isRopeActive = true;
            }
        }

        private void DestroyRope()
        {

        }

        private void test()
        {
            //for (int i = 0; i < numberOfRopeParts; i++)
            //{
            //    GameObject tmp;

            //    //tmp = Instantiate(ropePrefab, new Vector3(ropePosition.x,
            //    //                                                     ropePosition.y + ropePartDistance * (i + 1),
            //    //                                                     ropePosition.z), Quaternion.identity, ropeParent.transform);
            //    //tmp.transform.eulerAngles = new Vector3(180, 0, 0);

            //    tmp.name = ropeParent.transform.childCount.ToString();

            //    if (i == 0)
            //    {
            //        Destroy(tmp.GetComponent<CharacterJoint>());
            //    }
            //    else
            //    {
            //        tmp.GetComponent<CharacterJoint>().connectedBody =
            //            ropeParent.transform.Find((ropeParent.transform.childCount - 1).ToString()).GetComponent<Rigidbody>(); ;
            //    }
            //}
        }
    }
}