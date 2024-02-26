using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playData
{
    public string time;
    public int currentSceneNum;

    //»£∞®µµ 
    //hp
}

public class dataManager : MonoBehaviour
{

    public static dataManager instance;

    playData nowData = new playData();

    string path;
    string fileName = "save";

    private void Awake()
    {
        //ΩÃ±€≈Ê
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.persistentDataPath + "/";
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    public void saveData()
    {
        string data = JsonUtility.ToJson(nowData);
        File.WriteAllText(path + fileName, data);
    }

    public void loadData()
    {
        string data = File.ReadAllText(path + fileName);
        nowData = JsonUtility.FromJson<playData>(data);
    }
}
