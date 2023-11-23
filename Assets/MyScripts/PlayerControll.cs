using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//scene 2 player
public class PlayerControll : MonoBehaviour
{

    private Animator animator;

    public float speed = 2f; //speed



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


      
        float horizontal = Input.GetAxis("Horizontal");

        
        float vertical = Input.GetAxis("Vertical");

      
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        

       
        if (dir != Vector3.zero)
        {

           
            transform.rotation = Quaternion.LookRotation(dir);

  
            animator.SetBool("IsRun",true);

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

      
        }else
        {
  
            animator.SetBool("IsRun", false);
        
        }

     




    }






}
