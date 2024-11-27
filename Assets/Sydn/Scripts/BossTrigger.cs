using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTrigger : MonoBehaviour
{
    private bool isPlayerInTrigger = false; // 플레이어가 트리거 안에 있는지 여부 확인

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 BossTrigger 범위에 들어왔습니다!");
            isPlayerInTrigger = true; // 플레이어가 트리거 안에 들어옴
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 BossTrigger 범위를 벗어났습니다!");
            isPlayerInTrigger = false; // 플레이어가 트리거에서 나감
        }
    }

    private void Update()
    {
        // 트리거 안에 있는 동안 F 키 입력 감지
        if (isPlayerInTrigger && Input.GetKeyUp(KeyCode.F))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            Debug.Log($"현재 씬: {currentScene}");

            if (currentScene != "BossMap")
            {
                Debug.Log("BossMap 씬으로 이동합니다.");
                SceneManager.LoadScene("BossMap");
            }
        }
    }
}