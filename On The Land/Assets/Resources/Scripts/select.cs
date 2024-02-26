using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class select : MonoBehaviour
{
    public GameObject creat;	// 플레이어 닉네임 입력UI
    public Text[] slotText;		// 슬롯버튼 아래에 존재하는 Text들
    public Text newPlayerData;	// 새로 입력된 플레이어의 슬롯 저장명

    bool[] saveFile = new bool[4];	// 세이브파일 존재유무 저장
    ScriptOutput scriptOutput = new ScriptOutput();

    void Start()
    {
        
        // 슬롯별로 저장된 데이터가 존재하는지 판단.
        for (int i = 0; i < 4; i++)
        {
            if (File.Exists(dataManager.instance.path + $"{i}"))	// 데이터가 있는 경우
            {
                saveFile[i] = true;			// 해당 슬롯 번호의 bool배열 true로 변환
                
                dataManager.instance.nowSlot = i;	// 선택한 슬롯 번호 저장
                dataManager.instance.loadData();	// 해당 슬롯 데이터 불러옴
                slotText[i].text = dataManager.instance.nowData.currentSceneNum;	// 버튼에 저장된 씬 넘버 표시
            }
            else	// 데이터가 없는 경우
            {
                slotText[i].text = "비어있음";
            }
        }
        // 불러온 데이터를 초기화시킴.(버튼에 닉네임을 표현하기위함이었기 때문)
        dataManager.instance.DataClear();
    }

    //public void slot(int number)	// 슬롯의 기능 구현
    //{
    //    dataManager.instance.nowSlot = number;	// 슬롯의 번호를 슬롯번호로 입력함.
    //
    //    if (saveFile[number])	// bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
    //    {
    //        dataManager.instance.loadData();	// 데이터를 로드하고
    //        GoGame();	// 게임씬으로 이동
    //    }
    //    else	// bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
    //    {
    //        Creat();	// 플레이어 닉네임 입력 UI 활성화
    //    }
    //}

    //public void Creat()	// 플레이어 닉네임 입력 UI를 활성화하는 메소드
    //{
    //    creat.gameObject.SetActive(true);
    //}

    public void GoGame()	// 게임씬으로 이동
    {
        if (!saveFile[dataManager.instance.nowSlot])	// 현재 슬롯번호의 데이터가 없다면
        {
            //dataManager.instance.nowData.slotName = newPlayerData.text; // 입력한 이름을 복사해옴
            dataManager.instance.nowData.currentSceneNum = scriptOutput.currentStorySceneNumber;
            dataManager.instance.saveData(); // 현재 정보를 저장함.
        }
        SceneManager.LoadScene(1); // 게임씬으로 이동
    }
}