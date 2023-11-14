using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//开始界面，开始菜单，两个按钮
public class MainMenu : MonoBehaviour
{
    public Image imageEffect;//黑屏过渡的图片在Canvas中

    public float speed = 1;//黑屏过渡的速度


    public void PlayGame()
    {
        //SceneManager.LoadScene("SampleScene");
        StartCoroutine(SceneLoadOut());//开启协程
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    IEnumerator SceneLoadOut()
    {
        //yield return null;//等待一帧

        Color tempColor = imageEffect.color;
        tempColor.a = 0;
        imageEffect.color = tempColor;

        while (imageEffect.color.a < 1)
        {
            imageEffect.color += new Color(0, 0, 0, speed * Time.deltaTime);

            yield return null;//等待一帧

        }
        SceneManager.LoadScene("SampleScene");//加载场景
    }

}
