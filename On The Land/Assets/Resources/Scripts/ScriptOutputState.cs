using UnityEngine;
using UnityEngine.UI;


// State 인터페이스
public interface IScriptOutputState
{
    int HandleState(string name, Image img);
}

public class StateV1 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v1";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v1";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v1";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v1";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v1: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV2 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v2";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v2";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v2";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v2";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v2: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV3 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v3";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v3";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v3";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v3";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v3: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV4 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v4";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v4";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v4";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v4";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v4: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV5 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v5";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v5";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v5";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v5";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v5: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV6 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v6";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v6";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v6";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v6";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v6: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV7 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v7";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v7";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v7";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v7";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v7: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV8 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v8";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v8";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v8";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v8";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v8: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV9 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v9";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v9";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v9";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v9";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v9: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV10 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v10";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v10";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v10";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v10";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v10: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV11 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v11";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v11";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v11";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v11";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v11: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV12 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v12";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v12";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v12";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v12";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v12: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV13 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v13";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v13";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v13";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v13";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v13: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV14 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v14";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v14";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v14";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v14";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v14: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV15 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v15";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v15";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v15";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v15";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v15: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV16 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v16";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v16";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v16";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v16";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v16: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV17 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v17";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v17";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v17";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v17";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v17: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV18 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v18";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v18";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v18";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v18";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v18: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV19 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v19";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v19";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v19";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v19";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "아이작":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v19: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV20 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v20";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v20";
    private string pesPath = "Sprites/Img/pesImg/TI_pes_v20";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v20";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "???":
                spriteToLoad = Resources.Load<Sprite>(pesPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v20: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV21 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v21";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v21";
    //private string pesPath = "Sprites/Img/pesImg/TI_pes_v21";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v21";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v21: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV22 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v22";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v22";
    //private string pesPath = "Sprites/Img/pesImg/TI_pes_v22";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v22";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v22: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV23 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v23";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v23";
    //private string pesPath = "Sprites/Img/pesImg/TI_pes_v23";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v23";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "아서":
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "안나":
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "양소미":
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v23: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV24 : IScriptOutputState
{
    private string hshPath = "Sprites/Img/hshImg/TI_hsh_v24";
    private string pahPath = "Sprites/Img/pahImg/TI_pah_v24";
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v24";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;

        switch (name)
        {
            case "?????": //수호
                spriteToLoad = Resources.Load<Sprite>(hshPath);
                break;
            case "??": //안나
                spriteToLoad = Resources.Load<Sprite>(pahPath);
                break;
            case "양소미": //소미
                spriteToLoad = Resources.Load<Sprite>(ysmPath);
                break;
            default:
                spriteToLoad = Resources.Load<Sprite>("Sprites/Img/default");
                break;
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v24: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV25 : IScriptOutputState
{
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v25";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;
        if (name == "양소미")
        {
            spriteToLoad = Resources.Load<Sprite>(ysmPath);
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v24: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV26 : IScriptOutputState
{
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v26";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;
        if (name == "양소미")
        {
            spriteToLoad = Resources.Load<Sprite>(ysmPath);
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v24: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV27 : IScriptOutputState
{
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v27";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;
        if (name == "양소미")
        {
            spriteToLoad = Resources.Load<Sprite>(ysmPath);
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v24: " + name);
            return -1; // 처리 실패
        }
    }
}

public class StateV28 : IScriptOutputState
{
    private string ysmPath = "Sprites/Img/ysmImg/TI_ysm_v28";

    public int HandleState(string name, Image img)
    {
        Sprite spriteToLoad = null;
        if (name == "양소미")
        {
            spriteToLoad = Resources.Load<Sprite>(ysmPath);
        }

        if (spriteToLoad != null)
        {
            img.sprite = spriteToLoad;
            return 1; // 처리 성공
        }
        else
        {
            Debug.LogError("Failed to load sprite for state v24: " + name);
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
        currentState = new StateV1();
    }

    public int SOState(int facialExpression, string name)
    {
        switch (facialExpression)
        {
            case 1:
                currentState = new StateV1();
                Debug.Log("v1");
                break;
            case 2:
                currentState = new StateV2();
                Debug.Log("v2");
                break;
            case 3:
                currentState = new StateV3();
                Debug.Log("v3");
                break;
            case 4:
                currentState = new StateV4();
                Debug.Log("v4");
                break;
            case 5:
                currentState = new StateV5();
                Debug.Log("v5");
                break;
            case 6:
                currentState = new StateV6();
                Debug.Log("v6");
                break;
            case 7:
                currentState = new StateV7();
                Debug.Log("v7");
                break;
            case 8:
                currentState = new StateV8();
                Debug.Log("v8");
                break;
            case 9:
                currentState = new StateV9();
                Debug.Log("v9");
                break;
            case 10:
                currentState = new StateV10();
                Debug.Log("v10");
                break;
            case 11:
                currentState = new StateV11();
                Debug.Log("v11");
                break;
            case 12:
                currentState = new StateV12();
                Debug.Log("v12");
                break;
            case 13:
                currentState = new StateV13();
                Debug.Log("v13");
                break;
            case 14:
                currentState = new StateV14();
                Debug.Log("v14");
                break;
            case 15:
                currentState = new StateV15();
                Debug.Log("v15");
                break;
            case 16:
                currentState = new StateV16();
                Debug.Log("v16");
                break;
            case 17:
                currentState = new StateV17();
                Debug.Log("v17");
                break;
            case 18:
                currentState = new StateV18();
                Debug.Log("v18");
                break;
            case 19:
                currentState = new StateV19();
                Debug.Log("v19");
                break;
            case 20:
                currentState = new StateV20();
                Debug.Log("v20");
                break;
            case 21:
                currentState = new StateV21();
                Debug.Log("v21");
                break;
            case 22:
                currentState = new StateV22();
                Debug.Log("v22");
                break;
            case 23:
                currentState = new StateV23();
                Debug.Log("v23");
                break;
            case 24:
                currentState = new StateV24();
                Debug.Log("v24");
                break;
            //case 25:
            //    currentState = new StateV25();
            //    Debug.Log("v25");
            //    break;
            default:
                Debug.LogError("Invalid facial expression value");
                return -1;
        }

        return currentState.HandleState(name, img);
    }
}
