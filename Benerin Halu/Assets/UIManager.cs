using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image left, right;
    public float timeToHide;
    private float _timeToHide;
    public float timeToShow;
    private float _timeToShow;
    bool _isHide;
    int _counter;

    private void Start()
    {
        _timeToHide = timeToHide;
        _timeToShow = timeToShow;
        _isHide = false;
        _counter = 0;
    }
    private void FixedUpdate()
    {
        if (_counter >= 5)
            return;
        if (!_isHide)
        {
            _timeToShow -= Time.fixedDeltaTime;
            if (_timeToShow <= 0)
            {
                _timeToShow = timeToShow;
                _isHide = true;
                ActiveGameObjectImage(true);
            }
        }
        else
        {
            _timeToHide -= Time.fixedDeltaTime;
            if (_timeToHide <= 0)
            {
                _timeToHide = timeToHide;
                _isHide = false;
                _counter++;
                ActiveGameObjectImage(false);
            }
        }

    }

    void ActiveGameObjectImage(bool active)
    {
        left.gameObject.SetActive(active);
        right.gameObject.SetActive(active);
    }
}
