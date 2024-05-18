using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerLook PlayerLook;
    public InputManager InputManager;
    public Snowball snowball;
    public GameObject playerCamera;
    public GameObject attackPoint;

    [Space]
    public string nickname;
    public TextMeshPro nicknameText;   
    public GameObject playerHUD;
    public GameObject HealthBarOverhead;

    public void isLocalPlayer()
    {
        playerMovement.enabled = true;
        playerCamera.SetActive(true);
        PlayerLook.enabled = true;
        snowball.enabled = true;
        attackPoint.SetActive(true);       
        InputManager.enabled = true;
        playerHUD.SetActive(true);
        HealthBarOverhead.SetActive(true);
    }

    [PunRPC]
    public void overhead(string _nickname)
    {
        nickname = _nickname;
        nicknameText.text = nickname;

        HealthBarOverhead.gameObject.GetComponent<PhotonView>().RPC("SetMaxHealth", RpcTarget.AllBuffered, 5);
    }
    [PunRPC]
    public void isSpectator()
    {
        playerMovement.enabled = false;
        playerCamera.SetActive(false);
        PlayerLook.enabled = false;
        snowball.enabled = false;
        attackPoint.SetActive(false);
        InputManager.enabled = false;
        playerHUD.SetActive(false);
        HealthBarOverhead.SetActive(false);
        Camera.main.enabled = false;
        RoomManager.instance.SpectatorView.GetComponent<Camera>().enabled=true;
    }

}
