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
        score = GetComponent<Text>();
        time = GetComponent<Text>();
        string x = HaluMeter.instance.textScore.text;
        if (HaluMeter.instance.textScore.text == null)
            Debug.Log("a");
        score.text = x;
        time.text = HaluMeter.instance.textTime.text;
    }

    
}
