using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    // Ground������Ʈ�� ���� SpriteRenderer�� �迭 ����. /22.03.08 by ����
    public SpriteRenderer[] tiles;
    public Sprite[] groundImg;

    public float speed;

            

    void Start()
    {
        temp = tiles[0];
        

    }

          

    SpriteRenderer temp;

    void Update()
    {
        //���� ������ �����ϸ� �ٷ� �����̴� �׶��� ��ֹ� �÷��̾ �÷��� ��ư�� ������ isPlay�� true ���� �����̰� /22.03.16 by����.
        if (GameManager.instance.isPlay)
        {
            //tiles�������� x��ǥ�� -7���� ���� �� ���� �ڿ� �ִ� tiles�˻��ؼ� ���� �� Ÿ�Ϻ��� x��ǥ�� -1��ŭ �����ֱ�. /22.03.08 by ����
            for (int i = 0; i < tiles.Length; i++)
            {
                if (-5 >= tiles[i].transform.position.x)
                {
                    for (int q = 0; q < tiles.Length; q++)
                    {
                        //���� �ڿ� tiles�� �˻��ϴ� ����� ������ �ϳ� �ΰ� �ݺ����� ���ǹ��� ����ؼ� ���� tiles�� ������ ���� �� tiles�� x��ǥ�� ���ϸ鼭 ���� tile�� ���� tile���� x��ǥ�� ũ�� ���� tile�� ���� tile�� �ʱ�ȭ. /22.03.08 by ����
                        if (temp.transform.position.x < tiles[q].transform.position.x)
                            temp = tiles[q];
                    }
                    //x��ǥ�� -5�Ѿ������ tile�� ���� �ڷ� �����ְ�  Sprite �迭�� ���� �� �ڿ� ���� �ڷ� ���� tile�� Sprite�� Sprite�迭 �� �Ѱ��� �����ϰ� �ٲ��ֱ�. /22.03.08 by ����
                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -0.3f);
                    tiles[i].sprite = groundImg[Random.Range(0, groundImg.Length)];
                }
            }

            //�ݺ������� tile�� ���� ��ŭ �����鼭 Translate�Լ��� ����� tiles �������� �̵�. /22.03.08 by ����
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
            }
        }


    }
}
