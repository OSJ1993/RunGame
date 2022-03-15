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
            for (int q = 0; q < objCnt; q++)
            {

                // MobPool List�� �߰�.
                MobPool.Add(CreatObj(Mobs[i], transform));
            }
        }
    }


    private void Start()
    {
        StartCoroutine(CreateMob());
    }


    //�ڸ�ƾ�� ����ؼ� ������ �ð����� ����Ʈ�� ��ֹ��� �Ѱ��� �������� �̾� Ȱ��ȭ. /22.03.08 by ����
    IEnumerator CreateMob()
    {
        // while ���� �ݺ� ����. /22.03.15 by����
        while (true)
        {
            //Random.Range(�ּ�, �ִ�); �ּ�~�ִ� ������ ���� ���� Ȱ��ȭ. /22.03.08 by ����
            MobPool[Random.Range(0, MobPool.Count)].SetActive(true);

            //WaitForSeconds�� ��ȣ �ȿ� ���� ��ŭ ��ٷȴٰ� ����. /22.03.15 by����
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }

    //��ֹ��� Ȱ��ȭ ��ų �� List���� �������� ���� ��Ű�� ������ �̹� Ȱ��ȭ �Ǿ��ִ� ������Ʈ�� �ٽ� Ȱ��ȭ �ǹǷ� Ȱ��ȭ �Ǿ����� �ʴ� ������Ʈ�� ã�Ƽ� Ȱ��ȭ �����ִ� �Լ�.  /22.03.15 by ����
    int DeactiveMob()
    {
        List<int> num = new List<int>();

        //MobPool�� ũ�⸸ŭ �ݺ��ϸ鼭 ��Ȱ��ȭ �Ǿ��ִ� ã�� ������ List�� �߰�
        for(int i = 0; i < MobPool.Count; i++)
        {
            if (!MobPool[i].activeSelf)
                num.Add(i);
        }
        int x = 0;
        
       //x=num
            return;
    }

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
