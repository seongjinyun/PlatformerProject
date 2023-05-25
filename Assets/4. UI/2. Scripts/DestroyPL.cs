using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPL : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UI_Main" || SceneManager.GetActiveScene().name == "UI_Select")
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
