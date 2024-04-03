using UnityEngine;
using UnityEngine.UI;

public class speedOption : MonoBehaviour
{
    public Dropdown speedDropdown;
    public float[] speedOptions = { 0.5f, 1.0f, 1.5f, 2.0f };

    private void Start()
    {
        // 드롭다운 옵션 초기화
        InitializeOptions();

        // 이전에 저장된 속도 옵션 불러오기
        LoadSelectedSpeed();

        // 드롭다운 값이 변경될 때마다 저장
        speedDropdown.onValueChanged.AddListener(OnSpeedChanged);
    }

    // 드롭다운 옵션 초기화
    private void InitializeOptions()
    {
        speedDropdown.ClearOptions();

        foreach (float speed in speedOptions)
        {
            string optionText = speed.ToString() + "배속";
            speedDropdown.options.Add(new Dropdown.OptionData(optionText));
        }

        speedDropdown.RefreshShownValue();
    }

    // 드롭다운 값이 변경되었을 때 호출되는 메서드
    private void OnSpeedChanged(int index)
    {
        // 변경된 인덱스를 PlayerPrefs에 저장
        PlayerPrefs.SetInt("SelectedSpeedIndex", index);
        PlayerPrefs.Save();
    }

    // 이전에 저장된 속도 옵션 불러오기
    private void LoadSelectedSpeed()
    {
        if (PlayerPrefs.HasKey("SelectedSpeedIndex"))
        {
            int selectedIndex = PlayerPrefs.GetInt("SelectedSpeedIndex");
            speedDropdown.value = selectedIndex;
        }
    }

    // 현재 선택된 속도 반환
    public float GetCurrentSpeed()
    {
        int selectedIndex = speedDropdown.value;
        return speedOptions[selectedIndex];
    }
}
