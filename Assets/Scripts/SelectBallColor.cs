using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBallColor : MonoBehaviour
{
    /**
     * İstenen top rengini döner
     */
    public Color GetBallColor(String color)
    {
        switch (color)
        {
            case "black":
                return Color.black;
            case "red":
                return Color.red;
            case "pink":
                return Color.magenta;
            case "green":
                return Color.green;
            case "blue":
                return Color.cyan;
            case "brown":
                return Color.gray;
                
        }
        
        return Color.black;
    }
    
}
