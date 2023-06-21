using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound_Destroy : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UI_Main")
        {
            Destroy(gameObject);
        }
        
    }
}
