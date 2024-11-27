using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameManager GM;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GM.gameTime>=30f)
        {
            //게임 타임이 지나거나 플레이어 레벨이 올라가면 보스 출현
        }

        //구현할것: 1.보스의 플레이어 감지 및 트래킹  2. 플레이어가 보스와 멀어졌을때 재배치 3. 보스의 패턴 및 페이즈 구현 4.
    }
}
