using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Bu script GameManager objesi içine atılır
 */
public class GameManager : MonoBehaviour
{
    
    [SerializeField] private Text _coinNumText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _playedTimesText;

    [SerializeField] private GameObject _ball;
    private Material m_materailBall;

    private void Awake()
    {
        SelectBallColor selectBallColor = new SelectBallColor();
        SetGameInfoToText();
        m_materailBall = _ball.GetComponent<Renderer>().material;
        m_materailBall.color = selectBallColor.GetBallColor(SaveSystem.LoadPlayer().color);
    }

    /**
     * Score vs textleri gerekli ui lara ekler
     */
    private void SetGameInfoToText()
    {
        PlayerData playerData = new PlayerData();
        playerData = SaveSystem.LoadPlayer();

        _bestScoreText.text = "BEST SCORE : " + playerData.bestScore.ToString();
        _coinNumText.text = playerData.coin.ToString();
        _playedTimesText.text = "GAMES PLAYED : " + playerData.playedTimes.ToString();
        
    }
}
