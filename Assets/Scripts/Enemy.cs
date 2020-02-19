using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int TotalHitPoint = 3;

    private int CurHitPoint;

    private Vector3Int location;

    public Image HealthBar;

    public PlacementController placementController;

    private void Start()
    {
        CurHitPoint = TotalHitPoint;
        placementController = transform.parent.parent.GetComponent<PlacementController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            --CurHitPoint;

            HealthBar.fillAmount = (float) CurHitPoint / TotalHitPoint;
            if (CurHitPoint <= 0)
            {
                Destroy(transform.parent.gameObject);
                placementController.resetLocation(location.x, location.z);
            }
        }
    }

    public void RecordLocation(int x, int z)
    {
        location.x = x;
        location.z = z;
    }
}
