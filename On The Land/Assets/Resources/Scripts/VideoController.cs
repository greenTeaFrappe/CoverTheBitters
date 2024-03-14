using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;

    void Start()
    {
        // Video Player 컴포넌트의 이벤트에 OnVideoEnd 함수를 연결합니다.
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // 비디오가 끝에 도달하면 다음 씬으로 넘어갑니다.
        SceneManager.LoadScene(nextSceneName);
    }
}
