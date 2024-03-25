using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endingCredits : MonoBehaviour
{

    public float scrollSpeed = 20f; // ũ���� ��ũ�� �ӵ�
    public RectTransform creditsText; // ũ���� �ؽ�Ʈ�� RectTransform

    private void Start()
    {
        // ũ���� �ؽ�Ʈ ���� ��ġ�� ȭ�� �Ʒ��� ����
        creditsText.anchoredPosition = new Vector2(0f, -Screen.height);
    }

    private void Update()
    {
        // ũ������ �Ʒ��� ��ũ��
        creditsText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // ���� ũ������ ȭ���� ����� �ʱ� ��ġ�� �̵�
        if (creditsText.anchoredPosition.y >= 0f)
        {
            // ũ���� �ؽ�Ʈ ���� ��ġ�� ȭ�� �Ʒ��� ����
            creditsText.anchoredPosition = new Vector2(0f, -Screen.height);
        }
    }

}
