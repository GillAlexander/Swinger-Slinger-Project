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
        public bool test = false;

        [SerializeField] private GameObject ropeParent = default;
        private ConfigurableJoint[] joints;
        [SerializeField] private float maximumRopeTension = 0;
        [Tooltip("Time it takes before the rope is at max tension")]
        [SerializeField] private float spinTime = 0;
        [SerializeField] private float throwDistance = 0;
        private SoftJointLimitSpring softJointLimitSpring = new SoftJointLimitSpring();


        [Header("Curve")]
        [SerializeField] AnimationCurve curve = default;
        private float timeUntilMaxRopeTension = 0;

        void Start()
        {
            rotationSpeed = FindObjectOfType<PlayerController>().RotationSpeed;
            rotationValue = FindObjectOfType<PlayerController>().RotationValue;
        }

        void Update()
        {
            Debug.Log(rotationValue);
            
            if (test)
            {
                CalculateRotationSpeed();
                test = false;
            }

            if (GetComponent<PlayerController>().RotateRightButtonHeldDown)
            {
                if (joints == null)
                    joints = ropeParent.GetComponentsInChildren<ConfigurableJoint>();

                timeUntilMaxRopeTension += Time.deltaTime;
                if (timeUntilMaxRopeTension < 3)
                {
                    var value = curve.Evaluate(timeUntilMaxRopeTension);
                    Debug.Log(value);
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