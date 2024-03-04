using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class select : MonoBehaviour
{
    public Text[] slotText;     // 슬롯 버튼 아래에 있는 텍스트들

    bool[] saveFile = new bool[4]; // 세이브 파일이 있는지 여부를 저장하는 배열

    void Start()
    {
        // 각 슬롯에 데이터가 있는지 확인합니다.
        for (int i = 0; i < 4; i++)
        {
            if (PlayerPrefs.HasKey($"Slot{i}"))  // 데이터가 있는 경우
            {
                saveFile[i] = true; // 해당 슬롯을 true로 설정

                // 슬롯의 데이터를 로드합니다.
                string savedData = PlayerPrefs.GetString($"Slot{i}");
                string[] dataParts = savedData.Split('|');

                // 버튼에 씬 번호를 표시합니다.
                slotText[i].text = dataParts[0];
            }
            else  // 데이터가 없는 경우
            {
                slotText[i].text = "비어있음";
            }
        }
    }

    public void Slot(int number) // 슬롯의 기능
    {
        if (IsSlotOccupied(number))  // 이 슬롯에 데이터가 있는 경우
        {
            // 데이터를 로드하고 게임으로 이동합니다.
            string savedData = PlayerPrefs.GetString($"Slot{number}");
            string[] dataParts = savedData.Split('|');

            // 현재 씬 정보를 저장합니다.
            PlayerPrefs.SetString("CurrentSceneName", dataParts[0]);

            GoGame();
        }
        else  // 이 슬롯에 데이터가 없는 경우
        {
            CreateNew();
        }
    }

    public bool IsSlotOccupied(int slotNumber)
    {
        return saveFile[slotNumber]; // 해당 슬롯 번호의 데이터 유무를 반환합니다.
    }

    public void CreateNew()
    {
        Debug.Log("CreateNew() 함수 활성화 ");
        // 새로운 슬롯을 만드는 코드를 여기에 추가할 수 있습니다.
    }

    public void GoGame()
    {
        // 게임 씬으로 이동합니다.
        SceneManager.LoadScene(1);
    }
}
