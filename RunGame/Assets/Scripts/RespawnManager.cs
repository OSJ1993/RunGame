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
        //�ݺ����� CreatObj �żҵ带 ����ؼ� Mobs�迭�� PreFab�� ���ϴ� ����ŭ ���� �� /22.03.08 by ����
        for (int i = 0; i < Mobs.Length; i++)
        {
            // MobPool List�� �߰�.
            MobPool.Add(CreatObj(Mobs[i], transform)); 
        }
    }

    //�ڸ�ƾ�� ����ؼ� ������ �ð����� ����Ʈ�� ��ֹ��� �Ѱ��� �������� �̾� Ȱ��ȭ. /22.03.08 by ����
    //Random.Range(�ּ�, �ִ�); �ּ�~�ִ� ������ ���� ���� ��ȯ. /22.03.08 by ����


    //���� ������Ʈ�� ��ȯ������ ���� CreateObj�� ����� �ֱ�. /22.03.08 by ����
    GameObject CreatObj(GameObject obj, Transform parent)
    {
        //�Ű������� ���� GameObject ���� �� ��
        GameObject copy = Instantiate(obj);

        //Transform�� �ڽ����� ����
        copy.transform.SetParent(parent);

        //��Ȱ��ȭ ���� �� ��
        copy.SetActive(false);

        //return������ ��ȯ.
        return copy;
    }



}
