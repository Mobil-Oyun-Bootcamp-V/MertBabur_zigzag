using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/**
 * Ball içine into atılmalı
 * Ball ChangeDirection butonuna koyulmalı
 */
public class BallController : MonoBehaviour
{

    [SerializeField] private float _ballSpeed = 1f; // top hızını tutar
    [SerializeField] private Vector3 direction = Vector3.forward;

    private AudioSource[] _soundSource;

    private void Awake()
    {
        _soundSource = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBall();
    }

    /**
     * Top hareketini sağlar
     */
    private void MoveBall()
    {
        transform.position += direction * _ballSpeed * Time.deltaTime;
    }

    /**
     * Ekrana her tıklamadan topun hareket yönünü değiştirir
     */
    public void IdentifyDirection()
    {
        if(direction == Vector3.forward)
            direction = Vector3.right;
        else if(direction == Vector3.right)
            direction = Vector3.forward;
        Debug.Log(Random.Range(0, 2));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Collectible>())
        {
            _soundSource[0].Play();
        }
    }

}
