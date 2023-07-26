using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public bool goodButton = true; //false면 don't push 버튼
    public Sprite pressedButton;
    public Sprite unpressedButton;
    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    public GameObject floatMap;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        floatMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerHit = Physics2D.Raycast(transform.position, Vector3.up, 0.3f, LayerMask.GetMask("bluePlayer", "pinkPlayer"));
        //버튼 눌림
        if(playerHit.collider!=null){  
            sr.sprite = pressedButton;
            //일반 버튼
            if(goodButton){
                floatMap.SetActive(true);
            }
            //don't push 버튼
            else{
                nupjukBlue.GetComponent<BlueMove>().isAlive = false;
                nupjukPink.GetComponent<PinkMove>().isAlive = false;
            }
        }
        else{
            sr.sprite = unpressedButton;
        }
    }
}
