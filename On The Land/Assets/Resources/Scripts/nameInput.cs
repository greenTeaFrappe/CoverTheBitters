using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class nameInput : MonoBehaviour
{
    public InputField firstNameInput;
    public InputField secondNameInput;
    public Button nameApplyBtn;
    public GameObject popupPanel; // �˾�â ������Ʈ

    private const string playerNameKey = "PlayerName";
    private const int firstNameMaxLength = 6;
    private const int secondNameMaxLength = 2;

    private void Start()
    {
        nameApplyBtn.onClick.AddListener(SaveAndClosePopup);

        // InputField�� �ѱ۸� �Է� �����ϵ��� ���͸��� �����մϴ�.
        firstNameInput.onValueChanged.AddListener(delegate { FilterInput(firstNameInput, firstNameMaxLength); });
        secondNameInput.onValueChanged.AddListener(delegate { FilterInput(secondNameInput, secondNameMaxLength); });
    }

    public void SaveAndClosePopup()
    {
        string firstName = firstNameInput.text;
        string secondName = secondNameInput.text;

        // ��ȿ�� �˻�
        if (IsValidName(firstName) && IsValidName(secondName))
        {
            // ������ �����ϴ� ��쿡�� ���� �����ϰ� �˾�â�� �ݽ��ϴ�.
            string playerName = firstName + " " + secondName;
            PlayerPrefs.SetString(playerNameKey, playerName);
            PlayerPrefs.Save();
            Debug.Log("Player name saved: " + playerName);

            // �˾�â�� �ݽ��ϴ�.
            popupPanel.SetActive(false);
        }
        else
        {
            // ������ �������� �ʴ� ��� ��� ����մϴ�.
            Debug.LogWarning("Invalid name format. Please enter valid names.");
        }
    }

    // �̸��� ��ȿ���� �˻��ϴ� �޼���
    private bool IsValidName(string name)
    {
        // �ѱ۸� �Է� �����ϰ�, ������ ���� ���� ���� �ִ��� Ȯ���մϴ�.
        return Regex.IsMatch(name, "^[��-�R]*$") && name.Length <= firstNameMaxLength;
    }

    // �Է� �ʵ忡 �ѱ۸� �Էµǵ��� ���͸��ϴ� �޼���
    private void FilterInput(InputField inputField, int maxLength)
    {
        string filteredText = Regex.Replace(inputField.text, "[^��-�R]", "");
        // �Է� ���̰� �ִ� ���̸� �ʰ��ϸ� �Է��� �����ϴ�.
        if (filteredText.Length > maxLength)
        {
            filteredText = filteredText.Substring(0, maxLength);
        }
        inputField.text = filteredText;
    }
}
