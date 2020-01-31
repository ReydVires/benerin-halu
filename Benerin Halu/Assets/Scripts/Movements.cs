using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    //cache
    public float moveSpeed = 5f;
    float facing = 1f;
    float accel = 1f;
    float minAccel = 1f;
    float maxAccel = 3f;
    float minTreshold = 50f;
    float maxThreshold = 100f;
    Rigidbody2D myRigidBody;
    public float dirThreshold = 50f;
    float posY = 0f;
    /*Collider2D myCollider;
    BoxCollider2D myBoxCollider;*/
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        facing = ChangeDirection();
        accel = Random.Range(minAccel, maxAccel);
        /*myCollider = GetComponent<Collider2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }*/
        
        myRigidBody.velocity = new Vector2(facing * moveSpeed * accel, 0f);
        dirThreshold -= Time.deltaTime * 30;
        if (dirThreshold < 0)
        {
            facing = ChangeDirection();
            Debug.Log(facing);
            dirThreshold = Random.Range(minTreshold, maxThreshold);
            accel = Random.Range(minAccel, maxAccel);
        }
    }
    private float ChangeDirection()
    {
        return Mathf.Round(Random.Range(-1, 2));
        
    }
    /*bool isFacingRight()
    {
        return facing < 0;
    }*/
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
