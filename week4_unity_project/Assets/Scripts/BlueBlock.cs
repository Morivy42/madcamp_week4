using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{
    //핑크 넙죽이가 미는 거 막기
    private Rigidbody2D rb;
    public GameObject nupjukPink;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.isKinematic = false;
        if(nupjukPink.GetComponent<PinkMove>().isMovingBlock){
            rb.isKinematic = true;
        }
    }
}
