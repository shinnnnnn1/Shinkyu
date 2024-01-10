using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviourPun
{
    Rigidbody rigid;
    [SerializeField] [Range(0, 3)] float moveSpd;
    [SerializeField] float jumpPow;
    [SerializeField] float sensitivity;
    [SerializeField] bool mine;

    [SerializeField] Text mins;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Jump();
        //mins.text = photonView.IsMine.ToString();
        mins.text = photonView.ViewID.ToString();
    }
    void FixedUpdate()
    {
        if (!photonView.IsMine) { return; }
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
