using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class People : MonoBehaviour
{
    public string nama;
    public float speed;
    public int sanityMeter;
    public Movements movements;
    Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        sanityMeter = Random.Range(1, 4);
    }


    void Update()
    {
        //Debug.Log(movements.facing);
        
        movements.move(speed);
        anim.SetFloat("XPos", movements.facing);
        
    }

    private void OnMouseDown()
    {
        if (!EntitasDetail.inspectPopUp)
        {
            EntitasDetail.title = nama;
            FindObjectOfType<ScenesController>().popUp();
        }
    }
}
