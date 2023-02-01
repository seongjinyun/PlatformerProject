using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon_Laser : MonoBehaviour
{
    public float sca = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        sca += 5f * Time.deltaTime;
        transform.localScale = new Vector2(sca, 2);


        if (sca >= 20f)
        {
            Destroy(gameObject);
        }

        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * 8 * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -8 * Time.deltaTime);
        }
    }
}
