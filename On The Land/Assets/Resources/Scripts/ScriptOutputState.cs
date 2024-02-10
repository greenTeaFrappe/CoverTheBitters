using UnityEngine;
using UnityEngine.UI;

// State 인터페이스
public interface IScriptOutputState
{
    int HandleState(string name, Image img);
}

public class StateNomal : IScriptOutputState
{
    private string goldGirlPath = "Sprites/금발여캐/nomal";
    private string blueGirlPath = "Sprites/청발여캐/nomal";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "금발여캐":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "청발여캐":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for nomal state: " + name);
            return -1; // 처리 실패
        }
    }
}
public class StateSad : IScriptOutputState
{
    private string goldGirlPath = "Sprites/금발여캐/sad";
    //청발 여캐는 sad 표정이 없어서 임시로 쎄함으로 넣어둠
    private string blueGirlPath = "Sprites/청발여캐/sharpe";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "금발여캐":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "청발여캐":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateSmile : IScriptOutputState
{
    private string goldGirlPath = "Sprites/금발여캐/smile";
    private string blueGirlPath = "Sprites/청발여캐/smile";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "금발여캐":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "청발여캐":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // 처리 실패
        }
    }
}
public class StateShy : IScriptOutputState
{
    private string goldGirlPath = "Sprites/금발여캐/shy";
    private string blueGirlPath = "Sprites/청발여캐/shy";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "금발여캐":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "청발여캐":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateAngry : IScriptOutputState
{
    private string goldGirlPath = "Sprites/금발여캐/angry";
    private string blueGirlPath = "Sprites/청발여캐/angry";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "금발여캐":
                spriteToLoad = Resources.Load<Sprite>(goldGirlPath);
                break;
            case "청발여캐":
                spriteToLoad = Resources.Load<Sprite>(blueGirlPath);
                break;
            default:
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state: " + name);
            return -1; // 처리 실패
        }
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
