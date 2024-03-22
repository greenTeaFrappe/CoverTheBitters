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


    void Start()
    {
        EAScreen.SetActive(true);
        SAScreen.SetActive(false);
        Button Eabtn = EAChangeBtn.GetComponent<Button>();
        Button SAbtn = SAChangeBtn.GetComponent<Button>();
        Eabtn.onClick.AddListener(() =>
        {
            SAScreen.SetActive(false);
            EAScreen.SetActive(true);

        });

        SAbtn.onClick.AddListener(() =>
        {
            EAScreen.SetActive(false);
            SAScreen.SetActive(true);


        });
    }


}
