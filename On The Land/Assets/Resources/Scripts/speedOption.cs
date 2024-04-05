using UnityEngine;
using UnityEngine.UI;

public class speedOption : MonoBehaviour
{
    public Dropdown speedDropdown;
    public float[] speedOptions = { 0.5f, 1.0f, 1.5f, 2.0f };

    private void Start()
    {
        // ��Ӵٿ� �ɼ� �ʱ�ȭ
        InitializeOptions();

        // ������ ����� �ӵ� �ɼ� �ҷ�����
        LoadSelectedSpeed();

        // ��Ӵٿ� ���� ����� ������ ����
        speedDropdown.onValueChanged.AddListener(OnSpeedChanged);
    }

    // ��Ӵٿ� �ɼ� �ʱ�ȭ
    private void InitializeOptions()
    {
        speedDropdown.ClearOptions();

        foreach (float speed in speedOptions)
        {
            string optionText = speed.ToString() + "���";
            speedDropdown.options.Add(new Dropdown.OptionData(optionText));
        }

        speedDropdown.RefreshShownValue();
    }

    // ��Ӵٿ� ���� ����Ǿ��� �� ȣ��Ǵ� �޼���
    private void OnSpeedChanged(int index)
    {
        // ����� �ε����� PlayerPrefs�� ����
        PlayerPrefs.SetInt("SelectedSpeedIndex", index);
        PlayerPrefs.Save();
    }

    // ������ ����� �ӵ� �ɼ� �ҷ�����
    private void LoadSelectedSpeed()
    {
        if (PlayerPrefs.HasKey("SelectedSpeedIndex"))
        {
            int selectedIndex = PlayerPrefs.GetInt("SelectedSpeedIndex");
            speedDropdown.value = selectedIndex;
        }
    }

    // ���� ���õ� �ӵ� ��ȯ
    public float GetCurrentSpeed()
    {
        int selectedIndex = speedDropdown.value;
        return speedOptions[selectedIndex];
    }
}
