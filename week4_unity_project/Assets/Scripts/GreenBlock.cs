using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
{

    public List<GameObject> movingPlayers;
    public Sprite zeroBlockSprite;
    public Sprite oneBlockSprite;
    public Sprite twoBlockSprite; //둘이서 한 칸짜리 블록 못 밀어서 의미 없을듯
    private SpriteRenderer spriteRenderer;

    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    int blockNum_init = 0;
    int blockNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer.sprite.name=="block_32_5"){
            blockNum_init = 0;
        }
        else if(spriteRenderer.sprite.name=="block_32_6"){
            blockNum_init = 1;
        }
        else if(spriteRenderer.sprite.name=="block_32_7"){
            blockNum_init = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        blockNum = blockNum_init;

        if (nupjukBlue.GetComponent<BlueMove>().isMovingBlock&&(blockNum>0))
        {
            blockNum--;
        }
        if(nupjukPink.GetComponent<PinkMove>().isMovingBlock&&(blockNum>0)){
            blockNum--;
        }

        SpriteRenderer blockSpriteRenderer = GetComponent<SpriteRenderer>();
        if (blockNum == 0)
        {
            blockSpriteRenderer.sprite = zeroBlockSprite;
        }
        else if (blockNum == 1)
        {
            blockSpriteRenderer.sprite = oneBlockSprite;
        }
        else if (blockNum == 2)
        {
            blockSpriteRenderer.sprite = twoBlockSprite;
        }
    }
}
