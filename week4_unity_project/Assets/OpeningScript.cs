using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs delete all
        
        PlayerPrefs.DeleteAll();

        // store stage number
        PlayerPrefs.SetInt("stage", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
