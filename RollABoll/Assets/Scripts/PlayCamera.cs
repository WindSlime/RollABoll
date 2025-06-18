using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCamera : MonoBehaviour
{
    public GameObject ball; //볼 게임오브젝트를 저장하기위한 변수
    private Vector3 offset; //기준점의 변수 이름
    // Start is called before the first frame update
    void Start()
    {
        //카메라와 볼의 거리 측정값을 offset에 저장
        offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //볼이 움직일 때 마다 기준 거리를 더한 값을 카메라 위치에 저장
        transform.position = ball.transform.position + offset;
    }
}
