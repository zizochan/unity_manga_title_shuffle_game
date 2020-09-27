using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBackgroundController : MonoBehaviour
{
    SpriteRenderer mainSpriteRenderer;
    public Sprite[] bg_sprites;

    // Start is called before the first frame update
    void Start()
    {
        mainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetBackground();
    }

    void SetBackground()
    {
        mainSpriteRenderer.sprite = ChoiceSprite();
    }

    Sprite ChoiceSprite()
    {
        int index = UnityEngine.Random.Range(0, bg_sprites.Length);
        return bg_sprites[index];
    }
}
