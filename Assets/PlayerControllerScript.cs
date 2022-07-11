using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerScript : MonoBehaviour
{
    private Vector3 p_position;
    private float p_power = 40f;
    private Animator p_anim;

    private void Start()
    {
        p_anim = GetComponent<Animator>();
    }
    private void Update()
    {
        p_anim.SetFloat("Run", 0);
        p_anim.SetFloat("Walk", 0);
        p_anim.SetFloat("Shoot", 0);
    }

    public void OnForward()
    {
        //this.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward * 10f * Time.deltaTime);
        p_anim.SetFloat("Walk", 1f);
        p_anim.SetFloat("Run", 0);
        p_anim.SetFloat("Shoot", 0);
    }


}
