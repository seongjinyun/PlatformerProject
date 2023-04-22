using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Active : MonoBehaviour
{
    public GameObject pause_button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UI_Select")
        {
            pause_button.SetActive(false);
        }
        
        
    }
}
