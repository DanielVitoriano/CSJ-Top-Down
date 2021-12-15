using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float speed;
    private float initSpeed;
    private int index;
    private Animator anim;
    public List<Transform> paths = new List<Transform>();

    private void Start() {
        initSpeed = speed;
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if(Dialogue_controller.instance.IsShowing){
            speed = 0;
            anim.SetBool("isWalking", false);
        }
        else{
            speed = initSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f){
            if(index < paths.Count - 1){
                index = Random.Range(0, paths.Count - 1);
            }
            else{ index = 0;}
        }
        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0){
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if(direction.x < 0){
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}