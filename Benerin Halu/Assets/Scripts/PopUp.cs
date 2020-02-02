using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text text;
    public Sprite potrait;
    public GameObject panelImage;
    public string message;
    // Start is called before the first frame update
    void Start()
    {
        
        text = GetComponent<Text>();
        text.text = EntitasDetail.title;
        potrait = EntitasDetail.potrait;
        message = EntitasDetail.message;
        panelImage.GetComponent<Image>().sprite = potrait;
        Debug.Log(message);
        Fungus.Flowchart.BroadcastFungusMessage(message);
        FindObjectOfType<Fungus.Flowchart>().SetFloatVariable("halu", 10);
        //Fungus.FloatData.
    }

    // Update is called once per frame
        
}
