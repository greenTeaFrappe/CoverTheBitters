using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class albumSelect : MonoBehaviour
{ 
    public Button EAChangeBtn;
    public Button SAChangeBtn;
    public GameObject EAScreen;
    public GameObject SAScreen;
    private isEABtnClicked = false;
    private isSABtnClicked = false;
    void Start()
    {
        EAScreen.SetActive(true);
        SAScreen.SetActive(false);
        Button Eabtn = EAChangeBtn.GetComponent<Button>();
        Button SAbtn = SAChangeBtn.GetComponent<Button>();
        Eabtn.onClick.AddListener(() =>
        {
            isEABtnClicked = !isEABtnClicked;
            if (isEABtnClicked)
            {
                EAScreen.SetActive(false);
            }
            else
            {
                EAScreen.SetActive(false);
            }
        });

        SAbtn.onClick.AddListener(() =>
        {
            isSABtnClicked = !isSABtnClicked;
            if (isSABtnClicked)
            {

            }
            else
            {

            }
            

        })
    }


}
