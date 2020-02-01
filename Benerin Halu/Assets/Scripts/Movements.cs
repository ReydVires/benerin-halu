using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    float random = 0;
    public float facing = 1f;
    float accel = 1f;
    float minAccel = 1f;
    float maxAccel = 2f;
    float minTreshold = 30f;
    float maxThreshold = 50f;
    Rigidbody2D myRigidBody;
    float dirThreshold = 50f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float facing, Vector3 position)
    {
        gameObject.SetActive(true);
        accel = Random.Range(minAccel, maxAccel);
        this.facing = facing;
        transform.position = position + Vector3.up * Random.Range(-0.15f,0.15f);
    }

    public void move(float speed)
    {
        myRigidBody.velocity = new Vector2(facing * speed * accel, 0f);
        dirThreshold -= Time.deltaTime * 20;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            DummyScript.deadEntity.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }

}
