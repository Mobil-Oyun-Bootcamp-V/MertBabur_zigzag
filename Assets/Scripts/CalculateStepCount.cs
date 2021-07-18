using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Bu script Ball objesi içine atılır
 */
public class CalculateStepCount : MonoBehaviour
{
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.GetComponent<Platform>())
        {
            GameObject.FindObjectOfType<ScoreManager>().AddStep(1);
        }
    }
}
