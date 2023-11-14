using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//场景2开始的黑屏过渡
//淡入
public class SceneFader : MonoBehaviour
{

    public Image imageEffect;//黑屏过渡的图片在Canvas中

    public float speed = 1f;//黑屏过渡的速度


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneLoadIn());//开启淡入的协程
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //图片的透明度从1到0，如果透明度>0，则一直往下不断的减，直到透明度=0
    IEnumerator SceneLoadIn()
    {
        //yield return null;//等待一帧

        Color tempColor = imageEffect.color;
        tempColor.a = 1;
        imageEffect.color = tempColor;

        while (imageEffect.color.a >0)
        {
            imageEffect.color += new Color(0, 0, 0, -speed * Time.deltaTime);

            yield return null;//等待一帧

        }
       
    }

}
