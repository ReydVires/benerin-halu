using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public static Queue<GameObject> deadEntity = new Queue<GameObject>();
    public float timeNewEntitiy = 5;

    private void Update()
    {
        if(deadEntity.Count > 0)
        {
            timeNewEntitiy -= Time.deltaTime;
            if(timeNewEntitiy <= 0)
            {
                timeNewEntitiy = 3f;
                //deadEntity.Dequeue().GetComponent<Movements>().Initialize();
            }
        }
    }
}
