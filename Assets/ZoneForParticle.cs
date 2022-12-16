using System;
using System.Collections;
using UnityEngine;

public class ZoneForParticle : MonoBehaviour
{
    [SerializeField] private GameObject rain;
    [SerializeField] private GameObject[] massRain;
    [SerializeField] private Transform player;

    private GameObject _test;
    private Vector3 _playerPos;
    private bool _isSpawn;
    private int _countRain;
    
    public float posXFromPlayer;
    public float posYFromWorld;
    public float weatherSpeed;
    public float timeForspawn;

    private void Update()
    {
        _playerPos = player.transform.position;
        if (_test != null)
        {
            _test.transform.Translate(new Vector3(-weatherSpeed*Time.deltaTime,0));
            if (!_isSpawn)
            {
                _isSpawn = true;
                StartCoroutine(WaitSpawn());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            CreateWeather();
        }
    }

    private void SetMassElement()
    {
        if (_countRain < massRain.Length)
        {
            if (massRain[_countRain] != null) Destroy(massRain[_countRain]);
            massRain[_countRain] = _test;
            _countRain++;
        }
        else
        {
            _countRain = 0;
            if (massRain[_countRain] != null) Destroy(massRain[_countRain]);
            massRain[_countRain] = _test;
            _countRain++;
        }
    }
    private void CreateWeather()
    {
        _test = Instantiate(rain, new Vector3(_playerPos.x+posXFromPlayer,posYFromWorld),Quaternion.Euler(new Vector3(-90f,0)));
        SetMassElement();
        _isSpawn = false;
    }

    private IEnumerator WaitSpawn()
    {
        yield return new WaitForSeconds(timeForspawn);
        CreateWeather();
    }
}