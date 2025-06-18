using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Spider : MonoBehaviour
{

    Animator anim;
    public float speed;
    public float JumpPower;
    bool iswalk = false;
    bool isJump = false;
    public float rotateS = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        float Spiderspeed = speed * Time.deltaTime; //Spiderspeed�� speed�� ���� �ٸ��⿡ Spiderspeed�� speed�� �ٲٸ� ������ �߻���
        float SpiderJump = JumpPower * Time.deltaTime;
        float yrotate = rotateS * Time.deltaTime;
        Vector3 rot = new Vector3(0.0f, yrotate, 0.0f);

        iswalk = false;
        isJump = false;
        #region Move
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0f, Spiderspeed);
            iswalk = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-rot);
            iswalk = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -Spiderspeed);
            iswalk = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(rot);
            iswalk = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0f, JumpPower, 0f);
            isJump = true;
        }

        anim.SetBool("iswalk", iswalk);
        anim.SetBool("isJump", isJump);

        #endregion
    }
}
