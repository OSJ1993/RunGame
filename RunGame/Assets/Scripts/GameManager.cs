using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region instance
    public static GameManager instance;
    private void Awake()
    {
        //��Ŭ������ /22.03.16 by����
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    //PLAY��ư�� ������ ������ �Ŵ����� �ڷ�ƾ�� ����ǰ� ���� /22.03.16 by����
    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;

    //�Ǽ��� ������ �ϳ� ����� �׶���� ��ֹ� ���ǵ带 �� ������ ���ؼ� ����. /22.03.16 by����.
    public float gameSpeed=1;
    public bool isPlay = false;
    public GameObject playBtn;

    //��ư�� Ŭ�� �� �� ȣ���� �޼ҵ� ����./22.03.16 by����
    public void playBtnClick()
    {
        //������ �����ϸ� ��ư�� ���صǹǷ� ��Ȱ��ȭ./22.03.16 by����
        playBtn.SetActive(false);

        //��ư ������ isPlay�� true�� �ٲ��ִ� �Լ�./22.03.16 by����
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

