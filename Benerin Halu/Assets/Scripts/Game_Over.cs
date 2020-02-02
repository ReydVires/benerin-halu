using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] 
    public Text score;
    [SerializeField] 
    public Text time;
    void Start()
    {
        score.text = HaluMeter.instance._score.ToString();
        time.text = HaluMeter.instance._timePlay.ToString();
    }

    private void Update()
    {
        score.text = HaluMeter.instance._score.ToString();
        time.text = HaluMeter.instance._timePlay.ToString();
    }


}
