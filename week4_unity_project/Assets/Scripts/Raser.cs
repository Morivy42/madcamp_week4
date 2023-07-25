using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raser : MonoBehaviour
{
    bool raserHit = false;
    bool blueHit = false;
    bool pinkHit = false;
    public GameObject nupjukPink;
    public GameObject nupjukBlue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!raserHit)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.up, 0.2f, LayerMask.GetMask("bluePlayer", "pinkPlayer"));
            if (raycastHit.collider != null)
            {
                raserHit = true;
                //layer 6: bluePlayer, 7: pinkPlayer
                if (raycastHit.collider.gameObject.layer == 6)
                {
                    blueHit = true;
                }
                else if (raycastHit.collider.gameObject.layer == 7)
                {
                    pinkHit = true;
                }
            }
        }

        if (pinkHit)
        {
            nupjukPink.GetComponent<PinkMove>().isAlive =false;
            pinkHit = false;
            // pinkSpriteRenderer.sprite = newPinkSprite;
            
        }
        if (blueHit)
        {
            nupjukBlue.GetComponent<BlueMove>().isAlive =false;
            blueHit = false;
        }
        
    }
}
