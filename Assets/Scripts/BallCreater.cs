using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class BallCreater : MonoBehaviour
{
    [SerializeField] private GameObject _bigPlatform;
    [SerializeField] private GameObject _lastPlatform;
    [SerializeField] private GameObject _coin;

    [SerializeField] private float _destroyPlatformTime = 1f; // platform yok etme zamanı 
    [SerializeField] private float _instantiateBallTime = 2f; // platform oluşturma zamanı
    [SerializeField] private float _instantiateBallRepeatRate = 2f; // platform oluşturma tekrarlama zamanı
    [SerializeField] private float _setActiveKinematicForPlatformTime = 2f; // platform kinematic aktif etme zamanı
    [SerializeField] private float _setActiveKinematicForPlatformRepeatRate = 2f; // platform kinematic aktif etme tekrarlama zamanı
    
    private Queue<GameObject> _platformList = new Queue<GameObject>(); // oluşturulan platformları tutar
    private GameObject _destroyPlatform; // destroy edilecek platformu tutar
    
    
    private void Awake()
    {
        _platformList.Enqueue(_bigPlatform);
        _platformList.Enqueue(_lastPlatform);
        
        InstantiateBall20();
        
        //InvokeRepeating(nameof(InstantiateBall), _instantiateBallTime, _instantiateBallRepeatRate);
        //InvokeRepeating(nameof(SetActiveKinematicForPlatform), _setActiveKinematicForPlatformTime, _setActiveKinematicForPlatformRepeatRate);

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    /**
     * Yeni platform eklenir
     */
    private void InstantiateBall()
    {
        int whichDirection = Random.Range(0, 2); // 0 --> sağ(x) , 1 --> ön(y)

        if (whichDirection == 0) // sağa doğru platform ekleme
        {
            _lastPlatform = Instantiate(_lastPlatform, _lastPlatform.transform.position + Vector3.right * 5, _lastPlatform.transform.rotation);
            if (Probability())
            {
                _lastPlatform.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                _lastPlatform.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else if (whichDirection == 1) // sola doğru platform ekleme
        {
            _lastPlatform = Instantiate(_lastPlatform, _lastPlatform.transform.position + Vector3.forward * 5, _lastPlatform.transform.rotation);
            if (Probability())
            {
                _lastPlatform.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                _lastPlatform.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        
        _platformList.Enqueue(_lastPlatform);
    }

    /**
     * Oyun başında 20 adet platform ekler
     */
    public void InstantiateBall20()
    {
        for (int i = 0; i < 20; i++)
        {
            InstantiateBall();
        }
            
    }

    /**
     * Platfornların kinetmatickleri false yapılır. Çünkü aşağı doğru düşmesi için
     */
    private void SetActiveKinematicForPlatform()
    {
        GameObject platform = _platformList.Dequeue();
        _destroyPlatform = platform;
        platform.GetComponent<Rigidbody>().isKinematic = false;
        Invoke(nameof(DestroyPlatform), _destroyPlatformTime);
    }
    
    /**
     * Platformu yok eder
     */
    private void DestroyPlatform()
    {
        Destroy(_destroyPlatform);
    }

    private bool Probability()
    {
        int num = Random.Range(0, 5);
        if (num == 4)
            return true;

        return false;
    }

    /**
     * Belli saniyeler ile yeni platformlar oluşturulur
     */
    public void InvokeInstantiateBall()
    {
        InvokeRepeating(nameof(InstantiateBall), _instantiateBallTime, _instantiateBallRepeatRate);
    }

    /**
     * Belli saniyler ile yeni platformların kinematicleri false edilir
     */
    public void InvokeSetActiveKinematicForPlatform()
    {
        InvokeRepeating(nameof(SetActiveKinematicForPlatform), _setActiveKinematicForPlatformTime, _setActiveKinematicForPlatformRepeatRate);

    }

    /**
     * InvokeRepating leri kapatır
     */
    public void CancelInvokeForInvokeInstantiateBallAndInvokeSetActiveKinematicForPlatform()
    {
        CancelInvoke(nameof(InstantiateBall));
        CancelInvoke(nameof(SetActiveKinematicForPlatform));
    }
    
}
