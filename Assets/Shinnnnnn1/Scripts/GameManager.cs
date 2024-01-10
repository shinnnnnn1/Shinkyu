using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance
    {
        get
        {
            if (instance == null)
            {
                instancee = FindObjectOfType<GameManager>();
            }
            return instancee;
        }
    }
    private static GameManager instancee;

    void Start()
    {
        PhotonNetwork.Instantiate("Char01", Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
