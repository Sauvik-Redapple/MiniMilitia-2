using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 p_position;
    private float p_power = 40f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        p_position = this.transform.position + new Vector3(10f, 10f, 10f);
        if (p_power > 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("Going up");
                if (this.transform.position == p_position)
                {
                    this.transform.position = p_position;
                }
                p_power = p_power - 0.5f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Jumping up");
                this.GetComponent<Rigidbody>().AddForce(Vector3.up * 8f, ForceMode.Impulse);
                p_power = p_power - 0.3f;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                //Debug.Log("Going front");
                this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1f, ForceMode.Impulse);
            }
        }

        if (p_power < 40f)
        {
            p_power = p_power + 0.1f;
        }
        Debug.Log(p_power);
    }
}
