using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//场景2中自己写的玩家（办公男）
public class PlayerControll : MonoBehaviour
{

    private Animator animator;

    public float speed = 2f; //在面板上修改速度



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        //水平轴
        float horizontal = Input.GetAxis("Horizontal");

        //垂直轴
        float vertical = Input.GetAxis("Vertical");

        //向量
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        

        //切换动画
        //当用户按下按键
        if (dir != Vector3.zero)
        {

            //面向向量
            transform.rotation = Quaternion.LookRotation(dir);

            //播放跑步动画
            animator.SetBool("IsRun",true);

            //朝向前方移动
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

      
        }else
        {
            //播放站立动画
            animator.SetBool("IsRun", false);
        
        }

        //跳跃
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    animator.SetBool("IsJump", true);

        //}
        //else
        //{
        //    //播放站立动画
        //    animator.SetBool("IsJump", false);

        //}




    }






}
