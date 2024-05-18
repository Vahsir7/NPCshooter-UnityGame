using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    // Ensure the variable declaration is correct and not shadowed
    private PhotonView photonView;
    [SerializeField] GameObject player;

    [Header("References")]
    public Transform Cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalAmmo = 10;
    public float throwCoolDown=0.5f;

    [Header("Throwing")]
    public float throwForce = 100f;
    public float upwardForce = 1f;

    void Start()
    {
        Cam = Camera.main.transform;
    }

    
    public void shoot()
    {
        if (totalAmmo > 0)
        {
            // Call the shoot method using Photon RPC on the current object's PhotonView
            //player.GetComponent<PhotonView>().RPC("shoot", RpcTarget.All);
            // Instantiate the bullet
            GameObject projectile = Instantiate(objectToThrow, attackPoint.position, Cam.rotation);

            // Get the rigidbody of the bullet
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            // Calculate the direction the bullet will be thrown
            Vector3 forceDirection = Cam.transform.forward;

            // Add force to the bullet
            Vector3 forceToAdd = forceDirection * throwForce + transform.up * upwardForce;
            rb.AddForce(forceToAdd, ForceMode.Impulse);

            totalAmmo--;
        }
        
    }
}
