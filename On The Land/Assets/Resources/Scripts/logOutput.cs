using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class logOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;

    public ScrollRect scrollRect;
    public GameObject chatItemPrefab; // ��ȭ �׸� ������
    public Transform content; // ScrollRect Content

    private ScriptOutput scriptOutput; // ScriptOutput ������Ʈ�� �����ϱ� ���� ���� �߰�

    public int logCount;
    public int itemHeight = 100;


    private void Start()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);
        logBtn.onClick.AddListener(TaskOnClick);

        // ScriptOutput ������Ʈ ��������
        scriptOutput = GetComponent<ScriptOutput>();

        // content�� null�̸� �ڽ� ������Ʈ���� ã�Ƽ� �Ҵ�
        if (content == null)
        {
            content = scrollRect.content;
        }
    }

    void TaskOnClick()
    {
        scrollRect.gameObject.SetActive(true);
        backBtn.gameObject.SetActive(true);

        logBtn.gameObject.SetActive(false);

        backBtn.onClick.AddListener(Task2OnClick);

        // ScriptOutput ������Ʈ�� �����ϴ��� Ȯ��
        if (scriptOutput != null)
        {
            // ���� ��ȭ �׸� ����
            foreach (Transform child in content)
            {
                Destroy(child.gameObject);
            }

            // count ������ŭ�� ��ҵ��� �����Ͽ� content�� �߰�
            for (int i = 0; i < scriptOutput.count; i++)
            {
                GameObject chatItem = Instantiate(chatItemPrefab, content);

                // ������ ������ logText�� chatImage ������Ʈ ã��
                TextMeshProUGUI logText = chatItem.transform.Find("logText").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI name = chatItem.transform.Find("name").GetComponent<TextMeshProUGUI>();
                UnityEngine.UI.Image pfpImg = chatItem.transform.Find("pfpImg").GetComponent<UnityEngine.UI.Image>();

                if (logText != null && name != null)
                {
                    logText.text = scriptOutput.texts[i];
                    name.text = scriptOutput.names[i];
                }

                if (pfpImg != null)
                {
                    switch (scriptOutput.names[i])
                    {
                        case "�ȳ�": //�Ǿ�ȭ
                            pfpImg.sprite = scriptOutput.pfpImages[0];
                            break;
                        case "������": //���̻�
                            pfpImg.sprite = scriptOutput.pfpImages[1];
                            break;
                        case "�Ƽ�": //�ϼ�ȣ
                            pfpImg.sprite = scriptOutput.pfpImages[2];
                            break;
                        case "��ҹ�":
                            pfpImg.sprite = scriptOutput.pfpImages[3];
                            break;
                        default: // �� �� �����ι�
                            pfpImg.sprite = scriptOutput.pfpImages[4];
                            break;
                    }
                }
                RectTransform chatItemRect = chatItem.GetComponent<RectTransform>();
                chatItemRect.anchoredPosition = new Vector2(0, -i * itemHeight);

            }
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, scriptOutput.count * itemHeight);
        }
    }

    void Task2OnClick()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);

        logBtn.gameObject.SetActive(true);
    }
}
