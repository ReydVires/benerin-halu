using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text text;
    public Sprite potrait;
    public GameObject panelImage;
    // Start is called before the first frame update
    void Start()
    {
        
        text = GetComponent<Text>();
        text.text = EntitasDetail.title;
        potrait = EntitasDetail.potrait;
        panelImage.GetComponent<Image>().sprite = potrait;
    }

    // Update is called once per frame
        
}
