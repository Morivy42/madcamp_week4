using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
{

    public Sprite zeroBlockSprite;
    public Sprite oneBlockSprite;
    public Sprite twoBlockSprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;

    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    int blockNum_init = 0;
    int blockNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (spriteRenderer.sprite.name)
        {
            case "block_32_5":
            case "slidenblock64_1":
                blockNum_init = 0;
                break;
            case "block_32_6":
            case "slidenblock64_3":
                blockNum_init = 1;
                break;
            case "block_32_7":
            case "slidenblock64_5":
                blockNum_init = 2;
                break;
            default:
                break;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.isKinematic = false;
        blockNum = blockNum_init;
        bool bluePush = nupjukBlue.GetComponent<BlueMove>().isMovingBlock;
        bool pinkPush = nupjukPink.GetComponent<PinkMove>().isMovingBlock;

        if (bluePush && (blockNum > 0))
        {
            GameObject blockObject = nupjukBlue.GetComponent<BlueMove>().blockObject;
            if (blockObject == this.gameObject)
                blockNum--;
        }
        if (pinkPush && (blockNum > 0))
        {
            GameObject blockObject = nupjukPink.GetComponent<PinkMove>().blockObject;
            if (blockObject == this.gameObject)
                blockNum--;
        }
        SpriteRenderer blockSpriteRenderer = GetComponent<SpriteRenderer>();
        if (blockNum == 0)
        {
            rb.isKinematic = false;
            blockSpriteRenderer.sprite = zeroBlockSprite;
        }
        else if (blockNum == 1)
        {
            if (pinkPush || bluePush)
            {
                rb.isKinematic = true;
            }
            blockSpriteRenderer.sprite = oneBlockSprite;
        }
        else if (blockNum == 2)
        {
            blockSpriteRenderer.sprite = twoBlockSprite;
        }
    }
}
