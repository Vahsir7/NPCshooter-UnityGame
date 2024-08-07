using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Damage : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    public HealthBar HealthBar;
    int currentHealth;
    public bool isLocalPlayer;
    public GameObject HealthBarHUD;
    public GameObject HealthBarOverhead;
    Billboard billboard;

    
    
    
    void Start()
    {
        currentHealth= maxHealth;
        //HealthBar.SetMaxHealth(maxHealth);
        HealthBarHUD.gameObject.GetComponent<PhotonView>().RPC("SetMaxHealth", RpcTarget.AllBuffered, maxHealth);
        HealthBarOverhead.gameObject.GetComponent<PhotonView>().RPC("SetMaxHealth", RpcTarget.AllBuffered, maxHealth);
    }

    [PunRPC]
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //HealthBar.SetHealth(currentHealth);
        HealthBarHUD.gameObject.GetComponent<PhotonView>().RPC("SetHealth", RpcTarget.AllBuffered, currentHealth);
        HealthBarOverhead.gameObject.GetComponent<PhotonView>().RPC("SetHealth", RpcTarget.AllBuffered, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        
        if (isLocalPlayer)
            RoomManager.instance.spawnPlayer();
            //billboard.flag = 1;
            Destroy(gameObject);
            //PlayerSetup playerSetup = GetComponent<PlayerSetup>();
            //playerSetup.GetComponent<PhotonView>().RPC("isSpectator", RpcTarget.AllBuffered);
        


    }
}
