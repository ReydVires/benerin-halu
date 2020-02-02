using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    //public Text text;
    public Sprite potrait;
    public GameObject panelImage;
    public GameObject peopleObject;
    private People _people;
    // Start is called before the first frame update
    void Start()
    {
        
        //text = GetComponent<Text>();
        //text.text = EntitasDetail.title;
        potrait = EntitasDetail.potrait;
        panelImage.GetComponent<Image>().sprite = potrait;
        peopleObject = EntitasDetail.go;
        _people = peopleObject.GetComponent<People>();
        if (peopleObject == null)
        {
            Debug.Log("debug log");
        }
    }

    public void rehabilitate()
    {
        if (_people.sanityMeter >= 11)
        {
            HaluMeter.AddingHaluMeter(-15);
            _people.BackToPoll();
        }
        else
        {
            HaluMeter.AddingHaluMeter(5);
        }
    }
    // Update is called once per frame
        
}
