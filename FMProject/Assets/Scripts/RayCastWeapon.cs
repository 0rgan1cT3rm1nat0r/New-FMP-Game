using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{

    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(firePoint.position, firePoint.right, out hitInfo))
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return null; // Use 'null' instead of '0' for yielding a frame.

        lineRenderer.enabled = false;
    }
}