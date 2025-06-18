using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Xml.Serialization;
using UnityEngine;

public class Spider1 : MonoBehaviour
{
    #region ������
    // **** �� �ڵ���� ������ ****
    //���� spider �ڵ�� �� �ٸ����� ������
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
        float Spiderspeed = speed * Time.deltaTime; //Spiderspeed�� speed�� ���� �ٸ��⿡ Spiderspeed�� speed�� �ٲٸ� ������ �߻���
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

        float xSpeed = Spiderspeed * moveH; //�¿� �̵�
        float ySpeed = Spiderspeed * moVe; //�յ� �̵�

        float rSpeed = rotspeed * Time.deltaTime; //ȸ���̵� ���
        float yrotate = rotspeed * moveH; // ȸ���� 

        Vector3 rot = new Vector3(0.0f, yrotate, 0.0f); //ȸ�� ����
        transform.Rotate(rot);
        #endregion
    }
}
