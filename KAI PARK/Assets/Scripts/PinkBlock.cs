using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBlock : MonoBehaviour
{
    //파란 넙죽이가 미는 거 막기
    private Rigidbody2D rb;
    public GameObject nupjukBlue;
    public
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.isKinematic = false;
        if ((nupjukBlue.GetComponent<BlueMove>().blockObject == this.gameObject)&&nupjukBlue.GetComponent<BlueMove>().isMovingBlock)
        {
            rb.isKinematic = true;
        }
    }
}
