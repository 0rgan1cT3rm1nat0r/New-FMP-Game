using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject Beacon;

    private void Start()
    {
        InvokeRepeating("IHATEDELAY", 0.5f, 0.5f);
    }

    private void IHATEDELAY()
    {
        // Check if the Beacon is either destroyed or deactivated
        if (Beacon == null)
        {
            //Debug.Log("Beacon is null. Changing scene to CutScene...");
            SceneManager.LoadScene("CutScene");
        }
        else
        {
            //Debug.Log("Beacon is still active.");
        }
    }
}
