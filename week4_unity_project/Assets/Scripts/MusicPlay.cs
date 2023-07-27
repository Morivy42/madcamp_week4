using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject nupjukBlue;
    public GameObject nupjukPink;
    public GameObject escMenu;
    public GameObject clearCanvas;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bool blueAlive = nupjukBlue.GetComponent<BlueMove>().isAlive;
        bool pinkAlive = nupjukPink.GetComponent<PinkMove>().isAlive;
        if (!(blueAlive && pinkAlive))
        {
            audioSource.Pause();
        }
        if((clearCanvas!=null)&&clearCanvas.activeSelf){
            audioSource.Pause();
        }
        if ((escMenu!=null)&&escMenu.activeSelf)
        {
            audioSource.volume = 0.3f;
        }
        else
        {
            // audioSource.UnPause();
            audioSource.volume = 1f;
        }
    }
}
