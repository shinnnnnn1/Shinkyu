using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRPC : MonoBehaviour
{
    NetworkManager network;
    UIManager ui;

    public void _SelectStage(int stage)
    {
        network = FindObjectOfType<NetworkManager>();
        ui = FindObjectOfType<UIManager>();
        if(stage == 5)
        {
            stage = Random.Range(1, 4);
        }
        ui.photonView.RPC("StageSelect", RpcTarget.All, network.id, stage);
    }
    public void _SelectCharacter(int number)
    {
        ui.photonView.RPC("SetCharacter", RpcTarget.All, network.id, number);
    }
    public void _SelectWeapon(int number)
    {
        ui.photonView.RPC("SetWeapon", RpcTarget.All, network.id, number);
    }
}
