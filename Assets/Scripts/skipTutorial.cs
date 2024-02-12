using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skipTutorial : MonoBehaviour
{
    
    [SerializeField] private GameObject levelLoaderTransition;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private AudioSource videoAudio;

    private void Awake()
    {
        StartCoroutine(VideoEndSkipTutorial());
    }

    public void OnClickSkipTutorial()
    {
        videoAudio.Pause();
        videoPlayer.SetActive(false);
        levelLoaderTransition.SetActive(true);
        levelLoader.LoadNextLevel();
    }



    IEnumerator VideoEndSkipTutorial()
    {
        yield return new WaitForSeconds(videoAudio.clip.length);
        OnClickSkipTutorial();
    }
}
