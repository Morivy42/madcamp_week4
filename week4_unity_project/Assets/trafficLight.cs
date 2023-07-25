using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when RedLight is on, if player moves, then game over
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "RedLight")
            {
                if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
                {
                    Debug.Log("Game Over");
                }
            }
        }
    }

    // receive int from animation event
    public void ChangeLight(int light)
    {
        if (light == 0)
        {
            gameObject.tag = "RedLight";
                    Debug.Log("RedLight");

        }
        else if (light == 1)
        {
            gameObject.tag = "GreenLight";
                    Debug.Log("GreenLight");

        }
    }

}
