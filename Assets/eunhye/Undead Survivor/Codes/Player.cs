using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;


    public float speed;
    public scaner scanner;


    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;




    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<scaner>();
    }
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // 애니메이터에 속도와 방향 정보 전달
        anim.SetFloat("Speed", inputVec.magnitude);
        anim.SetFloat("Horizontal", inputVec.x);
        anim.SetFloat("Vertical", inputVec.y);

        if (Input.GetKeyUp(KeyCode.F))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            // 디버깅 로그 추가: 현재 씬 확인
            Debug.Log($"현재 씬: {currentScene}");

            if (currentScene != "Top_down")
            {
                Debug.Log("Top_down 씬으로 이동합니다.");
                SceneManager.LoadScene("Top_down");
            }
            
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized*speed*Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        

    }
}
