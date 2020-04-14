using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonathan
{
    public class RopeMechanics : MonoBehaviour
    {
        private bool inRotation = default;
        private float rotationSpeed = 0;
        private float rotationValue = 0;

        [SerializeField] private GameObject ropeParent = default;
        private ConfigurableJoint[] joints;
        [SerializeField] private float maximumRopeTension = 0;
        [Tooltip("Time it takes before the rope is at max tension")]
        [SerializeField] private float spinTime = 0;
        [SerializeField] private float throwDistance = 0;
        private SoftJointLimitSpring softJointLimitSpring = new SoftJointLimitSpring();

        private SpawnRope spawnRope = null;

        [Header("Curve")]
        [SerializeField] AnimationCurve curve = default;
        private float timeUntilMaxRopeTension = 0;

        void Start()
        {
            spawnRope = GetComponent<SpawnRope>();

            rotationSpeed = FindObjectOfType<PlayerController>().RotationSpeed;
            rotationValue = FindObjectOfType<PlayerController>().RotationValue;
        }

        void Update()
        {
            if (spawnRope.IsRopeActive)
            {
                if (GetComponent<PlayerController>().RotateRightButtonHeldDown || GetComponent<PlayerController>().RotateLeftButtonHeldDown)
                {
                    if (joints == null)
                        joints = ropeParent.GetComponentsInChildren<ConfigurableJoint>();

                    timeUntilMaxRopeTension += Time.deltaTime;
                    if (timeUntilMaxRopeTension < 3)
                    {
                        var value = curve.Evaluate(timeUntilMaxRopeTension);

                        softJointLimitSpring.spring += (5 * value);

                        for (int i = 0; i < joints.Length; i++)
                        {
                            joints[i].angularYZLimitSpring = softJointLimitSpring;
                        }
                    }
                }
                else
                {
                    if (joints != null)
                    {
                        softJointLimitSpring.spring = 5;

                        for (int i = 0; i < joints.Length; i++)
                        {
                            joints[i].angularYZLimitSpring = softJointLimitSpring;
                        }
                    }

                    timeUntilMaxRopeTension = 0;
                }
            }

        }

        public void DetachAttachedObject()
        {
            if(spawnRope.TargetObject != null && spawnRope.IsRopeActive)
            {
                Debug.Log("Detach Object");
                for (int i = 0; i < joints.Length; i++)
                {
                    joints[i] = null;
                }
                joints = null;
                Destroy(spawnRope.TargetObject.GetComponent<ConfigurableJoint>());
                spawnRope.TargetObject.GetComponent<Rigidbody>().AddForce((spawnRope.transform.forward * 10) + Vector3.up * 5 , ForceMode.Impulse);
                spawnRope.ResetRope();
            }
        }

        private void CalculateRotationSpeed()
        {
            
        }

        private void CalculateRopeStrength()
        {

        }

        private IEnumerator IncreaseRopeTension()
        {
            var time = 0f;
            while (time < 3f)
            {
                yield return new WaitForSeconds(1f);
                time += Time.deltaTime;

                Debug.Log("Tension");
            }

            time = 0;
            yield return null;
        }
    }
}