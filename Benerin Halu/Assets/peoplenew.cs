using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peoplenew : MonoBehaviour, IMoveable
{
    public float speed;
    public int sanityMeter;
    public bool facingRight = true;
    Rigidbody2D rb2d;
    Animator anim;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        initFacing();
        sanityMeter = Random.Range(1, 4);
    }

    void initFacing()
    {
        if (facingRight)
        {
            anim.SetFloat("XPos", 1.0f);
        }
        else
        {
            anim.SetFloat("XPos", -1.0f);
        }
    }

    void Update()
    {
        
    }

    public void Move()
    {
        
    }

    private void OnMouseDown()
    {
        HaluMeter.AddingHaluMeter(5);
    }
}
