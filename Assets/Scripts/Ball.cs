using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType { myBall, opponentBall };

    Rigidbody rigidBody;

    public float moveSpeed = 10f;
    public float thrust = 10f;
    public int MaxBounce = 3;
    // Start is called before the first frame update
    private GameObject closestTower;
    private GameObject[] allTowers;
    private float BounceCount;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //rigidBody.AddForce(transform.forward * thrust);
        transform.position = new Vector3(transform.position.x, 0.16f, transform.position.z);
        rigidBody.constraints = RigidbodyConstraints.FreezePositionY;
        BounceCount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 v = rigidBody.velocity;
        //if(v.x*v.x+v.z*v.z< moveSpeed*moveSpeed)
        //rigidBody.AddForce(transform.forward * thrust);

        //rigidBody.velocity = new Vector3(1f,0,1f) * moveSpeed; b
        if (transform.position.y < 0.16)
            transform.position = new Vector3(transform.position.x, 0.16f, transform.position.z);
        
        rigidBody.MovePosition(transform.position + transform.forward * moveSpeed * Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            BounceCount = 0;
            ContactPoint contactPoint = collision.GetContact(0);
            Vector3 newDir = Vector3.zero;
            Vector3 curDir = transform.TransformDirection(Vector3.forward);
            newDir = Vector3.Reflect(curDir, contactPoint.normal);
            Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
            
            //Debug.Log(newDir.x+"   "+ newDir.z);
            transform.rotation = rotation;
        }
        if (collision.gameObject.tag == "Wall")
        {
            BounceCount++;
            if (BounceCount < MaxBounce)
            {
                
                ContactPoint contactPoint = collision.GetContact(0);
                Vector3 newDir = Vector3.zero;
                Vector3 curDir = transform.TransformDirection(Vector3.forward);
                newDir = Vector3.Reflect(curDir, contactPoint.normal);
                Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
                //Debug.Log(newDir.x+"   "+ newDir.z);
                transform.rotation = rotation;
                Debug.Log("YES");
            }
            else
            {
                BounceCount = 0;
                FindClosestTower();
            }
            
        }
                
    }

    void FindClosestTower()
    {
        float distanceToClosestTower = Mathf.Infinity;
        closestTower = null;
        allTowers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject currentTower in allTowers)
        {
            float distanceToTower = (currentTower.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToTower < distanceToClosestTower)
            {
                distanceToClosestTower = distanceToTower;
                closestTower = currentTower;
            }
        }
        Debug.Log(closestTower.transform.position);
        Vector3 direction = closestTower.transform.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
