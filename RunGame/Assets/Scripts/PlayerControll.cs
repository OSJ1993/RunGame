using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    bool isJump = false;
    bool isTop = false;
    public float jumpHeight = 0;
    public float jumpSpeed = 0;

    Vector2 startPosition;
    void Start()
    {
        //스타프 포지션 스크립트가 실행 될 때 오브젝트에 현재 포지션으로 스타트 포지션으로 초기화. /22.03.07 by 승주
        startPosition = transform.position;
    }


    void Update()
    {

        //화면이 터치 됬을 때 점프 구현. 화면의 터치 여부는 GetMouseButtonDown 함수 이용  /22.03.07 by 승주  
        if (Input.GetMouseButtonDown(0))
        {
            // 터치가 이루어 지면 bool isJump를 true로 바꾸어 실행./22.03.07 by 승주
            isJump = true;
        }
        //Player가 계속 내려가다 startPosition보다 낮은 위치에 오면 isJump와 isTop을 false로 만들고 startPosition로 초기화.
        else if (transform.position.y <= startPosition.y)
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }

        if (isJump)
        {
            //일정 높이에 도달하면 참으로 변경하고 더 이상 Lerp 함수가 실행되지 않게 해주는 함수 /22.03.07 by 승주
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)
            {
                //점프 변수가 true일 때 Player가 위로 올라가는 함수./22.03.07 by 승주
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }

            // isTop = true고 Player가 startPosition위에 있을 때 MoveTowards 함수를 이용해 startPosition으로 옮겨줌
            if (transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
            }
        }
    }
}
