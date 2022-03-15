using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{

    public float mobSpeed = 0;
    public Vector2 StartCoroutine;

    //MobPrefabs이 활성화 되면 우측에서 시작해서 화면 좌측을 넘어가면 다시 비활성화. / 22.03.15 by승주.
    //OnEnable은 오브젝트가 활성화 될 때 실행. /22.03.15 by승주
    private void OnEnable()
    {
        transform.position = StartCoroutine;
    }


    void Update()
    {
        //움직임 /22.03.08 by 승주
        transform.Translate(Vector2.left * Time.deltaTime * mobSpeed);

        //오브젝트의 x좌표가 -6보다 작아지면 
        if (transform.position.x < -6)
        {
            //오브젝트 비활성화. /22.03.15 by승주
            gameObject.SetActive(false);
        }
    }
}
