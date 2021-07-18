using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Bu script Ball objesi içine atılır
 */
public class StartPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject _coinTable; // coin sayısını tutar
    [SerializeField] private GameObject _stepCount; // ilerleme sayısını tutar

    [SerializeField] private GameObject _shopPanel;
    
    private BallCreater _ballCreater;
    private AudioSource[] _soundSource;
    private void Awake()
    {
        _ballCreater = GameObject.FindObjectOfType<BallCreater>();
        _soundSource = GetComponents<AudioSource>();
    }

    /**
     * Button bastığımızda oyunu başlatır
     */
    public void StartGame()
    {
        _soundSource[1].Play();
        ActiveBallController();
        _coinTable.SetActive(true);
        _stepCount.SetActive(true);
        ClosePanel();
        _ballCreater.InvokeInstantiateBall(); // platform eklenir
        _ballCreater.InvokeSetActiveKinematicForPlatform(); // platformların kinematicleri aktif edilir
    }
    
    /**
     * StartPaneli kapatır
     */
    private void ClosePanel()
    {
        startPanel.SetActive(false);
    }

    /**
     * BallController scriptini aktif eder
     */
    private void ActiveBallController()
    {
        gameObject.GetComponent<BallController>().enabled = true;
    }

    /**
     * Shop paneli açar
     */
    public void GotoShopPanel()
    {
        startPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }

}