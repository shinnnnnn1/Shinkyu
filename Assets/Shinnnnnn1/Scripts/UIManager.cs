using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class UIManager : MonoBehaviourPunCallbacks
{
    [HideInInspector] public NetworkManager network;

    public int status;
    public Image currentImage;
    public Image[] image;
    public Image[] panels;
    public Image[] wating;

    public int[] stageSelected;
    public int selectedStage;

    public int[] character;
    public int[] weapon;

    void Start()
    {
        network = FindObjectOfType<NetworkManager>();
    }
        
    [PunRPC]
    public void Next(int direction)
    {
        image[status].gameObject.SetActive(false);
        status += direction;
        image[status].gameObject.SetActive(true);
        currentImage = image[status];
    }
    public void Matching(Image panel)
    {
        panel.gameObject.SetActive(!panel.gameObject.activeSelf);
    }

    [PunRPC]
    public void StageSelect(int id, int stage)
    {
        stageSelected[id - 1] = stage;
        if (stageSelected[0] != 0 && stageSelected[1] != 0)
        {
            if(stageSelected[0] == stageSelected[1])
            {
                selectedStage = stageSelected[0];
            }
            else
            {
                int set = Random.Range(0, 1);
                selectedStage = stageSelected[set];
            }
            photonView.RPC("Next", RpcTarget.Others, 1);
        }
    }

    [PunRPC]
    public void SetCharacter(int id, int number)
    {
        character[id - 1] = number;
    }

    [PunRPC]
    public void SetWeapon(int id, int number)
    {
        weapon[id - 1] = number;
        if(weapon[0] != 0 && weapon[1] != 0)
        {
            Debug.Log("Stage " + selectedStage + " Start");
            photonView.RPC("GameStart", RpcTarget.All, selectedStage);
        }
    }

    [PunRPC]
    public void GameStart(int stage)
    {
        PhotonNetwork.LoadLevel("0" + stage);
        Debug.Log("ALEFIBVJHNDFOIVJNDIV");
        //photon.RPC("CreateCharacters", RpcTarget.All, selectedStage, character[id - 1], weapon[id - 1]);
    }

    [PunRPC]
    public void CreateCharacters(int charact, int weap)
    {
        for(int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount;  i++)
        {
            GameObject aom = PhotonNetwork.Instantiate("Char" + charact, Vector3.up, Quaternion.identity);
            aom.GetPhotonView().ViewID = 2;
        }
    }
}
