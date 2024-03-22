using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveImg : MonoBehaviour
{
    public Sprite collectedImage; // ������ �̹���
    public Button collectButton; // �̹����� ������ ��ư

    private bool isCollected = false; // �̹����� �����Ǿ����� ����

    void Start()
    {
        // �̹��� ���� ��ư�� Ŭ�� �̺�Ʈ ������ �߰�
        collectButton.onClick.AddListener(CollectImage);
    }

    void CollectImage()
    {
        // �̹����� ���� �������� ���� ��쿡�� ���� ���¸� ������Ʈ�ϰ� PlayerPref�� ����
        if (!isCollected)
        {
            isCollected = true;
            PlayerPrefs.SetInt("CollectedImage_" + gameObject.name, 1); // �̹����� ������ ������ ǥ��
            PlayerPrefs.Save(); // ���� ������ ����

            // UI �� �̹��� �߰� ���� ������Ʈ ������ ���⿡ �߰��� �� �ֽ��ϴ�.
            Debug.Log("Image collected: " + collectedImage.name);
        }
        else
        {
            Debug.Log("Image already collected!");
        }
    }
}
