using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    
    Camera SpectatorCam;
    public int flag = 0;
    public void LateUpdate()
    {
        //if(flag==0)
        if(Camera.main!=null){ transform.LookAt(Camera.main.transform); }
        
        //print(flag);
        /*else
        {
            Debug.Log("Camera.main is null");
            SpectatorCam=RoomManager.instance.SpectatorView.GetComponent<Camera>();
            transform.LookAt(SpectatorCam.transform.position + SpectatorCam.transform.forward);

        }*/

        //transform.LookAt(Camera.main.transform);
    }
}
