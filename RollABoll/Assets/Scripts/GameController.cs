using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int V_Ending = 12;
    public int L_Ending = 100;

    private int Count;
    private int Score;
    public TextMeshProUGUI ScoreTXT;

    private float Sec;
    public TextMeshProUGUI TimeTXT;

    public TextMeshProUGUI WinLoseTXT;
    // Start is called before the first frame update
    void Start()
    {
        Count = 0;
        Score = 0;
        Sec = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        

        //시간 카운트
        Sec += Time.deltaTime; //시간 카운트를 Time에서 누적
        int Dest = L_Ending - (int)Sec;
        if(Dest <= 0) //실패하는 조건 0초
        {
            GameEnding(false);
        }
        TimeTXT.text = string.Format("{0:D3}",Dest, (int)Sec); //스트링 포맷에 따른 출력
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick")) //Pick 태그를 가진 게임오브젝트를 검출 true이면 if{}실행
        {
            Count++;
            other.gameObject.SetActive(false); //검출된 게임 오브젝트를 활성화상태 스위치를 false
            GetComponent<AudioSource>().Play(); //사운드 출력
        }
        Score = Count * 100; //점수를 Count 1개 당 100점으로 변환
        ScoreTXT.text = "Score : " + Score.ToString(); //InGame UI 스코어 출력

        if(Count >= V_Ending) //성공하는 조건 12개 먹기
        {
            GameEnding(true);
        }
    }

    //게임이 끝났을 때 처리하는 메소드
    void GameEnding(bool bIsWin)
    {
        if(bIsWin)
        {
            WinLoseTXT.color= Color.yellow;
            WinLoseTXT.text = "WINER!";
        }
        else
        {
            WinLoseTXT.color = Color.red;
            WinLoseTXT.text = "LOSER";
        }
        Time.timeScale = 0; //게임 일시 멈춤
    }
}
