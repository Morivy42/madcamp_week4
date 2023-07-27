using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redLight : MonoBehaviour
{
    bool redLightOn = false;
    bool playerMoving = false;
    public GameObject player;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (redLightOn) 
        {
            // 키 입력이 있는지 확인
            if (Input.GetAxis("redLightHorizontal") != 0 || Input.GetAxis("redLightVertical") != 0)
            {
                
                Debug.Log("Game Over");
                player.GetComponent<BlueMove>().isAlive =false;
                player2.GetComponent<PinkMove>().isAlive =false;
            }
        }


    }

    void RedLightOn()
    {
        Debug.Log("Red Light On");
        redLightOn = true;
    }

    void RedLightOff()
    {
        Debug.Log("Red Light Off");
        redLightOn = false;
    }
}
// if (Input.anyKey)
//         {
//             Debug.Log("아무 키나 눌렸습니다.");
//         }

//         if (Input.anyKeyDown)
//         {
//             Debug.Log("아무 키나 처음 눌렸습니다.");
//         }

//         foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
//         {
//             if (Input.GetKey(keyCode))
//             {
//                 Debug.Log("키가 눌렸습니다: " + keyCode.ToString());
//             }

//             if (Input.GetKeyDown(keyCode))
//             {
//                 Debug.Log("키가 처음 눌렸습니다: " + keyCode.ToString());
//             }

//             if (Input.GetKeyUp(keyCode))
//             {
//                 Debug.Log("키가 떼어졌습니다: " + keyCode.ToString());
//             }
//         }