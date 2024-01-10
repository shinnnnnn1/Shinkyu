using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    Rigidbody rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(Vector3.right * 10000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("asdasd");
        }
    }
}
