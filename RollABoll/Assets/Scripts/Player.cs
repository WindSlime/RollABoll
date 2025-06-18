using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 1.0f; //속도를 나타내는 변수
    private Rigidbody rb; //중력을 제어하기 위한 변수

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //리지드바디를 받아옴
    }

    // Update is called once per frame
    void Update()
    {
        float moveV = Input.GetAxis("Vertical"); //수직축 입력
        float moveH = Input.GetAxis("Horizontal"); //수평축 입력

        Vector3 move = new Vector3(moveH, 0.0f, moveV);

        //Debug.Log("Vertical : " + moveV + "\t Horizontal : " + moveH);
        rb.AddForce(move * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick")) //Pick 태그를 가진 게임오브젝트를 검출 true이면 if{}실행
        {
            other.gameObject.SetActive(false); //검출된 게임 오브젝트를 활성화상태 스위치를 false
        }
    }

}
