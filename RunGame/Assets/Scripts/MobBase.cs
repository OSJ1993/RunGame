using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{

    public float mobSpeed = 0;
    public Vector2 StartCoroutine;

    //MobPrefabs�� Ȱ��ȭ �Ǹ� �������� �����ؼ� ȭ�� ������ �Ѿ�� �ٽ� ��Ȱ��ȭ. / 22.03.15 by����.
    //OnEnable�� ������Ʈ�� Ȱ��ȭ �� �� ����. /22.03.15 by����
    private void OnEnable()
    {
        transform.position = StartCoroutine;
    }


    void Update()
    {
        //������ /22.03.08 by ����
        transform.Translate(Vector2.left * Time.deltaTime * mobSpeed);

        //������Ʈ�� x��ǥ�� -6���� �۾����� 
        if (transform.position.x < -6)
        {
            //������Ʈ ��Ȱ��ȭ. /22.03.15 by����
            gameObject.SetActive(false);
        }
    }
}
