using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class speedOption : MonoBehaviour
{
    public Dropdown speedDropdown;
    public float[] speedOptions = { 0.5f, 1.0f, 1.5f, 2.0f };
    public int currentIndex;

    void Start()
    {
        InitDropdown();
        speedDropdown.onValueChanged.AddListener(OnSpeedChanged);
    }

    // Update is called once per frame
    private void InitDropdown()
    {
        speedDropdown.ClearOptions();

        foreach (float speed in speedOptions)
        {
            string optionText = speed.ToString() + "¹è¼Ó";
            speedDropdown.options.Add(new Dropdown.OptionData(optionText));
        }

        speedDropdown.RefreshShownValue();
    }

    public void OnSpeedChanged(int index)
    {
        speedDropdown.value = index;
        currentIndex = index;
    }

    public float GetCurrentSpeed()
    {
        return speedOptions[currentIndex];
    }
}
