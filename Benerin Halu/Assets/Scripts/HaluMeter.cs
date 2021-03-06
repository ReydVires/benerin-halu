﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaluMeter : MonoBehaviour
{
    public static HaluMeter instance;
    public static Queue<float> sanityPeople;
    [SerializeField]
    private Image bar;
    private float _value;
    public float timeHalu = 1f;
    [SerializeField]
    private float _addingHalu;
    private float _timeHalu = 1;
    [SerializeField]
    private Slider _haluMeter;
    [SerializeField]
    private float _maxHalu;

    public Text textTime;
    public float _timePlay;

    public Text textScore;
    public long _score;

    public bool _isGameOver;

    public GameObject panelGameOver;

    private Color[] indicators ={new Color(0,255,0,255), new Color(236, 255, 0, 255), new Color(255, 0, 0, 255) };

    private void Awake()
    {
        instance = this;
        sanityPeople = new Queue<float>();
        _isGameOver = false;
    }

    void Start()
    {
        _score = 0;
        _timePlay = 0;
        _value = 0;
        _haluMeter.value = 0;
        _haluMeter.maxValue = _maxHalu;
        _timeHalu = timeHalu;
        addingScore(0);
    }

    void Update()
    {
        if (_isGameOver)
        {
            Time.timeScale = 0;
            panelGameOver.SetActive(true);
            return;
        }
        _timeHalu -= Time.deltaTime;
        _timePlay += Time.deltaTime;
        SetTimeText(Mathf.RoundToInt(_timePlay));
        if(_timeHalu <= 0)
        {
            _timeHalu = timeHalu;
            //AddingHaluMeter(_addingHalu);
        }
        if (sanityPeople.Count == 0)
            return;
        _value = Mathf.Clamp(_value + sanityPeople.Dequeue(), 0, 300);
        _haluMeter.value = _value;
        ChangeColors(_value);
        _isGameOver = (_value >= _maxHalu);
    }

    void ChangeColors(float val)
    {
        if (val < _maxHalu / 3)
        {
            bar.color = indicators[0];
        }
        if (val < (_maxHalu / 3) * 2 && val > _maxHalu/3)
        {
            bar.color = indicators[1];
        }
        if (val > (_maxHalu / 3) * 2)
        {
            bar.color = indicators[2];
        }
    }
    
    public static void AddingHaluMeter(float halu)
    {
        sanityPeople.Enqueue(halu);
    }

    public void addingScore(long point)
    {
        _score += point;
        textScore.text = _score.ToString();
    }

    void SetTimeText(int time)
    {
        textTime.text = string.Format("{0:00} : {1:00}", time / 60, time % 60);
    }
}
