using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainOption : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseMenuCanvas;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OPTIONOn()
    {
        pauseMenuCanvas.SetActive(true);
    }

    public void OPTIONOff()
    {
        pauseMenuCanvas.SetActive(false);
    }
}
