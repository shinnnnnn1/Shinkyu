using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_Text statusText;
    public GameObject state;
    public InputField roomInput, NickNameInput;
    public Image[] matching;
    public TMP_Text LocalText;

    float scene;

    void Awake() => Screen.SetResolution(800, 450, false);
    void Update() => statusText.text = PhotonNetwork.NetworkClientState.ToString();

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        print("Server Connected");
    }
    public void Disconnect() => PhotonNetwork.Disconnect();
    public override void OnDisconnected(DisconnectCause cause) => print(cause);


    public void JoinRandomOrCreateRoom() => PhotonNetwork.JoinRandomRoom();
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // ルームの参加人数を2人に設定する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        PhotonNetwork.CreateRoom(null, roomOptions);
    }
    public void LeaveRoom()
    {
        print(PhotonNetwork.Server);
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinedRoom()
    {
        print("Joined " + PhotonNetwork.CurrentRoom.Name);
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        //PhotonNetwork.LoadLevel("SampleScene");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) 
    {
        print(newPlayer);
    }
    public override void OnCreateRoomFailed(short returnCode, string message) => print("Failed Create Room");
    public override void OnJoinRoomFailed(short returnCode, string message) => print("Failed Join Room");
    //public override void OnJoinRandomFailed(short returnCode, string message) => print("Failed Join Random  Room");

    public void Next(bool previous)
    {
        int dir = previous ? 1 : -1;
        state.transform.localPosition += Vector3.right * (-1920 * dir);
    }
    public void LocalMatch(bool previous)
    {
        int dir = previous ? 1 : -1;
        state.transform.localPosition += Vector3.up * (-1080 * dir);
    }
    public void LocalCreateOrJoin(bool createRoom)
    {
        if(!createRoom)
        {
            PhotonNetwork.JoinRoom(roomInput.text);
        }
        else
        {
            PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions { MaxPlayers = 2 });
        }
    }
    public void ImageEnnable(GameObject window)
    {
        window.SetActive(!window.activeSelf);
    }
    public void ButtonInteractable(Button button)
    {
        button.interactable = !button.interactable;
    }
}
