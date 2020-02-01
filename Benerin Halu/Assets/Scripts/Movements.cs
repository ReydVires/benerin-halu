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
    public int random;

    public GameObject spawnPoint;
    private Transform[] _spawnPoint;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        random = Random.Range(1, 1000);
        _spawnPoint = new Transform[spawnPoint.transform.childCount];
        int i = 0;
        foreach (Transform child in spawnPoint.transform)
        {
            _spawnPoint[i++] = child;
        }

        Initialize();
        
    }

    public void Initialize()
    {
        gameObject.SetActive(true);
        accel = Random.Range(minAccel, maxAccel);
        int idx = Random.Range(0, _spawnPoint.Length-1);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            DummyScript.deadEntity.Enqueue(gameObject);
            gameObject.SetActive(false);
            // gameObject.active = false;
        }
    }
    private void OnMouseDown()
    {
        if (!EntitasDetail.inspectPopUp)
        {
            EntitasDetail.random = random.ToString();
            FindObjectOfType<ScenesController>().popUp();
        }
    }

}
