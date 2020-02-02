using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class People : MonoBehaviour
{
    public string nama;
    public float speed;
    public float delayLevelDown;
    private float _delayLevelDown;
    private float _delayAddHalu;
    public int emojiMeter; // Max is 7
    public int sanityMeter; // max 10
    public Movements movements;
    public GameObject baloonPrefab;
    public GameObject baloonSelf;
    public float baloonTransDelay;
    private Animator animEff;
    private GameObject animEffObj;
    float baloonDelayChange;
    // IList<GameObject> baloons;
    int pickedEmojisIdx;
    IList<int> hasShowBaloonIndexs;
    Animator anim;
    public Sprite potrait;
    string[] emojis = { "Sad", "GJ", "Angry", "Heart", "Tai", "Sleepy", "Suicide" };
    IList<string> pickedEmojis;
    bool _canMove;
    public AudioClip emoji;

    void Start()
    {
        emojiMeter = definePeople();
        _delayLevelDown = delayLevelDown;
        _delayAddHalu = 5;
        pickedEmojis = new List<string>(); // di sini karena define emoji bakal dipanggil saat emoticon bertambah
        InitBaloonState();
        anim = GetComponentInChildren<Animator>();
        baloonDelayChange = baloonTransDelay;
        animEffObj = gameObject.transform.GetChild(2).gameObject;
        animEff = animEffObj.GetComponent<Animator>();
        Debug.Assert(animEff != null);
        _canMove = true;
    }

    void DefineEmoji()
    {
        
        while (pickedEmojis.Count != emojiMeter)
        {
            var pickEmo = Random.Range(0, emojis.Length - 1);
            if (!pickedEmojis.Contains(emojis[pickEmo]))
                pickedEmojis.Add(emojis[pickEmo]);
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

        baloonSelf.SetActive(false);
        if (pickedEmojis.Count >= 1)
        {
            baloonSelf.SetActive(true);
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
        if (movements != null && _canMove)
        {
            movements.Move(speed);
            anim.SetFloat("XPos", movements.facing);
        }
        else
        {
            movements.Move(0);
        }
        levelDown();
        HaluPeople();
    }

    
    void ChangeBaloonState()
    {
        if (pickedEmojis.Count <= 1)
            return;
        if (pickedEmojisIdx == pickedEmojis.Count-1)
        {
            
            pickedEmojisIdx = 0;
            /*
            for (int i = 0; i < emojiMeter; i++)
            {
                hasShowBaloonIndexs.Add(i);
            }
            */
        }
        
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
            EntitasDetail.go = gameObject;
            FindObjectOfType<ScenesController>().popUp();

        }
    }

    /*
        gameObject.GetComponentInParent<AudioSource>().PlayOneShot(emoji);
    */
    public int definePeople()
    {
        sanityMeter = Random.Range(10,10);
        if (sanityMeter < 5)
        {
            return 0;
        }else if (sanityMeter < 7)
        {
            return Random.Range(1, 3);
        }else if (sanityMeter < 9)
        {
            return Random.Range(2, 5);
        }
        else
        {
            return Random.Range(3, 7);
        }
    }
    public void levelDown()
    {
        delayLevelDown -= Time.deltaTime;
        if (delayLevelDown <= 0)
        {
            delayLevelDown = _delayLevelDown;
            sanityMeter += 1;
            if (sanityMeter == 5 || sanityMeter == 7 || sanityMeter == 9)
            {
                baloonSelf.SetActive(true);
                emojiMeter += 2;
                while (pickedEmojis.Count != emojiMeter)
                {
                    var pickEmo = Random.Range(0, emojis.Length - 1);
                    if (!pickedEmojis.Contains(emojis[pickEmo]))
                        pickedEmojis.Add(emojis[pickEmo]);
                }
            }
        }
    }

    public void HaluPeople()
    {
        if (sanityMeter <= 10)
            return;
        _delayAddHalu -= Time.deltaTime;
        if(_delayAddHalu < 0)
        {
            _delayAddHalu = 5;
            HaluMeter.AddingHaluMeter(10);
        }
    }

    public void BackToPoll()
    {
        DummyScript.deadEntity.Enqueue(gameObject);
        _canMove = true;
        animEffObj.SetActive(false);
        gameObject.SetActive(false);
    }

    IEnumerator DelayRehabilityEffect(float second, bool isBackToPool)
    {
        yield return new WaitForSeconds(second);
        animEffObj.SetActive(false);
        if (isBackToPool)
        {
            BackToPoll();
        }
    }

    public void RehabilityFeedback(bool isPositive)
    {
        Debug.Log("1 second passed");
        animEffObj.SetActive(true);
        if (isPositive)
        {
            _canMove = false;
            animEff.SetFloat("feedback", 1f);
        }
        else
        {
            animEff.SetFloat("feedback", 0f);
        }
        StartCoroutine(DelayRehabilityEffect(0.7f, isPositive));
    }
}
