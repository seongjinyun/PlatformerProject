using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class NameEnter : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    private string playerName = null;

    private string baseURL = "https://desktop-api.op.gg/indi"; // API �ּ�


    private void Awake()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    private void Update()
    {
    }

    //���콺
    public void InputName()
    {
        playerName = playerNameInput.text;
        PlayerPrefs.SetString("CurrentPlayerName", playerName);

        if (!string.IsNullOrEmpty(playerName))
        {
            /*Debug.Log(playerName);
            Debug.Log(ScoreManager.gameScore);
            Debug.Log(ScoreManager.gameTimer);
*/
            StartCoroutine(RegisterScore(playerName, ScoreManager.gameScore, Mathf.RoundToInt(ScoreManager.gameTimer), "another-world", "fezTOzdREMzdIIOKwZObYl0ELfQ0rUXV1jRLP1DlHvoFAPDqbH"));

        }
        else
        {
            Debug.Log("�̸��� �Է��ϼ���.");
        }
        
    }
    IEnumerator RegisterScore(string playerName, int score, int timer, string gameKind, string key) // ���ھ� API�� ����
    {

        scoreModel scoremodel = new scoreModel(playerName, score, timer, gameKind, key);
        string output = JsonConvert.SerializeObject(scoremodel); 

        Debug.Log(output);

        using (UnityWebRequest www = UnityWebRequest.Post(baseURL + "/result", output))
        {
            Debug.Log("www : " + www);
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            Debug.Log(www.result);

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error registering score. Response Code: " + www.responseCode + ", Error Message: " + www.error);
            }
            else
            {
                Debug.Log("Score registered successfully!");
                LoadingSceneController.LoadScene("UI_Main");

                // ������ �޽��� �� ��� ȭ�� ǥ��
            }
        }

            
    }
}
