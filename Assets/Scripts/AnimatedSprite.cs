using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;
    public float animationTime = 0.25f;
    public int animationFrame { get; private set; }
    public bool loop = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Advance), animationTime, animationTime);
    }

    private void Advance()
    {
        if (!spriteRenderer.enabled) return;

        this.animationFrame++;

        if (this.animationFrame >= this.sprites.Length && this.loop)
            this.animationFrame = 0;

        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
            this.spriteRenderer.sprite = sprites[animationFrame];
    }

    public void Restart()
    {
        this.animationFrame = -1;
        this.Advance();
    }
}
