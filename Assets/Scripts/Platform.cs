using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    private ScoreManager _scoreManager;
    private List<Color> colors;

    private void Awake()
    {
        colors = new List<Color>();
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        colors.Add(new Color(143, 161, 0));
        colors.Add(new Color(143, 161, 203));
        colors.Add(new Color(218, 119, 203));
        colors.Add(new Color(218, 119, 85));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void ChangeColor()
    {
        int stepCount = _scoreManager._stepCount;
        if (stepCount == 5)
        {
            int num = Random.Range(0,5);
            gameObject.GetComponent<Renderer>().material.color = colors[num];

        }
    }
}
