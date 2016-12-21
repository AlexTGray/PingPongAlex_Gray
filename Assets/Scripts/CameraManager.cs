using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraManager : NetworkBehaviour {
    public Camera p1;
    public Camera p2;
    // Use this for initialization
    void Start()
    {
        p1.enabled = false;
        p2.enabled = false;


    }
    public override void OnStartLocalPlayer()
    {
        if (isServer)
        {
            p1.enabled = true;
            Debug.Log("P1 Status: " + p1.enabled);
        }
        else if (isClient)
        {
            p2.enabled = true;
            Debug.Log("Fucker");
        }
    }
        // Update is called once per frame
	void Update () {
        
    }
}
