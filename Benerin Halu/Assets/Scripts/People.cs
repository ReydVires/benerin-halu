using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour, IMoveable
{
    public float speed;
    public float sanityMeter;
    Rigidbody2D rb2d;
    Animator anim;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("XPos", 1.0f);
    }

    void Update()
    {
        
    }

    public void Move()
    {
        
    }
}
