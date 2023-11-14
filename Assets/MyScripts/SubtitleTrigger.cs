using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//字幕2、3，立方体触发器
public class SubtitleTrigger : MonoBehaviour
{
    [System.Serializable]
    public struct Subtitle
    {
        public string text;
        public float startTime;
        public float duration;
    }

    public Subtitle[] subtitles;
    public Text subtitlesText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisplaySubtitles();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ClearSubtitles();
        }
    }

    private void DisplaySubtitles()
    {
        foreach (Subtitle subtitle in subtitles)
        {
            StartCoroutine(ShowSubtitle(subtitle));
        }
    }

    private System.Collections.IEnumerator ShowSubtitle(Subtitle subtitle)
    {
        yield return new WaitForSeconds(subtitle.startTime);

        subtitlesText.text = subtitle.text;
        yield return new WaitForSeconds(subtitle.duration);

        subtitlesText.text = "";
    }

    private void ClearSubtitles()
    {
        StopAllCoroutines();
        subtitlesText.text = "";
    }
}