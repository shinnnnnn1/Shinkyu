using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public UIManager ui;
    public ButtonRPC button;

    [Header("Default")]
    public TMP_Text[] statusText;
    public Image[] state;

    [Header("Matching")]
    public Image localMatching, fail;
    public TMP_Text pass, reason;
    public int id;

    void Awake() => Screen.SetResolution(1600, 900, false);
    void Update()
    {
        statusText[0].text = "Statue : " + PhotonNetwork.NetworkClientState.ToString();
        statusText[1].text = "Server : " + PhotonNetwork.Server.ToString();
        if (PhotonNetwork.InRoom)
        {
            statusText[2].text = "Room Name : " + PhotonNetwork.CurrentRoom.Name;
            statusText[3].text = "Player Count : " + PhotonNetwork.CurrentRoom.PlayerCount;
            statusText[5].text = "Player1 Stage : " + ui.stageSelected[0];
            statusText[6].text = "Player2 Stage : " + ui.stageSelected[1];
            statusText[7].text = "Local ID : " + id;
            statusText[9].text = "Selected Stage : " + ui.selectedStage;
            statusText[10].text = "01char : " + ui.character[0];
            statusText[11].text = "02char : " + ui.character[1];
            statusText[12].text = "01wea : " + ui.weapon[0];
            statusText[13].text = "02wea : " + ui.weapon[1];
        }
        statusText[8].text = ui.status.ToString();
    }

    //サーバー接触、切断
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        ui.Next(1);
    }
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnConnectedToMaster()
    {
        statusText[4].text = "Log : Master Server Connected";
    }
    public override void OnDisconnected(DisconnectCause cause) => print(cause);

    //ルーム参加、作成、退室
    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print(message);
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }
    public override void OnCreatedRoom()
    {
        statusText[4].text = "Log : Room Created";
        id = 1;
    }
    public override void OnJoinedRoom()
    {
        statusText[4].text = "Log : Room Joined";
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            id = PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log("Game Start");
            statusText[4].text = "Log : Game Started";
            ui.photonView.RPC("Next", RpcTarget.All, 3);
        }
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        statusText[4].text = "Log : Leaved Room";
        //if(id > PhotonNetwork.CurrentRoom.PlayerCount)
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer + newPlayer.NickName);
    }

    public void LocalCreate(InputField password)
    {
        if(password.text == "") { return; }
        PhotonNetwork.CreateRoom(password.text, new RoomOptions { MaxPlayers = 2 });
        pass.text = "Password : " + password.text;
        ui.Matching(localMatching);
    }
    public void LocalJoin(InputField password)
    {
        if (password.text == "") { return; }
        PhotonNetwork.JoinRoom(password.text);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) => Reason(message);
    public override void OnJoinRoomFailed(short returnCode, string message) => Reason(message);
    public void Reason(string message)
    {
        statusText[4].text = "Log : Failed";
        reason.text = message;
        ui.Matching(fail);
    }
}
