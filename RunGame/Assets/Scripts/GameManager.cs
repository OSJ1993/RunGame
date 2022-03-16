using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region instance
    public static GameManager instance;
    private void Awake()
    {
        //싱클톤패턴 /22.03.16 by승주
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    //PLAY버튼이 눌리면 리스폰 매니저에 코루틴이 재생되게 변경 /22.03.16 by승주
    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;

    //실수형 변수를 하나 만들고 그라운드와 장애물 스피드를 이 변수를 통해서 조절. /22.03.16 by승주.
    public float gameSpeed=1;
    public bool isPlay = false;
    public GameObject playBtn;

    //버튼이 클릭 될 때 호출할 메소드 생성./22.03.16 by승주
    public void playBtnClick()
    {
        //게임이 시작하면 버튼이 방해되므로 비활성화./22.03.16 by승주
        playBtn.SetActive(false);

        //버튼 킅릭시 isPlay를 true로 바꿔주는 함수./22.03.16 by승주
        isPlay = true;

        onPlay.Invoke(isPlay);
    }

    public void Gameover()
    {
        playBtn.SetActive(true);
        isPlay = false;
        onPlay.Invoke(isPlay);
    }
}

