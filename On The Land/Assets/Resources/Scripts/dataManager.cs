using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class playData
{
    public string time;
    public string currentSceneNum;
    public string slotName;
    //»£∞®µµ 
    //hp
}

public class dataManager : MonoBehaviour
{
    public static dataManager instance;

    public playData nowData = new playData();

    public string path;
    public int nowSlot;
    
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

        path = Application.persistentDataPath + "/save";
        print(path);
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    public void saveData()
    {
        string data = JsonUtility.ToJson(nowData);
        File.WriteAllText(path, data);
    }

    public void loadData()
    {
        string data = File.ReadAllText(path);
        nowData = JsonUtility.FromJson<playData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowData = new playData();
    }
}
