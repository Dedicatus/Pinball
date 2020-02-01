using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigidBody;

    public float moveSpeed = 10f;
    public float thrust = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * thrust);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
