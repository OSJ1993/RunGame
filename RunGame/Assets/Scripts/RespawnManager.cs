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
            // MobPool List에 추가.
            MobPool.Add(CreatObj(Mobs[i], transform)); 
        }
    }

    //코르틴을 사용해서 정해진 시간마다 리스트에 장애물을 한개를 랜덤으로 뽑아 활성화. /22.03.08 by 승주
    //Random.Range(최소, 최대); 최소~최대 사이의 임의 수를 반환. /22.03.08 by 승주


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
