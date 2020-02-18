using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    public float ballThrust = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fire()
    {
        Vector3 newDir = new Vector3(0f,0,0f);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
        Instantiate(ball, transform.position, rotation);
        //ball.GetComponent<Rigidbody>().AddForce(new Vector3(0,1f,0) * ballThrust);
    }
}
