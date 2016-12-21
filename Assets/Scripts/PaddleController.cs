using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PaddleController : NetworkBehaviour {
    public GameObject paddle;
    public Transform p1;
    bool isP1;
    bool isP2;
    public Transform p2;
    Rigidbody rb;

    float horizontalMove;
    float verticalMove;
    float speed = 0.2f;

    private Vector3 paddlePos;
    // Use this for initialization
    void Awake()
    {
      
    }

    void Start () {
        if (isLocalPlayer)
        {
            if (!isClient)
            {
                GameObject.Find("Main Camera").gameObject.transform.parent = p1.transform;
                isP1 = true;
            }
            else if (isClient)
            {
                GameObject.Find("Main Camera").gameObject.transform.parent = p2.transform;
                isP1 = false;
                isP2 = true;
            }
            
        }
        rb = paddle.GetComponent<Rigidbody>();
        if (isServer)
        {
            paddlePos = new Vector3(0, 0, -7.5f);
        }
        else if (!isServer)
        {
            paddlePos = new Vector3(0, 0, 6.7f);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        if (isServer)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");
            float xPos = transform.position.x + (horizontalMove * speed);
            float yPos = transform.position.y + (verticalMove * speed);
            paddlePos = new Vector3(Mathf.Clamp(xPos, 0.6f, 3.4f), Mathf.Clamp(yPos, -1.2f, 1.26f), paddlePos.z);
            transform.position = paddlePos;
        }
        else if (isClient)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            verticalMove = Input.GetAxis("Vertical");
            float xPos = transform.position.x + (-horizontalMove * speed);
            float yPos = transform.position.y + (verticalMove * speed);
            paddlePos = new Vector3(Mathf.Clamp(xPos, 0.6f, 3.4f), Mathf.Clamp(yPos, -1.2f, 1.26f), paddlePos.z);
            transform.position = paddlePos;
        }

    }
}
