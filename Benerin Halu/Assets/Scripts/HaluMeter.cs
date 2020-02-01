using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaluMeter : MonoBehaviour
{
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

    private Color[] indicators ={new Color(0,255,0,255), new Color(236, 255, 0, 255), new Color(255, 0, 0, 255) };

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
        ChangeColors(_value);
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
}
