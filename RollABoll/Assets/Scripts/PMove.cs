using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public Transform[] wayPoint; //경로 배열
    private Vector3 currPos; //위치 저장 변수
    private int wayPointIndex = 0; //현재 경로의 인덱스
    public float Speed = 1.0f;
    public float rotspeed = 120.0f;

    Animator anim;
    bool iswalk = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        #region 경로
        float moveH = Input.GetAxis("Horizontal");
        float moVe = Input.GetAxis("Vertical");

        iswalk = false;

        currPos = transform.position; //현재위치 계산
        if (wayPointIndex < wayPoint.Length) //현재 경로 인덱스를 전체길이와 비교
        {
            transform.position = Vector3.MoveTowards //지정된 경로로 이동
                (currPos, //현재 위치
                wayPoint[wayPointIndex].transform.position, // 다음 위치
                Speed * Time.deltaTime); //속도로 루프가 돌때마다 계속 이동 시켜줌
            iswalk = true;

            Vector3 direction = wayPoint[wayPointIndex].position - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction); //즉시 회전
            }

            //현 위치에서 다음 위치에 가까이 도달하면, 
            if (Vector3.Distance(wayPoint[wayPointIndex].transform.position, currPos) < 0.1f)
            {
                wayPointIndex++; //다음 위치로 변경됨
                if (wayPointIndex >= wayPoint.Length) wayPointIndex = 0; //지정된 경로 끝까지 도달시 다시 처음 위치로 변경
                Vector3 Direction = wayPoint[wayPointIndex].position - transform.position;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction); // 목표 방향
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation,
                        targetRotation,
                        rotspeed * Time.deltaTime // 회전 속도
                    );
                }
                
            }
            

        }
        #endregion
    }
}
