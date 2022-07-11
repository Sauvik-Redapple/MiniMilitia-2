using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    Vector3 offset;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        offset= transform.position-target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position= target.transform.position + offset;
    }
}
