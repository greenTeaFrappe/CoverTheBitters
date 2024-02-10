using UnityEngine;
using UnityEngine.UI;

// State 인터페이스
public interface IScriptOutputState
{
    int HandleState(string name, Image img);
}

public class StateNomal : IScriptOutputState
{
    public string spritePath= "Sprites/Sprites";
    public Sprite goldGirl, blueGirl;


    public int HandleState(string name, Image img)
    {
        switch (name)
        {
            case "금발여캐":
                spritePath += "/금발여캐/nomal";
                goldGirl = Resources.Load<Sprite>(spritePath);
                img.sprite = goldGirl;
                break;
            case "청발여캐":
                img.sprite = blueGirl;
                break;
            default:
                break;
        }

        return 1;
    }
}
public class StateAngry : IScriptOutputState
{
    public Sprite goldGirl, blueGirl;
    public int HandleState(string name, Image img)
    {
        switch (name)
        {
            case "금발여캐":
                img.sprite = goldGirl;
                break;
            case "청발여캐":
                img.sprite = blueGirl;
                break;
            default:
                break;
        }
        return 1;
    }
}
public class StateSad : IScriptOutputState
{
    public Sprite goldGirl, blueGirl;
    public int HandleState(string name, Image img)
    {
        switch (name)
        {
            case "금발여캐":
                img.sprite = goldGirl;
                break;
            case "청발여캐":
                img.sprite = blueGirl;
                break;
            default:
                break;
        }
        return 1;
    }
}
public class StateShy : IScriptOutputState
{
    public Sprite goldGirl, blueGirl;
    public int HandleState(string name, Image img)
    {
        switch (name)
        {
            case "금발여캐":
                img.sprite = goldGirl;
                break;
            case "청발여캐":
                img.sprite = blueGirl;
                break;
            default:
                break;
        }
        return 1;
    }
}
public class StateSmile : IScriptOutputState
{
    public Sprite goldGirl, blueGirl;
    public int HandleState(string name, Image img)
    {
        switch (name)
        {
            case "금발여캐":
                img.sprite = goldGirl;
                break;
            case "청발여캐":
                img.sprite = blueGirl;
                break;
            default:
                break;
        }
        return 1;
    }
}

public class ScriptOutputState : MonoBehaviour
{
    
    public Image img;

    private IScriptOutputState currentState;

    void Start()
    {
        // 초기 상태 설정
        currentState = new StateNomal();
    }

    public int SOState(int facialExpression, string name)
    {
        switch (facialExpression)
        {
            case 0:
                currentState = new StateNomal();
                currentState.HandleState(name, img);
                Debug.Log("nomal");
                break;
            case 1:
                currentState = new StateAngry();
                currentState.HandleState(name, img);
                Debug.Log("angry");
                break;
            case 2:
                currentState = new StateSad();
                currentState.HandleState(name, img);
                Debug.Log("sad");
                break;
            case 3:
                currentState = new StateShy();
                currentState.HandleState(name, img);
                Debug.Log("shy");
                break;
            case 4:
                currentState = new StateSmile();
                currentState.HandleState(name, img);
                Debug.Log("smile");
                break;
            default:
                Debug.LogError("Invalid facial expression value");
                break;
        }
        return 0;
    }
}
