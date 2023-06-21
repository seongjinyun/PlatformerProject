using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour //±‚¡∏ æ¿¿ª ∞°∏Æ∞Ì ¥Ÿ¿Ω æ¿¿ª ∫“∑Øø»
{
    static string nextScene;

    [SerializeField]
    Slider progressBar;


    public static void LoadScene(string sceneName)
    {   
        
        nextScene = sceneName;
        SceneManager.LoadScene("UI_Loading");
    }
   
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    IEnumerator LoadSceneProcess()
    {
        //yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressBar.value = op.progress;
            }
           else
            timer += Time.unscaledDeltaTime;
            progressBar.value = Mathf.Lerp(0.9f, 1f, timer);
            if (progressBar.value >= 1.0f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }

}
