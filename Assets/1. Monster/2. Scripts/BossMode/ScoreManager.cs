using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text FinalscoreText;
    public GameObject Panel;
    public int score;
    public float timer = 60f;
    private bool timerEnded = false;

    //private string baseURL = "https://your-api-server-url.com"; // API 주소

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (!timerEnded)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time " + Mathf.Round(timer);

            if (timer <= 0)
            {
                timerEnded = true;
                EndGame();
            }
        }
    }
    public void RestartScene() // 씬 다시시작
    {
        Scene currentScene = SceneManager.GetActiveScene(); // 현재 활성화된 씬을 가져옵니다.
        SceneManager.LoadScene(currentScene.name); // 현재 씬을 다시 불러옵니다.
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score:" + score;
    }

    public void MainSceneGO()
    {
        LoadingSceneController.LoadScene("UI_Main");

    }
    public void Quit() //게임 정지 함수 (QUIT 버튼을 누르면 실행)
    {
        Application.Quit();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
        FinalscoreText.text = "Score:" + score;
        




        /*string playerName = "사용자 이름"; // 프로젝트에 맞게 사용자 이름을 설정하세요.
        StartCoroutine(RegisterScore(playerName, score));*/
    }

/*    IEnumerator RegisterScore(string playerName, int score) // 스코어 API에 전송
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("score", score);

        UnityWebRequest www = UnityWebRequest.Post(baseURL + "/register_score", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error registering score: " + www.error);
        }
        else
        {
            Debug.Log("Score registered successfully!");
            // 적절한 메시지 및 결과 화면 표시
        }
    }*/
}
