using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageIntro : MonoBehaviour
{
    public GameObject StageInt;
    public TMP_Text StageText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "1_Stage")
        {
            StageText.text = "1스테이지 : ###동굴";
            Invoke("SetActivefalse", 2);
        }

        // 씬 전환 시 bool값 변경을 false에서 true로 변경 후, 그 경우 SetActive(true)로 게임 오브젝트 온 하고 스테이지 별로 텍스트만 변경
    }

    void SetActivefalse()
    {
        StageInt.SetActive(false);
    }
}
