using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Sprite potrait;
    public GameObject panelImage;
    public GameObject peopleObject;
    private People _people;

    void Start()
    {
        
        //text = GetComponent<Text>();
        //text.text = EntitasDetail.title;
        potrait = EntitasDetail.potrait;
        panelImage.GetComponent<Image>().sprite = potrait;
        peopleObject = EntitasDetail.go;
        _people = peopleObject.GetComponent<People>();
    }

    public void rehabilitate()
    {
        var isRehabilitated = _people.sanityMeter >= 11;
        if (isRehabilitated)
        {
            HaluMeter.AddingHaluMeter(-15);
            //DelayAddHaluMeter(0.5f, -15);
        }
        else
        {
            HaluMeter.AddingHaluMeter(5);
            //DelayAddHaluMeter(0.5f, 5);
        }
        _people.RehabilityFeedback(isRehabilitated);
    }

    //IEnumerator DelayAddHaluMeter(float sec, int value)
    //{
    //    yield return new WaitForSeconds(sec);
    //    HaluMeter.AddingHaluMeter(value);
    //}

}
