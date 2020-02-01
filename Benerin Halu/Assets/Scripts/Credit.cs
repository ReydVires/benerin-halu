using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Credit : MonoBehaviour
{
    [SerializeField] RectTransform creditPanel;
    bool isShow = true;
    void Start()
    {
        creditPanel = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void creditShow()
    {
        if (isShow){
            creditPanel.DOMove(new Vector3(700f, creditPanel.position.y, 0f), 1f);
            //creditPanel.localPosition = Vector3.Lerp(creditPanel.localPosition, new Vector3(254f, 0.02503967f, 0f), 1f);
            isShow = false;
        }
        else
        {
            //creditPanel.localPosition = Vector3.Lerp(creditPanel.localPosition, new Vector3(565f, 0.02503967f, 0f), 1f);
            creditPanel.DOMove(new Vector3(1000f, creditPanel.position.y, 0f), 1f);
            isShow = true;
        }
        
    }
}
