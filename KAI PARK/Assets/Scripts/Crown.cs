using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{

    // [SerializeField] private GameObject crown;
    [SerializeField] private string sceneName;

    private bool isClear = false;

    // Start is called before the first frame update
    void Start()
    {
        isClear = PlayerPrefs.GetString(sceneName) == "cleared";
        gameObject.SetActive(isClear);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
