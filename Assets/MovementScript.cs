using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Vector3 p_position;
    private float p_power = 40f;
    private Animator p_anim;
    // Start is called before the first frame update
    void Start()
    {
        p_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        p_anim.SetFloat("Run", 0);
        p_anim.SetFloat("Walk", 0);
        p_anim.SetFloat("Shoot", 0);
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            p_anim.SetFloat("Walk", 1f);
            p_anim.SetFloat("Run", 0);
            p_anim.SetFloat("Shoot", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * 50f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up * -50f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.forward * -10f * Time.deltaTime);
            p_anim.SetFloat("Walk", 0.5f);
            p_anim.SetFloat("Run", 0);
            p_anim.SetFloat("Shoot", 0);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.forward * 20f * Time.deltaTime);
            p_anim.SetFloat("Run", 1f);
            p_anim.SetFloat("Walk", 0);
            p_anim.SetFloat("Shoot", 0);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.LeftShift))
        {
            this.transform.Translate(Vector3.forward * -20f * Time.deltaTime);
            p_anim.SetFloat("Run", 0.5f);
            p_anim.SetFloat("Walk", 0);
            p_anim.SetFloat("Shoot", 0);
        }
        if(Input.GetMouseButton(0))
        {
            p_anim.SetFloat("Shoot", 1);
            p_anim.SetFloat("Walk", 0);
            p_anim.SetFloat("Run", 0);
        }


        #region JumpFlight
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
        #endregion
    }
}
