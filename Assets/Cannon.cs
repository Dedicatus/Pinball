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
        Vector3 newDir = new Vector3(45f,0,45f);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
        Instantiate(ball, transform.position, rotation);
        ball.GetComponent<Rigidbody>().AddForce(transform.up * ballThrust);
    }
}
