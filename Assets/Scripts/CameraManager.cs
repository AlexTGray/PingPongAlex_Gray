using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour {
    public Camera p1;
    public Camera p2;

    // Use this for initialization
    void Start()
    {
        if(isLocalPlayer)
        {
            if (isClient)
            {
                p1.enabled = false;
                p2.enabled = true;
            }
            else
            {
                p1.enabled = true;
                p2.enabled = false;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
