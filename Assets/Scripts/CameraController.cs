using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraController : NetworkBehaviour
{
    public Camera cam;
	// Use this for initialization
	void Start () {
        
        if (isLocalPlayer)
        {
            cam.enabled = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
