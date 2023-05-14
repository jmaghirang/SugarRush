using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //public Button pauseButton;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        GameManager.instance.TogglePause();
    }
}
