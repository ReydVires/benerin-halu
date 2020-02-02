using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class People : MonoBehaviour
{
    public string nama;
    public float speed;
    public int emojiMeter; // Max is 7
    public int sanityMeter;
    public Movements movements;
    public GameObject baloonPrefab;
    public GameObject baloonSelf;
    public float baloonTransDelay;
    float baloonDelayChange;
    // IList<GameObject> baloons;
    int pickedEmojisIdx;
    IList<int> hasShowBaloonIndexs;
    Animator anim;
    public Sprite potrait;
    string[] emojis = { "Sad", "GJ", "Angry", "Heart", "Tai", "Sleepy", "Suicide" };
    IList<string> pickedEmojis;

    public AudioClip emoji;

    void Start()
    {
        emojiMeter = Random.Range(0, 6);
        pickedEmojis = new List<string>(); // di sini karena define emoji bakal dipanggil saat emoticon bertambah
        InitBaloonState();
        anim = GetComponentInChildren<Animator>();
        baloonDelayChange = baloonTransDelay;
    }

    void DefineEmoji()
    {
        Debug.Log(pickedEmojis.Count);
        while (pickedEmojis.Count != emojiMeter)
        {
            var pickEmo = Random.Range(0, emojis.Length - 1);
            if (!pickedEmojis.Contains(emojis[pickEmo]))
                pickedEmojis.Add(emojis[pickEmo]);
        }
        for (int i = 0; i < pickedEmojis.Count; i++)
        {
            Debug.Log(pickedEmojis[i] + " " + i);
        }
    }
    
    void InitBaloonState()
    {
        /*
        for (var i = 0; i < emojiMeter; i++)
        {
            hasShowBaloonIndexs.Add(i);
        }
        */

        var baloonTransform = gameObject.transform.GetChild(1).transform;
        baloonSelf = Instantiate(baloonPrefab, baloonTransform);
        DefineEmoji();


        if (pickedEmojis.Count >= 1)
        {
            pickedEmojisIdx = 0;
            baloonSelf.GetComponent<Baloon>().SetSprite(pickedEmojis[pickedEmojisIdx]);
        }
        

    }
    
    void Update()
    {
        // baloon
        if (baloonDelayChange > 0)
        {
            baloonDelayChange -= Time.deltaTime * 15;
        }
        else
        {
            ChangeBaloonState();
        }

        // movement
        if (movements != null)
        {
            movements.Move(speed);
            anim.SetFloat("XPos", movements.facing);
        }
    }

    
    void ChangeBaloonState()
    {
        if (pickedEmojis.Count <= 1)
            return;
        if (pickedEmojisIdx == pickedEmojis.Count-1)
        {
            Debug.Log("Do Reset Baloon State");
            pickedEmojisIdx = 0;
            /*
            for (int i = 0; i < emojiMeter; i++)
            {
                hasShowBaloonIndexs.Add(i);
            }
            */
        }
        Debug.Log("Do Change Baloon");
        baloonSelf.GetComponent<Baloon>().SetSprite(pickedEmojis[++pickedEmojisIdx]);

            /*
            // set sprite
            var pickBaloonIndex = Random.Range(0, hasShowBaloonIndexs.Count - 1);
            baloonSelf.GetComponent<Baloon>().SetSprite(emojis[pickBaloonIndex]);
            hasShowBaloonIndexs.RemoveAt(pickBaloonIndex);
            */

            // delay
        baloonDelayChange = baloonTransDelay;
        
        
    }
    

    private void OnMouseDown()
    {
        if (!EntitasDetail.inspectPopUp)
        {
            EntitasDetail.title = nama;
            EntitasDetail.potrait = potrait;
            FindObjectOfType<ScenesController>().popUp();

        }
    }

    /*
        gameObject.GetComponentInParent<AudioSource>().PlayOneShot(emoji);
    */
    
}
