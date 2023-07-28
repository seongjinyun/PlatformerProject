using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

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

            StartCoroutine(RegisterScore(playerName, ScoreManager.gameScore, Mathf.RoundToInt(ScoreManager.gameTimer * 1000), "another_world", "fezTOzdREMzdIIOKwZObYl0ELfQ0rUXV1jRLP1DlHvoFAPDqbH"));
        }
        else
        {
            Debug.Log("�̸��� �Է��ϼ���.");
        }
        
    }
    IEnumerator RegisterScore(string playerName, int score, int playedTime, string gamekind, string key) // ���ھ� API�� ����
    {

        scoreModel scoremodel = new scoreModel(playerName, score, playedTime, gamekind, key);
        string output = JsonConvert.SerializeObject(scoremodel);

        Debug.Log("��û ������ URL: " + baseURL + "/result");
        Debug.Log("��û ������: " + output);

        using (UnityWebRequest www = UnityWebRequest.Post(new Uri(baseURL + "/result"), new System.Collections.Generic.Dictionary<string, string> { { "Content-Type", "application/json" }, { "Accept", "application/json" } }))
        {
            www.SetRequestHeader("Content-Type", "application/json"); // Content-Type ����
            byte[] data = System.Text.Encoding.UTF8.GetBytes(output);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(data);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error registering score. Response Code: " + www.responseCode + ", Error Message: " + www.error);
            }
            else
            {
                Debug.Log("Score registered successfully!");
                LoadingSceneController.LoadScene("UI_Main");

                ScoreManager.gameScore = 0;
                ScoreManager.gameTimer = 60f;
            }
        }

    }
}
