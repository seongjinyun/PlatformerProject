using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject player;

    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text FinalscoreText;
    public GameObject Panel;
    public static int gameScore = 0;
    public static float gameTimer = 60f;
    private bool timerEnded = false;
    public static Player_Move p_Move;
    Player_Anim player_Anim;
/*    private string baseURL = "https://desktop-api.op.gg/indi/result?gamekind=&key="; // API 주소
*/
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        scoreText.text = "SCORE: " + gameScore;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");

        p_Move = player.GetComponent<Player_Move>();
    }
    private void Update()
    {
        if (!timerEnded)
        {
            gameTimer -= Time.deltaTime;
            timerText.text = "TIME: " + Mathf.Round(gameTimer);

            if (gameTimer <= 0)
            {
                timerEnded = true;
                EndGame();
            }
        }

        if(BoolManager.PlayerDie == true)
        {
            EndGame();
        }
        //else if(BoolManager.PlayerDie == false)
       // {
         //   Panel.SetActive(false);
       // }
    }

    public void RestartScene() // 씬 다시시작
    {
        BoolManager.PlayerDie = false;
        p_Move.currentHealth = 5;
        Player_Attack.Skill_gauge = 0f;

        Scene currentScene = SceneManager.GetActiveScene(); // 현재 활성화된 씬을 가져옵니다.
        SceneManager.LoadScene(currentScene.name); // 현재 씬을 다시 불러옵니다.
    }

    public void AddScore(int value)
    {
        gameScore += value;
        scoreText.text = "SCORE: " + gameScore;
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
        FinalscoreText.text = "SCORE: " + gameScore;





        //string playerName = "사용자 이름"; // 프로젝트에 맞게 사용자 이름을 설정하세요.
        //StartCoroutine(RegisterScore(NameEnter.playerName, score, Mathf.RoundToInt(timer * 100), "another-world", "fezTOzdREMzdIIOKwZObYl0ELfQ0rUXV1jRLP1DlHvoFAPDqbH"));
    }

/*    IEnumerator RegisterScore(string playerName, int score, int timer, string gameKind, string key) // 스코어 API에 전송
    {
        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("score", score);
        form.AddField("playedTime", timer);
        form.AddField("gameKind", gameKind);
        form.AddField("key", key);

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
