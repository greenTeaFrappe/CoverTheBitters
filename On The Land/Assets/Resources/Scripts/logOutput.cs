using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class logOutput : MonoBehaviour
{
    public Button logBtn;
    public Button backBtn;

    public ScrollRect scrollRect;
    public GameObject chatItemPrefab; // ��ȭ �׸� ������
    public Transform content; // ScrollRect Content

    private ScriptOutput scriptOutput; // ScriptOutput ������Ʈ�� �����ϱ� ���� ���� �߰�

    public int logCount;

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

                // �ؽ�Ʈ�� �̹��� ����
                UnityEngine.UI.Text chatText = chatItem.GetComponentInChildren<UnityEngine.UI.Text>();
                UnityEngine.UI.Image chatImage = chatItem.GetComponentInChildren<UnityEngine.UI.Image>();

                if (chatText != null)
                {
                    chatText.text = scriptOutput.names[i] + " : " + scriptOutput.texts[i];
                }

                if (chatImage != null)
                {
                    switch (scriptOutput.names[i])
                    {
                        case "�ȳ�": //�Ǿ�ȭ
                            chatImage.sprite = scriptOutput.pfpImages[0];
                            break;
                        case "������": //���̻�
                            chatImage.sprite = scriptOutput.pfpImages[1];
                            break;
                        case "�Ƽ�": //�ϼ�ȣ
                            chatImage.sprite = scriptOutput.pfpImages[2];
                            break;
                        case "��ҹ�":
                            chatImage.sprite = scriptOutput.pfpImages[3];
                            break;
                        default: // �� �� �����ι�
                            chatImage.sprite = scriptOutput.pfpImages[4];
                            break;
                    }
                }
            }
        }
    }

    void Task2OnClick()
    {
        scrollRect.gameObject.SetActive(false);
        backBtn.gameObject.SetActive(false);

        logBtn.gameObject.SetActive(true);
    }
}
