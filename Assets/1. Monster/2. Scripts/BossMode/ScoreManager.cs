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

    //private string baseURL = "https://your-api-server-url.com"; // API �ּ�

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
    public void RestartScene() // �� �ٽý���
    {
        Scene currentScene = SceneManager.GetActiveScene(); // ���� Ȱ��ȭ�� ���� �����ɴϴ�.
        SceneManager.LoadScene(currentScene.name); // ���� ���� �ٽ� �ҷ��ɴϴ�.
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
    public void Quit() //���� ���� �Լ� (QUIT ��ư�� ������ ����)
    {
        Application.Quit();
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        Panel.SetActive(true);
        FinalscoreText.text = "Score:" + score;
        




        /*string playerName = "����� �̸�"; // ������Ʈ�� �°� ����� �̸��� �����ϼ���.
        StartCoroutine(RegisterScore(playerName, score));*/
    }

/*    IEnumerator RegisterScore(string playerName, int score) // ���ھ� API�� ����
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
            // ������ �޽��� �� ��� ȭ�� ǥ��
        }
    }*/
}
