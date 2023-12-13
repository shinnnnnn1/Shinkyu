using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField] [Range(0, 3)] float moveSpd;
    [SerializeField] float jumpPow;
    [SerializeField] float sensitivity;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        Move();
        RotateY();
        RotateX();
    }

    void Move()
    {
        Vector3 hor = transform.right * Input.GetAxisRaw("Horizontal");
        Vector3 ver = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 veloc = (hor + ver).normalized * moveSpd * 0.2f;
        rigid.MovePosition(transform.position + veloc);
    }

    void RotateY()
    {

    }

    void RotateX()
    {

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector3.up * jumpPow * 100);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
    }

    void OnCollisionExit(Collision collision)
    {

    }
}
