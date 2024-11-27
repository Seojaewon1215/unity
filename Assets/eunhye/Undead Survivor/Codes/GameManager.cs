using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("# Game Control")]

    public float gameTime;
    public float maxGameTime = 2 * 10f;
    [Header("# Player Control")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;


    public Animator fadeAnimator;


    void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log($"현재 씬: {currentScene}");
        Instance = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(720, 1280, true);

    }

    public void Update()
    {
       


        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
   
        }
    }

    public void GetExp()
    {
        exp++;

        if(exp == nextExp[level])
        {
            level++;
            exp = 0;

        }
    }

    private IEnumerator LoadSceneWithFade(string sceneName)
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f); // 페이드 아웃 지속 시간
        SceneManager.LoadScene(sceneName);
    }



}
