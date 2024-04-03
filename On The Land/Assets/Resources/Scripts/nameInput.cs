using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class nameInput : MonoBehaviour
{
    public InputField firstNameInput;
    public InputField secondNameInput;
    public Button nameApplyBtn;
    public GameObject popupPanel; // ÆË¾÷Ã¢ ¿ÀºêÁ§Æ®

    private const string playerNameKey = "PlayerName";
    private const int firstNameMaxLength = 6;
    private const int secondNameMaxLength = 2;

    private void Start()
    {
        nameApplyBtn.onClick.AddListener(SaveAndClosePopup);

        // InputField¿¡ ÇÑ±Û¸¸ ÀÔ·Â °¡´ÉÇÏµµ·Ï ÇÊÅÍ¸µÀ» Àû¿ëÇÕ´Ï´Ù.
        firstNameInput.onValueChanged.AddListener(delegate { FilterInput(firstNameInput, firstNameMaxLength); });
        secondNameInput.onValueChanged.AddListener(delegate { FilterInput(secondNameInput, secondNameMaxLength); });
    }

    public void SaveAndClosePopup()
    {
        string firstName = firstNameInput.text;
        string secondName = secondNameInput.text;

        // À¯È¿¼º °Ë»ç
        if (IsValidName(firstName) && IsValidName(secondName))
        {
            // Á¶°ÇÀ» ¸¸Á·ÇÏ´Â °æ¿ì¿¡¸¸ °ªÀ» ÀúÀåÇÏ°í ÆË¾÷Ã¢À» ´Ý½À´Ï´Ù.
            string playerName = firstName + " " + secondName;
            PlayerPrefs.SetString(playerNameKey, playerName);
            PlayerPrefs.Save();
            Debug.Log("Player name saved: " + playerName);

            // ÆË¾÷Ã¢À» ´Ý½À´Ï´Ù.
            popupPanel.SetActive(false);
        }
        else
        {
            // Á¶°ÇÀ» ¸¸Á·ÇÏÁö ¾Ê´Â °æ¿ì °æ°í¸¦ Ãâ·ÂÇÕ´Ï´Ù.
            Debug.LogWarning("Invalid name format. Please enter valid names.");
        }
    }

    // ÀÌ¸§ÀÇ À¯È¿¼ºÀ» °Ë»çÇÏ´Â ¸Þ¼­µå
    private bool IsValidName(string name)
    {
        // ÇÑ±Û¸¸ ÀÔ·Â °¡´ÉÇÏ°í, ÁöÁ¤µÈ ±æÀÌ ¹üÀ§ ³»¿¡ ÀÖ´ÂÁö È®ÀÎÇÕ´Ï´Ù.
        return Regex.IsMatch(name, "^[°¡-ÆR]*$") && name.Length <= firstNameMaxLength;
    }

    // ÀÔ·Â ÇÊµå¿¡ ÇÑ±Û¸¸ ÀÔ·ÂµÇµµ·Ï ÇÊÅÍ¸µÇÏ´Â ¸Þ¼­µå
    private void FilterInput(InputField inputField, int maxLength)
    {
        string filteredText = Regex.Replace(inputField.text, "[^°¡-ÆR]", "");
        // ÀÔ·Â ±æÀÌ°¡ ÃÖ´ë ±æÀÌ¸¦ ÃÊ°úÇÏ¸é ÀÔ·ÂÀ» ¸·½À´Ï´Ù.
        if (filteredText.Length > maxLength)
        {
            filteredText = filteredText.Substring(0, maxLength);
        }
        inputField.text = filteredText;
    }
}
