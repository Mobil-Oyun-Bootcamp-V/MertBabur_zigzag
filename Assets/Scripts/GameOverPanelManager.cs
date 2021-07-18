using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private Text _stepCount;
    [SerializeField] private Text _bestStepCount;

    private ScoreManager _scoreManager;

    private AudioSource[] _audioSource;

    private void Awake()
    {
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        _audioSource = GetComponents<AudioSource>();
    }

    /**
     * GameOver paneli açar
     */
    public void OpenGameOverPanel()
    {
        _gameOverPanel.SetActive(true);
    }

    /**
     * Oyunu tekrar başlatır
     */
    public void RetryGame()
    {
        _audioSource[0].Play();
        _levelManager.RestartScene();
    }
    
    /**
     * Oyun bilgilerini gerekli ui lara yerleştirir
     */
    public void SetGameInfo()
    {
        _stepCount.text = _scoreManager._stepCount.ToString();
        _bestStepCount.text = SaveSystem.LoadPlayer().bestScore.ToString();
    }
    
    
    
}
