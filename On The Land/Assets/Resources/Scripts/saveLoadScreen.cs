using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class saveLoadScreen : MonoBehaviour
{
    public GameObject loadScreen;
    
    public Button loadBtn;
    
    public Button loadBackBtn;


    // Start is called before the first frame update
    void Start()
    {
        loadScreen.gameObject.SetActive(false);

        loadBtn.onClick.AddListener(loadTaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
    void loadTaskOnClick()
    {
        loadScreen.gameObject.SetActive(true);

        loadBackBtn.onClick.AddListener(loadTask2OnClick);
    }


    void loadTask2OnClick()
    {
        loadScreen.gameObject.SetActive(false);
    }
}
