using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    // Ground오브젝트를 담을 SpriteRenderer를 배열 선언. /22.03.08 by 승주
    public SpriteRenderer[] tiles;
    public Sprite[] groundImg;

    public float speed;

            

    void Start()
    {
        temp = tiles[0];
        

    }

          

    SpriteRenderer temp;

    void Update()
    {
        //이제 게임을 실행하면 바로 움직이던 그라운드 장애물 플레이어를 플레이 버튼을 눌려서 isPlay가 true 때만 움직이게 /22.03.16 by승주.
        if (GameManager.instance.isPlay)
        {
            //tiles포지션의 x좌표가 -7보다 작을 때 가장 뒤에 있는 tiles검색해서 가장 뒤 타일보다 x좌표를 -1만큼 보내주기. /22.03.08 by 승주
            for (int i = 0; i < tiles.Length; i++)
            {
                if (-5 >= tiles[i].transform.position.x)
                {
                    for (int q = 0; q < tiles.Length; q++)
                    {
                        //가장 뒤에 tiles을 검색하는 방법은 변수를 하나 두고 반복문과 조건문을 사용해서 현재 tiles과 변수의 저장 된 tiles에 x좌표를 비교하면서 현재 tile이 변수 tile보다 x좌표가 크면 변수 tile을 현재 tile로 초기화. /22.03.08 by 승주
                        if (temp.transform.position.x < tiles[q].transform.position.x)
                            temp = tiles[q];
                    }
                    //x좌표가 -5넘어버리는 tile은 제일 뒤로 보내주고  Sprite 배열을 선언 한 뒤에 제일 뒤로 보낸 tile의 Sprite를 Sprite배열 중 한개를 랜덤하게 바꿔주기. /22.03.08 by 승주
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -0.3f);
                    tiles[i].sprite = groundImg[Random.Range(0, groundImg.Length)];
                }
            }

            //반복문으로 tile의 갯수 만큼 돌리면서 Translate함수를 사용해 tiles 좌측으로 이동. /22.03.08 by 승주
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
            }
        }


    }
}
