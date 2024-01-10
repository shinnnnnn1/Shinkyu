using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkInfo : MonoBehaviourPunCallbacks
{
    public static int id, character, weapon;
    public Text status, server, playerId, roomName, playerCount,
        stage, selectedStage, charact, weap;

    void Update()
    {
        status.text = "Statue : " + PhotonNetwork.NetworkClientState.ToString();
        server.text = "Server : " + PhotonNetwork.Server.ToString();
        if (PhotonNetwork.InRoom)
        {

        }
    }
}
