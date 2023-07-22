using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameEnter : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    private string playerName = null;

    private void Awake()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    private void Update()
    {
    }

    //마우스
    public void InputName()
    {
        playerName = playerNameInput.text;
        PlayerPrefs.SetString("CurrentPlayerName", playerName);

        if (!string.IsNullOrEmpty(playerName))
        {
            Debug.Log(playerName);
            LoadingSceneController.LoadScene("UI_Main");
        }
        else
        {
            Debug.Log("이름을 입력하세요.");
        }
        
    }
}
