using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playedTimes;
    public int coin;
    public int bestScore;
    public String color;
    public List<String> boughtColors;
    public PlayerData()
    {
        
    }
    
    public PlayerData(int _playedTimes, int _coin, int _bestScore, String _color, List<String> colors)
    {
        playedTimes = _playedTimes;
        coin = _coin;
        bestScore = _bestScore;
        color = _color;
        boughtColors = colors;
    }

}