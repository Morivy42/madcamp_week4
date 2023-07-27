using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingStageText : MonoBehaviour
{
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        // print Level number of the player
        text.text = "Level " + PlayerPrefs.GetInt("Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
