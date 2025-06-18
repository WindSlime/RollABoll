using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Xml.Serialization;
using UnityEngine;

public class Spider1 : MonoBehaviour
{
    #region 차이점
    // **** 전 코드와의 차이점 ****
    //전의 spider 코드와 왜 다른것을 쓰느냐
    //
    #endregion

    Animator anim;
    public float speed;
    public float JumpPower;
    bool iswalk = false;
    bool isJump = false;
    public float rotspeed = 120.0f; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Spiderspeed = speed * Time.deltaTime; //Spiderspeed와 speed는 서로 다르기에 Spiderspeed를 speed로 바꾸면 오류가 발생함
        float SpiderJump = JumpPower * Time.deltaTime;

        iswalk = false;
        isJump = false;

        #region Move
        float moveH = Input.GetAxis("Horizontal");
        float moVe = Input.GetAxis("Vertical");

        if (moveH > 0.5f || moveH < -0.5f)
            iswalk = true;
        else if (moVe > 0.5f || moVe < -0.5f)
            iswalk = true;
        else
            iswalk = false;

        anim.SetBool("iswalk", iswalk);
        anim.SetBool("isJump", isJump);

        float xSpeed = Spiderspeed * moveH; //좌우 이동
        float ySpeed = Spiderspeed * moVe; //앞뒤 이동

        float rSpeed = rotspeed * Time.deltaTime; //회전이동 계산
        float yrotate = rotspeed * moveH; // 회전값 

        Vector3 rot = new Vector3(0.0f, yrotate, 0.0f); //회전 적용
        transform.Rotate(rot);
        #endregion
    }
}
