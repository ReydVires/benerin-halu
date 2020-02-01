using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baloon : MonoBehaviour
{
    public SpriteRenderer _emoSprite;
    Sprite _sprite;

    void Start()
    {
        ApplySprite();
    }

    public void ApplySprite()
    {
        if (_sprite != null)
        {
            _emoSprite.sprite = _sprite;
        }
    }

    public void SetSprite(string name)
    {
        _sprite = Resources.Load<Sprite>("emo" + name);
        Debug.Log("Set baloon sprite: " + _sprite.name);
        ApplySprite();
    }
}
