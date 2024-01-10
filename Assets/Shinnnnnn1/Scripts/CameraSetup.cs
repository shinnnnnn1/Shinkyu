using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class CameraSetup : MonoBehaviourPun
{
    void Start()
    {
        if(photonView.IsMine)
        {
            CinemachineVirtualCamera cam =
                GameObject.FindWithTag("PlayerCamera").
                GetComponent<CinemachineVirtualCamera>();
            cam.Follow = transform;
        }
    }
}
