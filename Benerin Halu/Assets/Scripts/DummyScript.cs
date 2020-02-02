using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyScript : MonoBehaviour
{
    public static Queue<GameObject> deadEntity = new Queue<GameObject>();
    public float timeNewEntitiy = 5;
    public float timeSpawnDifficulity; // untuk mempercepat spawn jika waktu permainan sudah berlangsung cukup lama [OPTIONAL]
    public GameObject player;

    public RuntimeAnimatorController[] animatorControllers;

    public Sprite[] potraits;
    public Transform[] spawnSpot;

    private void Start()
    {
        for (int i = 0; i < 17; i++)
        {
            if (player.transform.GetChild(i).gameObject.activeSelf != true)
            {
                deadEntity.Enqueue(player.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < 6; i++)
        {
            InitPeople();
        }
    }
    private void Update()
    {
        if(deadEntity.Count > 0)
        {
            timeNewEntitiy -= Time.deltaTime;
            if (timeNewEntitiy <= 0)
            {
                timeNewEntitiy = 3f; // nanti bisa diganti dengan timeSpawnDifficulity [OPTIONAL]
                InitPeople();
            }
        }
    }

    public void InitPeople()
    {
        int idx = Random.Range(0, spawnSpot.Length);
        float facing = -1;
        if (idx < 2)
        {
            facing = 1;
        }
        int idxAnim = Random.Range(0, animatorControllers.Length);
        deadEntity.Dequeue().GetComponent<Movements>().Initialize(facing, spawnSpot[idx].position, animatorControllers[idxAnim], potraits[idxAnim]);
    }
}
