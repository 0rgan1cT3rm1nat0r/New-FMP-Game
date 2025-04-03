using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject arrowPrefab;

    public void FireProjectile()
    {
        Instantiate(arrowPrefab, transform.position, arrowPrefab.transform.rotation);
    }
}
