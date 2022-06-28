using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float movSpeed;
    public Rigidbody rb;

    private float MoveX;
    private float MoveZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(MoveX, 0, MoveZ);
        rb.transform.Translate(moveDirection * movSpeed * Time.deltaTime, Space.World);

        if(moveDirection!=Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }
}
