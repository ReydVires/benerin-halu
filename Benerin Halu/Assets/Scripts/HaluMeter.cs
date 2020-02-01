using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaluMeter : MonoBehaviour
{
    public static Queue<float> sanityPeople;

    private float _value;
    public float timeHalu = 1f;
    [SerializeField]
    private float _addingHalu;
    private float _timeHalu = 1;
    [SerializeField]
    private Slider _haluMeter;
    [SerializeField]
    private float _maxHalu;

    private void Awake()
    {
        sanityPeople = new Queue<float>();
    }

    void Start()
    {
        _value = 0;
        _haluMeter.value = 0;
        _haluMeter.maxValue = _maxHalu;
        _timeHalu = timeHalu;
    }

    void Update()
    {
        _timeHalu -= Time.deltaTime;
        if(_timeHalu <= 0)
        {
            _timeHalu = timeHalu;
            AddingHaluMeter(_addingHalu);
        }
        if (sanityPeople.Count == 0)
            return;
        _value = _value + sanityPeople.Dequeue();
        _haluMeter.value = _value;
    }

    
    public static void AddingHaluMeter(float halu)
    {
        sanityPeople.Enqueue(halu);
    }
}
