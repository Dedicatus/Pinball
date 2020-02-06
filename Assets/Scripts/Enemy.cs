using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hitPoint = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            --hitPoint;
            if (hitPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
