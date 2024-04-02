using UnityEngine;
using UnityEngine.UI;

public class quiteScript : MonoBehaviour
{
    public Button quitBtn;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = quitBtn.GetComponent<Button>();
        btn.onClick.AddListener(quitBtnClick);
    }

    // Update is called once per frame
    void quitBtnClick()
    {
        UnityEngine.Application.Quit();
    }
}
