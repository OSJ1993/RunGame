using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{

    public float mobSpeed = 0;

    void Start()
    {

    }


    void Update()
    {
        //������ /22.03.08 by ����
        transform.Translate(Vector2.left * Time.deltaTime);
    }
}
