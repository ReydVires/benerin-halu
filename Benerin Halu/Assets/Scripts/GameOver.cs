using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text score;
    [SerializeField] Text time;
    void Start()
    {
        score = GetComponent<Text>();
        time = GetComponent<Text>();
        score.text = HaluMeter.instance.textScore.text;
        time.text = HaluMeter.instance.textTime.text;
    }
}
