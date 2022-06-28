using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoMovementScript : MonoBehaviour
{
    [SerializeField]
    private float movSpeed;
    public Rigidbody rb;

    private float MoveX;
    private float MoveZ;
    [SerializeField] float Mouse_Sensitivity;
    [SerializeField] float Gun_Senityvity;
    [SerializeField] Transform gun;
    [SerializeField] private float xAxis;
    [SerializeField] private float yAxis;
    [SerializeField] float yrot;

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


        xAxis += Input.GetAxis("Mouse X") * Mouse_Sensitivity * Time.deltaTime;
        yAxis += Input.GetAxis("Mouse Y");

        Rotate_gun();
        clamp_rotation();
        Rotate_Player();

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }
    private void Rotate_Player()
    {
        transform.localRotation = Quaternion.Euler(0, -xAxis, 0);

    }
    private void Rotate_gun()
    {
        gun.localRotation = Quaternion.Euler(0, 0, yrot);
    }
    void clamp_rotation()
    {
        yrot = Mathf.Clamp(yAxis * Gun_Senityvity, -30, 30);
    }
}
