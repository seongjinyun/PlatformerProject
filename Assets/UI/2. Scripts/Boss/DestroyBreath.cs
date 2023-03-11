using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBreath : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, 2); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
