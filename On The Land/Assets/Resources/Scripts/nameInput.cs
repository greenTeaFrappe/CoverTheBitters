using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class nameInput : MonoBehaviour
{
    public InputField firstNameInput;
    public InputField secondNameInput;
    public Button nameApplyBtn;
    public GameObject popupPanel; // 팝업창 오브젝트

    private const string playerNameKey = "PlayerName";
    private const int firstNameMaxLength = 6;
    private const int secondNameMaxLength = 2;

    private void Start()
    {
        nameApplyBtn.onClick.AddListener(SaveAndClosePopup);

        // InputField에 한글만 입력 가능하도록 필터링을 적용합니다.
        firstNameInput.onValueChanged.AddListener(delegate { FilterInput(firstNameInput, firstNameMaxLength); });
        secondNameInput.onValueChanged.AddListener(delegate { FilterInput(secondNameInput, secondNameMaxLength); });
    }

    public void SaveAndClosePopup()
    {
        string firstName = firstNameInput.text;
        string secondName = secondNameInput.text;

        // 유효성 검사
        if (IsValidName(firstName) && IsValidName(secondName))
        {
            // 조건을 만족하는 경우에만 값을 저장하고 팝업창을 닫습니다.
            string playerName = firstName + " " + secondName;
            PlayerPrefs.SetString(playerNameKey, playerName);
            PlayerPrefs.Save();
            Debug.Log("Player name saved: " + playerName);

            // 팝업창을 닫습니다.
            popupPanel.SetActive(false);
        }
        else
        {
            // 조건을 만족하지 않는 경우 경고를 출력합니다.
            Debug.LogWarning("Invalid name format. Please enter valid names.");
        }
    }

    // 이름의 유효성을 검사하는 메서드
    private bool IsValidName(string name)
    {
        // 한글만 입력 가능하고, 지정된 길이 범위 내에 있는지 확인합니다.
        return Regex.IsMatch(name, "^[가-힣]*$") && name.Length <= firstNameMaxLength;
    }

    // 입력 필드에 한글만 입력되도록 필터링하는 메서드
    private void FilterInput(InputField inputField, int maxLength)
    {
        string filteredText = Regex.Replace(inputField.text, "[^가-힣]", "");
        // 입력 길이가 최대 길이를 초과하면 입력을 막습니다.
        if (filteredText.Length > maxLength)
        {
            filteredText = filteredText.Substring(0, maxLength);
        }
        inputField.text = filteredText;
    }
}
