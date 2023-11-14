using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//场景1中，门触发器，加载场景2
//加入了黑屏过渡（淡出）
public class DoorTrigger : MonoBehaviour
{

    public string sceneName = "Scene2";//定义场景


    public Image imageEffect;//黑屏过渡的图片在Canvas中

    public float speed = 1;//黑屏过渡的速度




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            FindObjectOfType<AudioManager>().PlaySound("Transfer");
            //播放音频
            //所有声音播放都用这句代码



            //黑屏透明度变化

            //SceneManager.LoadScene(sceneName);
            StartCoroutine(SceneLoadOut());//开启协程

            
        }
    }


    //协程（黑屏过渡）淡出
    //图片的透明度从0到1，如果透明度<0，则一直往上不断的加，直到透明度=1
    //https://www.bilibili.com/video/BV1Cm4y1i7jq?p=4&spm_id_from=pageDriver&vd_source=84edfb70ef913025c87fb8c33a197d8a

    IEnumerator SceneLoadOut()
    {
        //yield return null;//等待一帧

        Color tempColor = imageEffect.color ;
        tempColor.a = 0;
        imageEffect.color = tempColor;

        while (imageEffect.color.a<1)
        {
            imageEffect.color += new Color(0, 0, 0, speed * Time.deltaTime);

            yield return null;//等待一帧

        }
        SceneManager.LoadScene(sceneName);//加载场景
        
    }

 

}
