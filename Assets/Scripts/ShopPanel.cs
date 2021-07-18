using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{

    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Text _coinText;

    [SerializeField] private GameObject _ball;
    private Material m_materailBall;

    private PlayerData _playerData;
    
    private void Awake()
    {
        m_materailBall = _ball.GetComponent<Renderer>().material;
        FetchPlayerData();
        SetGameInfoToUI();
        SetInActiveImageRespectToBoughtColors();
    }

    /**
     * Start paneli açar
     */
    public void GotoStartPanel()
    {
        _shopPanel.SetActive(false);
        _startPanel.SetActive(true);
    }

    /**
     * Oyun bilgilerini ui lara yerleştirir
     */
    private void SetGameInfoToUI()
    {
        FetchPlayerData();
        _coinText.text = _playerData.coin.ToString();
        _shopPanel.GetComponent<Transform>().Find(_playerData.color).GetComponent<Button>().GetComponent<Image>().color = Color.gray;
    }

    public void BuyNewBall()
    {
        if (IsEnoughCoin())
        {
            BuyBall();
        }
    }

    private void BuyBall()
    {
        DecreaseCoinAndUpdateColor();
        
    }

    /**
     * Coin sayısı yeterli mi
     */
    private bool IsEnoughCoin()
    {
        int coinNum = SaveSystem.LoadPlayer().coin;
        if (coinNum >= 100)
            return true;

        return false;
    }

    /**
     * Coin sayısını azaltır
     */
    private void DecreaseCoinAndUpdateColor()
    {
        String color = EventSystem.current.currentSelectedGameObject.name;
        CloseBuyImage(color);
        UpdateOldColorBackground(_playerData.color);
        AddBoughColor(color);
        UpdateBallColor(color);
        int coinNum = _playerData.coin - 100;
        SaveSystem.SavePlayer(_playerData.playedTimes,coinNum,_playerData.bestScore, color, _playerData.boughtColors);
        
        SetGameInfoToUI();
    }

    /**
     * Satın alınmadan sonra coin resmi olan yer kapatılır
     */
    private void CloseBuyImage(String color)
    {
        _shopPanel.GetComponent<Transform>().Find(color).GetComponent<Button>().GetComponent<Transform>().Find(color)
            .GetComponent<Button>().gameObject.SetActive(false);
    }

    /**
     * Eski seçilmeyen topun arka planını beyaz yapar
     */
    private void UpdateOldColorBackground(String color)
    {
        _shopPanel.GetComponent<Transform>().Find(color).GetComponent<Button>().GetComponent<Image>().color = Color.white;
    }

    /**
     * Gerekli yerlerde hafızadan bilgiler okunması için
     */
    private void FetchPlayerData()
    {
        _playerData = SaveSystem.LoadPlayer();
    }

    /**
     * Yeni renk alındıkça player data güncellenir
     */
    private void AddBoughColor(String color)
    {
        _playerData.boughtColors.Add(color);
        Debug.Log(_playerData.boughtColors.Count);
        SaveSystem.SavePlayer(_playerData.playedTimes, _playerData.coin, _playerData.bestScore, _playerData.color, _playerData.boughtColors);
    }

    /**
     * Hangi toplar alındı onu ui da arkaplanlarını düzenler
     */
    private void SetInActiveImageRespectToBoughtColors()
    {
        List<String> colors = _playerData.boughtColors; 
        if (colors != null)
        {
            foreach (String color in colors)
            {
                if(color != "black") // siyah topta satın alma resmi yok. Eğer oraya girerse null verir
                CloseBuyImage(color);
            }
        }
    }

    /**
     * Satın alınmadan sonra top rengini değiştirir
     */
    private void UpdateBallColor(String color)
    {
        SelectBallColor selectBallColor = new SelectBallColor();
        m_materailBall.color = selectBallColor.GetBallColor(color);
    }

    /**
     * Satın alınan toplar arasından seçim yapar
     * Ve seçilen topun backgroundını gri yapar
     */
    public void SelectNewBall()
    {
        String color = EventSystem.current.currentSelectedGameObject.name;
        UpdateBallColor(color);
        UpdateOldColorBackground(_playerData.color);
        _shopPanel.GetComponent<Transform>().Find(color).GetComponent<Button>().GetComponent<Image>().color = Color.grey;
        SaveSystem.SavePlayer(_playerData.playedTimes, _playerData.coin, _playerData.bestScore, color, _playerData.boughtColors);
        SetGameInfoToUI();
    }
    
    
    
}
