using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    public float speed = 6.0f;
    private Vector3 moveDirection = Vector3.zero;
    Rigidbody rigidbody;
    public float fireRate = 0.4f;
    public float nextFire = 0.0f;
    public GameObject bullet, Gun;
    public GameLogic gameLogic;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded){
            animator.SetBool("Run",false);

            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0.0f,Input.GetAxis("Vertical"));
            moveDirection *= speed;
            if(Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical")!=0){
                animator.SetBool("Run", true);

            }

            if(Input.GetAxis("Vertical") < 0){
                this.transform.rotation = Quaternion.Euler(0,180,0);
            }else{
                this.transform.rotation = Quaternion.Euler(0,0,0);
            }

            if(Input.GetMouseButton(0) && Time.time > nextFire){
                nextFire = Time.time + fireRate;
                Fire();

            }

        }
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Fire(){
        animator.SetBool("Attack",true);
        StartCoroutine(returnState());
        Instantiate(bullet,Gun.transform.position,Gun.transform.rotation);

    }

    IEnumerator returnState(){
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attack",false);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Item"){
            Destroy(other.gameObject);
            gameLogic.GetScore();
        }
    }




}
