using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Unity.VisualScripting;

public class playerHUD : MonoBehaviour
{   
    [SerializeField] Snowball snowball;
    public TMP_Text ammo;
    public GameObject hudDisplay;
    //public GameObject player;
    //public TextMeshPro health;

    int ammoCount;
    // Start is called before the first frame update
    private void Start()
    {
        //ammo.text = $"AMMO :{snowball.totalAmmo}";
        ammoCount = snowball.totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = snowball.totalAmmo;
        hudDisplay.gameObject.GetComponent<PhotonView>().RPC("AmmoCounter", RpcTarget.AllBuffered, ammoCount);
        
    }

    [PunRPC]
    public void AmmoCounter(int _ammoCount)
    {
        ammo.text = $"AMMO :{_ammoCount}";
    }


}
