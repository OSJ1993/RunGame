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
        //��Ÿ�� ������ ��ũ��Ʈ�� ���� �� �� ������Ʈ�� ���� ���������� ��ŸƮ ���������� �ʱ�ȭ. /22.03.07 by ����
        startPosition = transform.position;
    }


    void Update()
    {

        //ȭ���� ��ġ ���� �� ���� ����. ȭ���� ��ġ ���δ� GetMouseButtonDown �Լ� �̿�  /22.03.07 by ����  
        if (Input.GetMouseButtonDown(0))
        {
            // ��ġ�� �̷�� ���� bool isJump�� true�� �ٲپ� ����./22.03.07 by ����
            isJump = true;
        }
        //Player�� ��� �������� startPosition���� ���� ��ġ�� ���� isJump�� isTop�� false�� ����� startPosition�� �ʱ�ȭ.
        else if (transform.position.y <= startPosition.y)
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }

        if (isJump)
        {
            //���� ���̿� �����ϸ� ������ �����ϰ� �� �̻� Lerp �Լ��� ������� �ʰ� ���ִ� �Լ� /22.03.07 by ����
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)
            {
                //���� ������ true�� �� Player�� ���� �ö󰡴� �Լ�./22.03.07 by ����
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isTop = true;
            }

            // isTop = true�� Player�� startPosition���� ���� �� MoveTowards �Լ��� �̿��� startPosition���� �Ű���
            if (transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
            }
        }
    }
}
