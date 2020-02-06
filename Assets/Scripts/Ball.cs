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
        //rigidBody.AddForce(transform.forward * thrust);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 v = rigidBody.velocity;
        //if(v.x*v.x+v.z*v.z< moveSpeed*moveSpeed)
        //rigidBody.AddForce(transform.forward * thrust);

        //rigidBody.velocity = new Vector3(1f,0,1f) * moveSpeed;
        rigidBody.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 newDir = Vector3.zero;
            Vector3 curDir = transform.TransformDirection(Vector3.forward);
            newDir = Vector3.Reflect(curDir, contactPoint.normal);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
            Debug.Log(newDir.x+"   "+ newDir.z);
            transform.rotation = rotation;
        }
    }
}
