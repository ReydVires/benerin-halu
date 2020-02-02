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
    public AudioSource sfx;
    public AudioClip berhasil;
    public AudioClip failed;

    public string message;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
        //text = GetComponent<Text>();
        //text.text = EntitasDetail.title;
        potrait = EntitasDetail.potrait;
        message = EntitasDetail.message;
        panelImage.GetComponent<Image>().sprite = potrait;
        peopleObject = EntitasDetail.go;
        _people = peopleObject.GetComponent<People>();
        Debug.Log(message);
        Fungus.Flowchart.BroadcastFungusMessage(message);
        FindObjectOfType<Fungus.Flowchart>().SetFloatVariable("halu", _people.sanityMeter);
        //Fungus.FloatData.
    }

    public void rehabilitate()
    {
        var isRehabilitated = _people.sanityMeter >= 11;
        if (isRehabilitated)
        {
            HaluMeter.AddingHaluMeter(-15);
            sfx.PlayOneShot(berhasil);
            //DelayAddHaluMeter(0.5f, -15);
        }
        else
        {
            sfx.PlayOneShot(failed);
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
