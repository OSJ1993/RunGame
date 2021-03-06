using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{


    public List<GameObject> MobPool = new List<GameObject>();


    public GameObject[] Mobs;
    public int objCnt = 1;

    void Awake()
    {
        //반복문과 CreatObj 매소드를 사용해서 Mobs배열에 PreFab을 원하는 수만큼 생성 후 /22.03.08 by 승주
        for (int i = 0; i < Mobs.Length; i++)
        {
            for (int q = 0; q < objCnt; q++)
            {

                // MobPool List에 추가.
                MobPool.Add(CreatObj(Mobs[i], transform));
            }
        }
    }


    private void Start()
    {
        GameManager.instance.onPlay += PlayGame;

    }

    void PlayGame(bool isplay)
    {
        if (isplay)
        {
            //게임 다시 시작 시 모든 장애물 비활성화. /22.03.16 by승주
            for (int i = 0; i < MobPool.Count; i++)
            {
                if (MobPool[i].activeSelf)
                    MobPool[i].SetActive(false);
            }
            StartCoroutine(CreateMob());
        }
        else
            StopAllCoroutines();
    }


    //코르틴을 사용해서 정해진 시간마다 리스트에 장애물을 한개를 랜덤으로 뽑아 활성화. /22.03.08 by 승주
    IEnumerator CreateMob()
    {
        yield return new WaitForSeconds(0.5f);

        // while 으로 반복 실행. /22.03.15 by승주
        while (GameManager.instance.isPlay)
        {
            //임의 수를 활성화. /22.03.08 by 승주
            MobPool[DeactiveMob()].SetActive(true);

            //Random.Range(최소, 최대); 최소~최대
            //WaitForSeconds는 괄호 안에 숫자 만큼 기다렸다가 실행. /22.03.15 by승주
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    //장애물을 활성화 시킬 때 List에서 랜덤으로 실행 시키기 때문에 이미 활성화 되어있는 오브젝트가 다시 활성화 되므로 활성화 되어있지 않는 오브젝트를 찾아서 활성화 시켜주는 함수.  /22.03.15 by 승주
    int DeactiveMob()
    {
        List<int> num = new List<int>();

        //MobPool의 크기만큼 반복하면서 비활성화 되어있는 찾아 순번을 List에 추가 /22.03.15 by 승주
        for (int i = 0; i < MobPool.Count; i++)
        {
            if (!MobPool[i].activeSelf)
                num.Add(i);
        }

        int x = 0;

        //그리고 List값이 0보다 크다면 정수형 List에서 임의 수 한개를 골라 반환. /22.03.15 by 승주
        if (num.Count > 0)
            x = num[Random.Range(0, num.Count)];
        return x;
    }

    //게임 오브젝트를 반환형으로 같는 CreateObj로 만들어 주기. /22.03.08 by 승주
    GameObject CreatObj(GameObject obj, Transform parent)
    {
        //매개변수로 받은 GameObject 복제 한 뒤
        GameObject copy = Instantiate(obj);

        //Transform의 자식으로 설정
        copy.transform.SetParent(parent);

        //비활성화 시켜 준 뒤
        copy.SetActive(false);

        //return값으로 반환.
        return copy;
    }



}
