using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform;
    [SerializeField] private float _fallLimit = 2.8f; // top bu limitten aşağı düşerse oyun biter

    [SerializeField] private GameObject _ball; // top objesini tutar
    [SerializeField] private Camera _camera;
    
    private bool _isFinishGame = false; // oyun bitti mi
    private ScoreManager _scoreManager;
    private GameOverPanelManager _gameOverPanelManager;
    private BallCreater _ballCreater;

    private bool _runMethod = false; // methodun bir kere çalışmasını sağlar

    private AudioSource[] _audioSource;
    
    private void Awake()
    {
        _scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        _gameOverPanelManager = GameObject.FindObjectOfType<GameOverPanelManager>();
        _ballCreater = GameObject.FindObjectOfType<BallCreater>();
        _audioSource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ControlBallFall();
        if (_isFinishGame)
        {
            if (!_runMethod) // method daha önce çalışmadı ise
            {
                _audioSource[1].Play();
               _scoreManager.SavePlayedTimesAndBestScoreAndCoinCount(); //  oyun bilgilerini kaydet
               _runMethod = true;
            }
            StopGame(); // oyunu durdur
            _gameOverPanelManager.SetGameInfo();
            _gameOverPanelManager.OpenGameOverPanel(); // GameOver paneli aç
            //List<String> list = new List<String>();
            //list.Add("black");
            //SaveSystem.SavePlayer(0,1000,0, "black", list);
            
        }
    }

    /**
     * Top belli bir miktar aşağı düşerse oyun biter
     */
    private void ControlBallFall()
    {
        if (_ballTransform.position.y < _fallLimit)
        {
            _isFinishGame = true;
        }
    }

    /**
     * Oyun bittiğinde top hareketi durur
     * Oyun bittiğinde platform oluşturma hareketi durur
     * Oyun bittiğinde kamera takibi durur
     */
    private void StopGame()
    {
        _ball.GetComponent<BallController>().enabled = false;
        _ballCreater.CancelInvokeForInvokeInstantiateBallAndInvokeSetActiveKinematicForPlatform();
        _camera.GetComponent<CameraFollow>().enabled = false;
    }

}
