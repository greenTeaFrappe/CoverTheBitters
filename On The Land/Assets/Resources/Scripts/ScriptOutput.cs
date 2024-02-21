using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptOutput : MonoBehaviour
{
    public Button setA;
    public Button setB;

    // �迭 ���� ����
    public string[] texts;
    public int[] facialExpressions;
    public string[] names;

    public Text nameText;
    public Text scripts;

    public int count=0;

    private void Start()
    {
        setA.gameObject.SetActive(false);
        setB.gameObject.SetActive(false);
    }   

    private void Update()
    {

        // ���콺 Ŭ�� ����
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown("space"))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                HandleMouseClick();
                //Ŭ�� ó��
            }

        }
    }

    private void HandleMouseClick()
    {
        if(count< texts.Length)
        {
            nameText.text = names[count];
            scripts.text = texts[count];

            //state ���� �����ؾ���
            ScriptOutputState state = GetComponent<ScriptOutputState>();
            state.SOState(facialExpressions[count], names[count]);
            count++;
        }
        else
        {
            setA.gameObject.SetActive(true);
            setB.gameObject.SetActive(true);
        }
    }

}
