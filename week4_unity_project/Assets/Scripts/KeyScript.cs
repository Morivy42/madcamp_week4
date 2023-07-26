using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject targetObj;
    public bool taken = false;
    // Start is called before the first frame update
    void Start()
    {
        targetObj = null;
    }

    void Awake(){
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D keyHit = Physics2D.Raycast(transform.position, Vector2.left, 0.5f, LayerMask.GetMask("pinkPlayer", "bluePlayer"));
        RaycastHit2D keyHit2 = Physics2D.Raycast(transform.position, Vector2.right, 0.5f, LayerMask.GetMask("pinkPlayer", "bluePlayer"));
        if(keyHit.collider!=null){
            targetObj = keyHit.collider.gameObject;
        }
        else if(keyHit2.collider!=null){    
            targetObj = keyHit2.collider.gameObject;
        }
        if(targetObj != null){
            taken = true;
            Vector3 offset = new Vector3(-0.3f, 0.3f, 0f);
            transform.Translate(targetObj.transform.position-this.transform.position+offset);
        }
        else{
            taken = false;
        }
    }
}
