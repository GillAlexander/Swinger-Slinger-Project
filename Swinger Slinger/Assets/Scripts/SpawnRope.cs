using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRope : MonoBehaviour
{
    [SerializeField] GameObject ropePrefab = default;
    [SerializeField] GameObject ropeParent = default;
    [SerializeField] CharacterJoint ropeJoint = default;
    
    [SerializeField] [Range(1, 50)] private float ropeLength = default;
    [SerializeField] private float ropePartLength = default;
    [SerializeField] bool spawn = default;

    private void Update()
    {
        if (spawn)
        {
            InstantiateRope();
            spawn = false;
        }
    }
    private void InstantiateRope()
    {
        var count = (int)(ropeLength / ropePartLength);

        for (int x = 0; x < count; x++)
        {
            GameObject tmp;

            tmp = Instantiate(ropePrefab, new Vector3(transform.position.x,
                                                                           transform.position.y + ropePartLength * (x + 1),
                                                                           transform.position.z),
                                                                           Quaternion.identity, ropeParent.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);

            tmp.name = ropeParent.transform.childCount.ToString();

            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = ropeParent.transform.Find((ropeParent.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }
    }
}