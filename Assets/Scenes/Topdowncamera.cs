using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topdowncamera : MonoBehaviour
{
    public Transform c_Target;
    public float c_Height = 10f;
    public float c_Distance = 20f;
    public float c_Angle = 45f;
    public float c_SmoothSpeed = 0.5f;
    public Vector3 refVelocity;


    // Start is called before the first frame update
    void Start()
    {
        HandleCamera();
    }

    // Update is called once per frame
    void Update()
    {
        HandleCamera();
    }

    protected virtual void HandleCamera()
    {
        if (!c_Target)
        {
            return;
        }

        Vector3 worldPosition = (Vector3.forward * -c_Distance) + (Vector3.up * c_Height);
        Vector3 rotatedVector = Quaternion.AngleAxis(c_Angle, Vector3.up) * worldPosition;
        Vector3 flatTargetPosition = c_Target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, c_SmoothSpeed);
        transform.LookAt(flatTargetPosition);
    }
    
}
