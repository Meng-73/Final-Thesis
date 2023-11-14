using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//字幕管理器（字幕1）
[System.Serializable]
public struct Subtitle
{
    public string text;
    public float startTime;
    public float duration;

}



public class SubtitlesManager : MonoBehaviour
{


    public Text subtitlesText;
    public Subtitle[] subtitles;

    private Coroutine subtitlesCoroutine;

    private void Start()
    {
        StartDisplayingSubtitles();
    }

    private void StartDisplayingSubtitles()
    {
        subtitlesCoroutine = StartCoroutine(DisplaySubtitles());
    }

    private IEnumerator DisplaySubtitles()
    {
        foreach (Subtitle subtitle in subtitles)
        {
            yield return new WaitForSeconds(subtitle.startTime);

            subtitlesText.text = subtitle.text;
            yield return new WaitForSeconds(subtitle.duration);

            subtitlesText.text = "";
        }
    }

    public void StopDisplayingSubtitles()
    {
        if (subtitlesCoroutine != null)
        {
            StopCoroutine(subtitlesCoroutine);
            subtitlesCoroutine = null;
        }
    }




}
