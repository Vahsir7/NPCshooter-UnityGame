using Photon.Pun;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Damage value to apply on collision
    public int damageAmount = 1;
    int wrongOffset = 0;
    private void OnCollisionEnter(Collision collision)
    {
        wrongOffset++;

        if (wrongOffset > 1)
        {
            // Check if the collision is with an object tagged as "Enemy" or "Player"
            if (collision.gameObject.GetComponent<Damage>())
            {
                collision.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, damageAmount);
                
            }
            Destroy(gameObject);
            wrongOffset = 0;
        }
    }
}