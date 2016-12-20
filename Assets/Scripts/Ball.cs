using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    [SerializeField]
    float forceValue = 4.5f;

    public Transform BallObject;
    

    Rigidbody rb;
    bool isMoving = false;
    private Vector3 velo;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	// Update is called once per frame
	void Update () {
        if (isMoving == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isMoving = true;
                StartBall();
            }
        }

	}
    void FixedUpdate()
    {
        velo = rb.velocity;
    }
    void StartBall()
    {
        float rand = Random.Range(0.0f, 2.0f);
        if (rand < 1.0f)
        {
            rb.velocity = new Vector3(0, 0, forceValue);
        }
        else
        {
            rb.velocity = new Vector3(0,0,-forceValue);
        }
    }
    void ResetBall()
    {
        velo = new Vector3(0f,0f,0f);
        rb.velocity = velo;
        isMoving = false;
        gameObject.transform.position = new Vector3(2, 0, 0);
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {


            Vector3 dir = coll.contacts[0].point - coll.transform.position;
            dir = -dir.normalized * forceValue;
            rb.velocity = new Vector3(velo.x - dir.x, velo.y - dir.y, -velo.z);
        }

        else if (coll.collider.CompareTag("ScoreZone"))
        {
            Debug.Log("Score");
            ResetBall();
        }
    }
}
