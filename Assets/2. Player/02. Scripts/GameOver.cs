using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Material cameraMaterial;
    public float gray_Scale = 0.0f;

    float apliy_Time = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        cameraMaterial = new Material(Shader.Find("Grayscale"));
    }

    // 후처리 source 이미지(현재 화면)를 destination 이미지로 교체
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        cameraMaterial.SetFloat("Grayscale", gray_Scale);
        Graphics.Blit(source, destination, cameraMaterial);
    }
    public void gameOver()
    {
        StartCoroutine(gameOver_effect());
    }
    private IEnumerator gameOver_effect()
    {
        float elapsedTime = 0.0f;

        while(elapsedTime < apliy_Time)
        {
            elapsedTime += Time.deltaTime;

            gray_Scale = elapsedTime / apliy_Time;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
