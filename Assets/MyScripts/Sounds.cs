using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//所有场景的声音设置
//（没有游戏物体，为了给AudioManager代码做设定）

[System.Serializable]
public class Sounds 
{
    public string name;

    public AudioClip clip;

    public float volume;

    public bool loop;

    public AudioSource source;

}
