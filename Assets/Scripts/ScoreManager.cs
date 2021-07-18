using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Bu script GameManager objesi içine atılır 
 */
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] public int _score = 0;
    [SerializeField] private Text _stepCountText;
    [SerializeField] public int _stepCount = 0;
    public int _scoreForLevel; // o level'da kac coin toplandigini tutar.

    
    private void Start()
    {
        LoadCoinQuantity();
    }

    /**
     * Her elmas aldığımızda score amount kadar artar
     */
    public void AddScore(int amount)
    {
        _score += amount;
        //_scoreForLevel += amount;
        _scoreText.text = _score.ToString("N0");
    }

    /**
     * Her platformdan geçildiğinde 1 stepCount artar
     */
    public void AddStep(int amount)
    {
        _stepCount += amount;
        _stepCountText.text = _stepCount.ToString("N0");
    }
    
    /**
     * Cihaz hafizasindaki coin sayisini getirir.
     */
    private void LoadCoinQuantity()
    {
        _score = SaveSystem.LoadPlayer().coin;
        _scoreText.text = _score.ToString();
    }

    /**
     * Oynanma sayısı, coin sayısı ve best score u kaydeder
     */
    public void SavePlayedTimesAndBestScoreAndCoinCount()
    {
        int playedTimes = SaveSystem.LoadPlayer().playedTimes;
        playedTimes += 1;
        Debug.Log(playedTimes + " : sdfsdfsdfdsfsdf");

        int bestScore = SaveSystem.LoadPlayer().bestScore;
        bestScore = UpdateBestScore(bestScore);
        
        SaveSystem.SavePlayer(playedTimes, _score, bestScore, SaveSystem.LoadPlayer().color, SaveSystem.LoadPlayer().boughtColors); /****/
        
    }

    /**
     * BestScore geçildi ise günceller
     */
    private int UpdateBestScore(int bestScore)
    {
        if (bestScore < _stepCount)
            return _stepCount;

        return bestScore;
    }


}