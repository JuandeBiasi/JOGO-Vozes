using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerManager : MonoBehaviour
{
    public string nextSceneName;

    void Start()
    {
        var videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = Application.streamingAssetsPath + "/intro.mp4";
        videoPlayer.loopPointReached += (_) => SceneManager.LoadScene(nextSceneName);
        videoPlayer.Play();
    }
}