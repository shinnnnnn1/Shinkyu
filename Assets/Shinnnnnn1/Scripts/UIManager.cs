using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UIManager : MonoBehaviourPunCallbacks
{
    [HideInInspector] public PhotonView photo;

    public float status;

    void Start()
    {
        photo = GetComponent<PhotonView>();
    }

    public void Next(bool previous)
    {
        int direction = previous ? -1 : 1;

    }
}
