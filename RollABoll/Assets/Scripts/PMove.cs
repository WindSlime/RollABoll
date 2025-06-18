using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMove : MonoBehaviour
{
    public Transform[] wayPoint; //��� �迭
    private Vector3 currPos; //��ġ ���� ����
    private int wayPointIndex = 0; //���� ����� �ε���
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
        #region ���
        float moveH = Input.GetAxis("Horizontal");
        float moVe = Input.GetAxis("Vertical");

        iswalk = false;

        currPos = transform.position; //������ġ ���
        if (wayPointIndex < wayPoint.Length) //���� ��� �ε����� ��ü���̿� ��
        {
            transform.position = Vector3.MoveTowards //������ ��η� �̵�
                (currPos, //���� ��ġ
                wayPoint[wayPointIndex].transform.position, // ���� ��ġ
                Speed * Time.deltaTime); //�ӵ��� ������ �������� ��� �̵� ������
            iswalk = true;

            Vector3 direction = wayPoint[wayPointIndex].position - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction); //��� ȸ��
            }

            //�� ��ġ���� ���� ��ġ�� ������ �����ϸ�, 
            if (Vector3.Distance(wayPoint[wayPointIndex].transform.position, currPos) < 0.1f)
            {
                wayPointIndex++; //���� ��ġ�� �����
                if (wayPointIndex >= wayPoint.Length) wayPointIndex = 0; //������ ��� ������ ���޽� �ٽ� ó�� ��ġ�� ����
                Vector3 Direction = wayPoint[wayPointIndex].position - transform.position;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction); // ��ǥ ����
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation,
                        targetRotation,
                        rotspeed * Time.deltaTime // ȸ�� �ӵ�
                    );
                }
                
            }
            

        }
        #endregion
    }
}
