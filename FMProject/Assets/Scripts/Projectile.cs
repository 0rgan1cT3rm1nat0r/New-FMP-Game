using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    private Transform target;
    private float moveSpeed;

    private void Update()
    {
        Vector3 moveDirNormalized = (target.position - transform.position).normalized;
        transform.position += moveDirNormalized * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 1f)
        {
            Destroy(gameObject);
        }
    }

    public void InitializeProjectile(Transform targert, float moveSpeed)
    {
        this.target = targert;
        this.moveSpeed = moveSpeed;
    }
}
