using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Bu script diamond objesi içine atılır
 */
public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<BallController>())
        {
            GameObject.FindObjectOfType<ScoreManager>().AddScore(1);
            Destroy(gameObject);
        }
    }
}
