using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] private int totalHealth = 3;

    private int curHealth;

    private int attack = 5;

    private Vector3Int location;

    public Image HealthBar;

    public PlacementController placementController;

    private void Start()
    {
        curHealth = totalHealth;
        placementController = transform.parent.parent.GetComponent<PlacementController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            --curHealth;

            HealthBar.fillAmount = (float) curHealth / totalHealth;
            if (curHealth <= 0)
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
