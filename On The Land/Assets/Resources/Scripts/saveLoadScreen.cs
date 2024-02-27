using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SaveLoadScreen : MonoBehaviour
{
    public GameObject saveScreen;
    public GameObject loadScreen;
    
    public Button saveBtn;
    public Button loadBtn;
    
    public Button saveBackBtn;
    public Button loadBackBtn;

    ScriptOutput scriptOutput = new ScriptOutput();

    // Start is called before the first frame update
    void Start()
    {
        saveScreen.gameObject.SetActive(false);
        loadScreen.gameObject.SetActive(false);

        saveBtn.onClick.AddListener(saveTaskOnClick);
        loadBtn.onClick.AddListener(loadTaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void saveTaskOnClick()
    {
        saveScreen.gameObject.SetActive(true);
        
        saveBackBtn.onClick.AddListener(saveTask2OnClick);
    }

    void loadTaskOnClick()
    {
        loadScreen.gameObject.SetActive(true);

        loadBackBtn.onClick.AddListener(loadTask2OnClick);
    }

    void saveTask2OnClick()
    {
        saveScreen.gameObject.SetActive(false);
        
    }

    void loadTask2OnClick()
    {
        loadScreen.gameObject.SetActive(false);
    }
}
