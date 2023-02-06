using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    public float camera_speed = 5.0f;
    //public GameObject target;

    GameObject my_target;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    Vector2 mapSize;

    [SerializeField]    
    float height;
    float width;
    float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;

        my_target = GameObject.FindGameObjectWithTag("Player");
        if( my_target != null)
        {
            Debug.Log("게임오브젝트("+my_target.name + ")을" + "찾음");
        }
        else
        {
            Debug.Log("못찾음");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //플레이어 카메라 추적
        Vector3 dir = my_target.transform.position - this.transform.position; //타겟과 카메라 위치 계산값
        Vector3 moveVector = new Vector3(dir.x * camera_speed * Time.deltaTime, dir.y * camera_speed * Time.deltaTime, 0.0f); //카메라 움직임

        dir.x = Mathf.Clamp(dir.x, center.x, mapSize.x);
        dir.y = Mathf.Clamp(dir.y, center.y, mapSize.y);
        transform.position = Vector3.Lerp(transform.position, dir, smoothing);

        this.transform.Translate(moveVector);

        

        //카메라 맵 밖 안보이게
        /*float lx = mapSize.x - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        float ly = mapSize.y - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        transform.position = new Vector3(clampX, clampY, -10f);*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }
}
