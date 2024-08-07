using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    public GameObject player;
    [Space]
    public Transform[] spawnPoints;

    [Space]
    public GameObject roomCam;
    public GameObject SpectatorView;
    private string nickName="NPC";

    [Space]
    public GameObject nameUI;
    public GameObject connectingUI;
    public GameObject openningUI;

    private void Awake()
    {
        instance = this;
    }

    public void UserName()
    {
        openningUI.SetActive(false);
        nameUI.SetActive(true);
    }
    public void ChangeNikcname( string _name)
    {
        nickName=_name;
    }
    public void JoinRoomButtonPress()
    {
        Debug.Log("Joining room");
        PhotonNetwork.ConnectUsingSettings();

        nameUI.SetActive(false);
        connectingUI.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined lobby");
        PhotonNetwork.JoinOrCreateRoom("Room", null, null);
        //Debug.Log("creat");
    }

    public override void OnJoinedRoom()
    {
        roomCam.SetActive(false);
        base.OnJoinedRoom();
        Debug.Log("Joined room");
        spawnPlayer();

    }
    public void spawnPlayer()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation);
        _player.GetComponent<PlayerSetup>().isLocalPlayer();
        _player.GetComponent<Damage>().isLocalPlayer = true;

        _player.GetComponent<PhotonView>().RPC("overhead", RpcTarget.AllBuffered, nickName);
        
    }
    public void spectator()
    {
        SpectatorView.SetActive(true);
        
    }
}
