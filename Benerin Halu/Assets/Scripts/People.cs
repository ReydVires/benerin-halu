using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour, IMoveable
{
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

    public void Move()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("A");
        HaluMeter.AddingHaluMeter(5);
    }
}
