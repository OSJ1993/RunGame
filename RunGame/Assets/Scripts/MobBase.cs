using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{

    public float mobSpeed = 0;
    public Vector2 StartPosition;

    //MobPrefabs�� Ȱ��ȭ �Ǹ� �������� �����ؼ� ȭ�� ������ �Ѿ�� �ٽ� ��Ȱ��ȭ. / 22.03.15 by����.
    //OnEnable�� ������Ʈ�� Ȱ��ȭ �� �� ����. /22.03.15 by����
    private void OnEnable()
    {
        transform.position = StartPosition;
    }


    void Update()
    {
        //���� ������ �����ϸ� �ٷ� �����̴� �׶��� ��ֹ� �÷��̾ �÷��� ��ư�� ������ isPlay�� true ���� �����̰� /22.03.16 by����.
        if (GameManager.instance.isPlay)

            //������ /22.03.08 by ����
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

        //������Ʈ�� x��ǥ�� -6���� �۾����� 
        if (transform.position.x < -6)
        {
            //������Ʈ ��Ȱ��ȭ. /22.03.15 by����
            gameObject.SetActive(false);
        }


    }
}
