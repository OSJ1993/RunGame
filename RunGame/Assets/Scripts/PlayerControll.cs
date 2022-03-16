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

    Animator animator;

    void Start()
    {
        //��Ÿ�� ������ ��ũ��Ʈ�� ���� �� �� ������Ʈ�� ���� ���������� ��ŸƮ ���������� �ʱ�ȭ. /22.03.07 by ����
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (GameManager.instance.isPlay)
            animator.SetBool("Run", true);
        else
            animator.SetBool("Run", false);

        //ȭ���� ��ġ ���� �� ���� ����. ȭ���� ��ġ ���δ� GetMouseButtonDown �Լ� �̿�  /22.03.07 by ����  
        if (Input.GetMouseButtonDown(0) && GameManager.instance.isPlay)
        {
            // ��ġ�� �̷�� ���� bool isJump�� true�� �ٲپ� ����./22.03.07 by ����
            isJump = true;
        }
        //Player�� ��� �������� startPosition���� ���� ��ġ�� ���� isJump�� isTop�� false�� ����� startPosition�� �ʱ�ȭ. /22.03.07 by ����
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

            // isTop = true�� Player�� startPosition���� ���� �� MoveTowards �Լ��� �̿��� startPosition���� �Ű��� /22.03.07 by ����
            if (transform.position.y > startPosition.y && isTop)
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��ֹ��� �浹�ϸ� GameManager�� ���ӿ��� �޼ҵ带 ȣ�� /22.03.16 by ����.
        if (collision.CompareTag("Mob"))
        {
            GameManager.instance.Gameover();

            
        }
    }
}
