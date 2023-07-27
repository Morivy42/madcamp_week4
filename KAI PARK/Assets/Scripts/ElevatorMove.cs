using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    public GameObject elevatorBody;

    public Sprite twoElevator;
    public Sprite oneElevator;
    public Sprite zeroElevator;

    private SpriteRenderer ebsr;
    private bool blueOn = false;
    private bool pinkOn = false;
    private int blockNum = 0;
    private int blockNum_init = 0;

    private bool movingElevator = false;
    private bool movingUp = true;
    public Vector3 startPos;
    public Vector3 endPos;
    public float distance = 13f;
    private float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        ebsr = elevatorBody.GetComponent<SpriteRenderer>();
        if (ebsr.sprite.name == "slidenblock64_2")
        {
            blockNum_init = 0;
        }
        else if (ebsr.sprite.name == "slidenblock64_4")
        {
            blockNum_init = 1;
        }
        else if (ebsr.sprite.name == "slidenblock64_6")
        {
            blockNum_init = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        blueOn = nupjukBlue.GetComponent<BlueMove>().onElevator;
        pinkOn = nupjukPink.GetComponent<PinkMove>().onElevator;
        blockNum = blockNum_init;

        if (blueOn && (blockNum > 0))
        {
            blockNum--;
        }
        if (pinkOn && (blockNum > 0))
        {
            blockNum--;
        }
        switch (blockNum)
        {
            case 0:
                ebsr.sprite = zeroElevator;
                movingElevator = true;
                movingUp = true;
                break;
            case 1:
                ebsr.sprite = oneElevator;
                if (movingElevator)
                {
                    movingUp = false;
                }
                break;
            case 2:
                ebsr.sprite = twoElevator;
                if (movingElevator)
                {
                    movingUp = false;
                }
                break;
            default:
                break;
        }
        if (movingElevator)
        {
            if (movingUp)
            {
                if ((endPos.y - elevatorBody.transform.position.y) > 0.1f)
                {
                    Vector3 endPos_floor = new Vector3(endPos.x, endPos.y - 0.6f, endPos.z);
                    Vector3 endPos_blue = new Vector3(nupjukBlue.transform.position.x, endPos.y, -1f);
                    Vector3 endPos_pink = new Vector3(nupjukPink.transform.position.x, endPos.y, -1f);
                    transform.position = Vector3.MoveTowards(transform.position, endPos_floor, speed * Time.deltaTime);
                    elevatorBody.transform.position = Vector3.MoveTowards(elevatorBody.transform.position, endPos, speed * Time.deltaTime);
                    nupjukBlue.transform.position = Vector3.MoveTowards(nupjukBlue.transform.position, endPos_blue, speed * Time.deltaTime);
                    nupjukPink.transform.position = Vector3.MoveTowards(nupjukPink.transform.position, endPos_pink, speed * Time.deltaTime);
                }
                else{
                    movingUp = false;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, startPos) > 0.1f)
                {
                    Vector3 startPos_floor = new Vector3(startPos.x, startPos.y - 0.6f, startPos.z);
                    Vector3 startPos_blue = new Vector3(nupjukBlue.transform.position.x, startPos.y, -1f);
                    Vector3 startPos_pink = new Vector3(nupjukPink.transform.position.x, startPos.y, -1f);
                    transform.position = Vector3.MoveTowards(transform.position, startPos_floor, speed * Time.deltaTime);
                    elevatorBody.transform.position = Vector3.MoveTowards(elevatorBody.transform.position, startPos, speed * Time.deltaTime);
                    if(blueOn){
                        nupjukBlue.transform.position = Vector3.MoveTowards(nupjukBlue.transform.position, startPos_blue, speed * Time.deltaTime);
                    }
                    if(pinkOn){
                        nupjukPink.transform.position = Vector3.MoveTowards(nupjukPink.transform.position, startPos_pink, speed * Time.deltaTime);
                    }                   
                }
            }
        }
    }
}
