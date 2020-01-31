using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour, IMoveable
{
    public float speed;
    public float sanityMeter;
    Rigidbody2D rb2d;
    public int facing;
    public Animator anim;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        var random = new Random();
        // Error
        facing = random.Next(-1, 1);
        Debug.Log(facing);
    }

    void Update()
    {
        
    }

    public void Move()
    {
        
    }
}
