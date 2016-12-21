using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
    float timer = 10;
    bool isIncreased;
    bool isShrunk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void Increase(GameObject paddle)
    {
        
        paddle.transform.localScale += new Vector3(1, 1, 0);
    }
    public void Shrink(GameObject paddle)
    {
        paddle.transform.localScale -= new Vector3(1, 1, 0);
    }
    public void Speed(Ball ball)
    {
        
    }
    public void GrowReset(GameObject paddle)
    {
        

    }
    void ShrinkReset(GameObject paddle)
    {
        paddle.transform.localScale += new Vector3(1, 1, 0);
    }
    void SpeedReset()
    {

    }
}
