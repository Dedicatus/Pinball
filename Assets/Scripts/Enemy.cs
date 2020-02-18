using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int TotalHitPoint = 3;
    private int CurHitPoint;

    public Image HealthBar;

    private void Start()
    {
        CurHitPoint = TotalHitPoint;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            --CurHitPoint;

            HealthBar.fillAmount = (float)CurHitPoint/TotalHitPoint;
            if (CurHitPoint <= 0)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}
