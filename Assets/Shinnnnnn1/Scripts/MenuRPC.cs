using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MenuRPC : MonoBehaviourPunCallbacks
{
    [HideInInspector] public PhotonView photo;

    private void Start()
    {
        photo = GetComponent<PhotonView>();
    }

    [PunRPC]
    void Next()
    {
        transform.localPosition += Vector3.right * (-1920);
    }

    [PunRPC]
    void ButtonOn()
    {

    }
}
