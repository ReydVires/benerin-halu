using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    float random = 0;
    public float facing = 1f;
    float accel = 1f;
    float minAccel = 0.5f;
    float maxAccel = 1.5f;
    float minTreshold = 30f;
    float maxThreshold = 50f;
    Rigidbody2D myRigidBody;
    float dirThreshold = 50f;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float facing, Vector3 position, RuntimeAnimatorController animator, Sprite potraits)
    {
        gameObject.SetActive(true);
        accel = Random.Range(minAccel, maxAccel);
        this.facing = facing;
        transform.position = position + Vector3.up * Random.Range(-0.15f,0.15f);
        gameObject.GetComponentInChildren<Animator>().runtimeAnimatorController = animator;
        gameObject.GetComponent<People>().potrait = potraits;
    }

    public void Move(float speed)
    {
        if (myRigidBody != null)
        {
            myRigidBody.velocity = new Vector2(facing * speed * accel, 0f);
        }
        dirThreshold -= Time.deltaTime * Random.Range(3, 18);
        if (dirThreshold < 0)
        {
            facing = ChangeDirection();
            dirThreshold = Random.Range(minTreshold, maxThreshold);
            accel = Random.Range(minAccel, maxAccel);
        }
    }

    private float ChangeDirection()
    {
        return Mathf.Round(Random.Range(1, 3)) == 1 ? 1 : -1;
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
