using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationClip healAnim;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
