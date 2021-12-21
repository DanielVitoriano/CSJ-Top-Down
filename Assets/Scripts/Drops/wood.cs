using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    [SerializeField] private float speed, timeMove, timeAlive;
    private float timeCount;
    private int dir = -1; // essa dir é para a animação// -1 subindo  e 1 descendo
    private float control;
    private Vector2 direction;

    private void Start() {
        float x = Random.Range(-1.5f, 1.5f);
        float y = Random.Range(-1.5f, 1.5f);

        direction = new Vector2(x, y);
    }

    private void Update() {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove){
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else{
            StartCoroutine(destroy());
            transform.Translate(new Vector2(0, dir) * Time.deltaTime);
            control += Time.deltaTime;
            if(control >= .3f){
                dir *= -1;
                control = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerItens>().setWood(1);
            Destroy(gameObject);
        }
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
}
