using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite _turnUp;
    [SerializeField] private Sprite _turnLeft;
    [SerializeField] private Sprite _turnDown;
    [SerializeField] private Sprite _turnRight;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Vector2 direction)
    {
        Sprite spriteToSet = null;
        if (direction == Vector2.up) spriteToSet = _turnUp;
        else if (direction == Vector2.left) spriteToSet = _turnLeft;
        else if (direction == Vector2.right) spriteToSet = _turnRight;
        else if (direction == Vector2.down) spriteToSet = _turnDown;
        _spriteRenderer.sprite = spriteToSet;
    }
}
