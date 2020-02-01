using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        
        text = GetComponent<Text>();
        text.text = EntitasDetail.title;
    }

    // Update is called once per frame
        
}
