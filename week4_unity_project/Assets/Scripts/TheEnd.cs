using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    private bool isEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        isEnded = PlayerPrefs.GetString("theEnd") == "true";
        PlayerPrefs.SetString("theEnd", "");
        this.gameObject.SetActive(isEnded);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
