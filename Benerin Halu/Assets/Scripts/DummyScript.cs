using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public static Queue<GameObject> deadEntity = new Queue<GameObject>();
    public float timeNewEntitiy = 5;
    public GameObject player;

    public RuntimeAnimatorController[] animatorControllers;

    private void Start()
    {
        deadEntity.Enqueue(player);
    }

    public Transform[] spawnIdx;

    private void Update()
    {
        if(deadEntity.Count > 0)
        {
            timeNewEntitiy -= Time.deltaTime;
            if(timeNewEntitiy <= 0)
            {
                timeNewEntitiy = 3f;
                int idx = Random.Range(0, spawnIdx.Length);
                float facing = -1;
                if(idx < 2)
                {
                    facing = 1;
                }
                deadEntity.Dequeue().GetComponent<Movements>().Initialize( facing,spawnIdx[idx].position);
            }
        }
    }
}
