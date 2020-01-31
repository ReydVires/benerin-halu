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

    public GameObject spawnPoint;
    private Transform[] _spawnPoint;

    /*Collider2D myCollider;
    BoxCollider2D myBoxCollider;*/
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        
        _spawnPoint = new Transform[spawnPoint.transform.childCount];
        int i = 0;
        foreach (Transform child in spawnPoint.transform)
        {
            _spawnPoint[i++] = child;
        }

        Initialize();
        
        /*myCollider = GetComponent<Collider2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();*/
    }

    public void Initialize()
    {
        gameObject.active = true;
        accel = Random.Range(minAccel, maxAccel);
        int idx = Random.RandomRange(0, _spawnPoint.Length);
        if(idx < 2)
        {
            facing = 1;
        }
        else
        {
            facing = -1;
        }
        transform.position = _spawnPoint[idx].position + Vector3.up * Random.Range(-1f,1f);
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


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("B");
        if (collision.gameObject.tag == "SafeZone")
        {
            DummyScript.deadEntity.Enqueue(gameObject);
            gameObject.active = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Lebih Cinta Koding");
    }

}
