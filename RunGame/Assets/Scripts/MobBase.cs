using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{

    public float mobSpeed = 0;
    public Vector2 StartPosition;

    //MobPrefabs이 활성화 되면 우측에서 시작해서 화면 좌측을 넘어가면 다시 비활성화. / 22.03.15 by승주.
    //OnEnable은 오브젝트가 활성화 될 때 실행. /22.03.15 by승주
    private void OnEnable()
    {
        transform.position = StartPosition;
    }


    void Update()
    {
        //이제 게임을 실행하면 바로 움직이던 그라운드 장애물 플레이어를 플레이 버튼을 눌려서 isPlay가 true 때만 움직이게 /22.03.16 by승주.
        if (GameManager.instance.isPlay)

            //움직임 /22.03.08 by 승주
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

        //오브젝트의 x좌표가 -6보다 작아지면 
        if (transform.position.x < -6)
        {
            //오브젝트 비활성화. /22.03.15 by승주
            gameObject.SetActive(false);
        }


    }
}
