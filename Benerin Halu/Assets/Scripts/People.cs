using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class People : MonoBehaviour
{
    public string nama;
    public float speed;
    public int sanityMeter; // Max is 10
    public Movements movements;
    public GameObject baloonPrefab;
    public float baloonTransDelay;
    int prevBaloonIdx = -1;
    float baloonDelayChange;
    IList<GameObject> baloons;
    IList<int> hasShowBaloonIndexs;
    Animator anim;
    string[] emojis = { "Sad", "GJ", "Angry", "Heart", "Tai", "Sleepy", "Suicide" };
    IList<string> pickEmojis;

    void Start()
    {
        sanityMeter = Random.Range(0, 6);
        InitBaloonState();
        anim = GetComponentInChildren<Animator>();
        baloonDelayChange = baloonTransDelay;
    }

    void DefineEmoji()
    {
        pickEmojis = new List<string>();
        for (var i = 0; i < sanityMeter; i++)
        {

        }
    }

    void InitBaloonState()
    {
        baloons = new List<GameObject>();
        hasShowBaloonIndexs = new List<int>();
        Debug.Log(name + ": " + sanityMeter);
        for (var i = 0; i < sanityMeter; i++)
        {
            // Get second child of people prefabs
            var baloonTransform = gameObject.transform.GetChild(1).transform;
            var baloonObject = Instantiate(baloonPrefab, baloonTransform);
            baloonObject.GetComponent<Baloon>().SetSprite(emojis[i]); // Set Emoji sprite
            baloonObject.SetActive(false);
            hasShowBaloonIndexs.Add(i);
            baloons.Add(baloonObject);
        }
    }

    void Update()
    {
        if (baloonDelayChange > 0)
        {
            baloonDelayChange -= Time.deltaTime * 15;
        }
        else
        {
            ChangeBaloonState();
        }

        if (movements != null)
        {
            movements.Move(speed);
            anim.SetFloat("XPos", movements.facing);
        }
    }

    void ChangeBaloonState()
    {
        if (hasShowBaloonIndexs.Count > 0)
        {
            Debug.Log("Do Change Baloon");
            var pickBaloonIndex = Random.Range(0, hasShowBaloonIndexs.Count - 1);
            var baloon = baloons[pickBaloonIndex];
            baloon.SetActive(true);
            if (prevBaloonIdx >= 0)
            {
                baloons[prevBaloonIdx].SetActive(false);
            }
            hasShowBaloonIndexs.RemoveAt(pickBaloonIndex);
            prevBaloonIdx = pickBaloonIndex;
            baloonDelayChange = baloonTransDelay;
        }
        else
        {
            Debug.Log("Do Reset Baloon State");
            for (int i = 0; i < sanityMeter; i++)
            {
                hasShowBaloonIndexs.Add(i);
                baloons[i].SetActive(false);
            }
            prevBaloonIdx = -1;
        }
    }

    private void OnMouseDown()
    {
        if (!EntitasDetail.inspectPopUp)
        {
            EntitasDetail.title = nama;
            FindObjectOfType<ScenesController>().popUp();
        }
    }
}
