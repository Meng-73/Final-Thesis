using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//点击人物关闭弹窗（场景1）
public class Quit : MonoBehaviour
{
    //退出打开对话框
    public void Click()
    {
        gameObject.SetActive(false);

    }
}
