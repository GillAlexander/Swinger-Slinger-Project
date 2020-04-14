using System;
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
        private bool objectIsAttached = false;
        private List<Rigidbody> ropeRigidbodies = new List<Rigidbody>();
        [SerializeField] private GameObject targetObject = null;
        private SoftJointLimitSpring joint = default;

        public GameObject TargetObject { get => targetObject; set => targetObject = value; }
        public bool IsRopeActive { get => isRopeActive; set => isRopeActive = value; }

        private void OnEnable()
        {
            RaycastManager.objectToAttach += FetchObject;
        }

        private void OnDisable()
        {
            RaycastManager.objectToAttach -= FetchObject;
            RaycastManager.playerIsInsideRange -= CreateRope;
        }

        private void FetchObject(GameObject target)
        {
            if (target != null)
            {
                if (!objectIsAttached)
                {
                    targetObject = target;
                }
                //else
                //    targetObject = null;

                RaycastManager.playerIsInsideRange += CreateRope;

                objectIsAttached = true;
            }
        }

        private void CreateRope()
        {
            StartCoroutine(BuildRope());
            return;
            List<Rigidbody> ropeList = new List<Rigidbody>();

            var targetRigidBody = targetObject.GetComponent<Rigidbody>();
            if (!targetObject.GetComponent<ConfigurableJoint>())
            {
                targetObject.AddComponent<ConfigurableJoint>();
            }

            SetupConfigurableJoint();

            if (!isRopeActive)
            {
                isRopeActive = true;
                for (int i = 0; i < 5; i++)
                {
                    GameObject ropePart = Instantiate(ropePrefab, new Vector3(ropeParent.transform.position.x,
                                                                                                             ropeParent.transform.position.y,
                                                                                                             ropeParent.transform.position.z + (i / 2)),
                                                                                                             ropeParent.transform.rotation, ropeParent.transform);
                    var joint = ropePart.GetComponent<ConfigurableJoint>();
                    var collider = ropePart.GetComponent<Collider>();
                    
                    ropeList.Add(ropePart.GetComponent<Rigidbody>());
                    ropePart.transform.eulerAngles = new Vector3(270, 0, 0);
                    ropePart.name = $"Rope {i}";
                    targetObject.transform.eulerAngles = new Vector3(270, 0, 0);
                    if (i == 0)
                    {
                        joint.connectedBody = ropeParent.GetComponent<Rigidbody>();
                        joint.connectedAnchor = new Vector3(0, 0, -0.2f);
                    }
                    else
                    {
                        joint.connectedBody = ropeList[i - 1];
                    }

                    if (i == 4)
                    {
                        targetObject.GetComponent<ConfigurableJoint>().connectedBody = ropePart.GetComponent<Rigidbody>();
                    }
                }
            }
        }

        private IEnumerator BuildRope()
        {
            if (!isRopeActive)
            {
                isRopeActive = true;
                for (int i = 0; i < numberOfRopeParts; i++)
                {
                    float posX = 0, posY = 0, posZ = 0;
                    Quaternion rotation = default;
                    Transform transform = ropeParent.transform;

                    if (ropeRigidbodies.Count == 0) // Äntligen :)
                    {
                        posX = ropeParent.transform.position.x;
                        posY = ropeParent.transform.position.y;
                        posZ = ropeParent.transform.position.z;
                        rotation = ropeParent.transform.rotation;
                    }
                    else
                    {
                        posX = ropeRigidbodies[i - 1].transform.position.x;
                        posY = ropeRigidbodies[i - 1].transform.position.y;
                        posZ = ropeRigidbodies[i - 1].transform.position.z;
                        rotation = ropeRigidbodies[i - 1].transform.rotation;
                    }

                    GameObject ropePart = Instantiate(ropePrefab, new Vector3(posX, posY, posZ), rotation, transform);


                    var joint = ropePart.GetComponent<ConfigurableJoint>();
                    var collider = ropePart.GetComponent<Collider>();

                    ropeRigidbodies.Add(ropePart.GetComponent<Rigidbody>());
                    //ropePart.transform.eulerAngles = new Vector3(270, 0, 0);
                    

                    ropePart.name = $"Rope {i}";
                    if (i == 0)
                    {
                        joint.connectedBody = ropeParent.GetComponent<Rigidbody>();
                        joint.connectedAnchor = new Vector3(0, 0, -0.15f);
                    }
                    else
                    {
                        joint.connectedBody = ropeRigidbodies[i - 1];
                        ropePart.transform.LookAt(ropeRigidbodies[i - 1].transform);
                    }

                    if (i == numberOfRopeParts - 1)
                    {
                        yield return new WaitForSeconds(0.05f);
                        if (targetObject != null && !targetObject.GetComponent<ConfigurableJoint>())
                        {
                            targetObject.AddComponent<ConfigurableJoint>();

                            SetupConfigurableJoint();
                        }
                        
                        //targetObject.transform.eulerAngles = new Vector3(270, 0, 0);
                        targetObject.transform.position = ropeRigidbodies[i].position;
                        targetObject.transform.rotation = ropeRigidbodies[i].transform.rotation;
                        targetObject.GetComponent<ConfigurableJoint>().connectedBody = ropePart.GetComponent<Rigidbody>();
                    }
                    yield return new WaitForSeconds(0.025f);
                    //yield return new WaitForSeconds(0f);
                }
            }
            
        }


        private void SetupConfigurableJoint()
        {
            var softJointLimitSpring = new SoftJointLimitSpring();
            var softJointLimit = new SoftJointLimit();

            softJointLimitSpring.spring = 5;
            softJointLimitSpring.damper = 2;
            softJointLimit.limit = 3;


            var targetJoint = targetObject.GetComponent<ConfigurableJoint>();

            targetJoint.xMotion = ConfigurableJointMotion.Limited;
            targetJoint.yMotion = ConfigurableJointMotion.Limited;
            targetJoint.zMotion = ConfigurableJointMotion.Limited;
            targetJoint.angularXMotion = ConfigurableJointMotion.Limited;
            targetJoint.angularYMotion = ConfigurableJointMotion.Limited;
            targetJoint.angularZMotion = ConfigurableJointMotion.Limited;

            targetJoint.autoConfigureConnectedAnchor = false;

            targetJoint.anchor = new Vector3(0, 0.5f, 0);
            targetJoint.axis = new Vector3(1, 0, 0);
            targetJoint.connectedAnchor = new Vector3(0, -1f, 0);
            targetJoint.secondaryAxis = new Vector3(0, 1, 0);

            targetJoint.angularXLimitSpring = softJointLimitSpring;
            targetJoint.angularYZLimitSpring = softJointLimitSpring;
            targetJoint.angularYLimit = softJointLimit;
        }

        public void ResetRope()
        {
            IsRopeActive = false;
            targetObject = null;
            objectIsAttached = false;

            StartCoroutine(DestroyRope());
        }

        public IEnumerator DestroyRope()
        {
            for (int i = 0; i < ropeRigidbodies.Count; i++)
            {
                Destroy(ropeRigidbodies[i].gameObject);
                ropeRigidbodies[i] = null;
            }
            ropeRigidbodies.Clear();
            yield return null;
        }
    }
}