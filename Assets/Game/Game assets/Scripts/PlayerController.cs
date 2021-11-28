using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
public class PlayerController : MonoBehaviour {
	
   public Joystick joystick;
   public CharacterController controller;
   public Animator anim;
   public Image bulletIndicator;
   public Transform targetIndicator;
   public Transform target;
   public ParticleSystem movementEffect;
   public ParticleSystem shootingEffect;
   public GameObject bloodEffect;
   
   public Transform gunFront;
   public GameObject bullet;
    AudioSource audio;
   public float speed;
   public float gravity;
   public float bulletCount;
   public float reloadSpeed;
   
   Vector3 moveDirection;
   float bullets = 1f;
   
   bool reloading;
   
   List<GameObject> bulletStorage = new List<GameObject>();

    public GameObject Box, player,bag;

   [HideInInspector]
   public bool safe;
   
   GameManager manager;
   
   void Start(){
        // manager = GameObject.FindObjectOfType<GameManager>();
        audio = GameObject.Find("ObstacleAudio").GetComponent<AudioSource>();
        player.SetActive(true);
        Box.SetActive(false);
    }
   
   void Update(){

        if (!GameManager.instance.isGameOver)
        {
            Vector2 direction = joystick.direction;

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(-direction.x, 0, -direction.y);

                Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
                transform.rotation = targetRotation;

                moveDirection = moveDirection * speed;
            }

            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
            controller.Move(moveDirection * Time.deltaTime);



            if (anim.GetBool("Moving") != (direction != Vector2.zero))
            {
                anim.SetBool("Moving", direction != Vector2.zero);

                if (direction != Vector2.zero)
                {
                    movementEffect.Play();
                    player.SetActive(true);
                    bag.SetActive(true);
                    Box.SetActive(false);
                }
                else
                {
                    movementEffect.Stop();
                    player.SetActive(false);
                    bag.SetActive(false);
                    Box.SetActive(true);
                }
            }
        }
		
   }
   
  /* public void Fire(){
	   GameObject newBullet = bulletStorage.Count > 0 ? recycleBullet() : Instantiate(bullet);
	   
	   newBullet.transform.rotation = transform.rotation;
	   newBullet.transform.position = gunFront.position;
	   
	   Bullet bulletController = newBullet.GetComponent<Bullet>();
	   bulletController.player = this;
	   shootingEffect.Play();
   }
   */
   public void SwitchSafeState(bool safe){
	   this.safe = safe;
	   
	   targetIndicator.gameObject.SetActive(!safe);
   }
   
   public void Die(){
	   Instantiate(bloodEffect, transform.position + Vector3.up * 1.5f, transform.rotation);
	   Destroy(gameObject);
   }
   
   GameObject recycleBullet(){
	   GameObject newBullet = bulletStorage[0];
	   bulletStorage.Remove(newBullet);
	   newBullet.SetActive(true);
	   
	   return newBullet;
   }
   
   public void DisableBullet(GameObject targetBullet){
	   targetBullet.SetActive(false);
	   bulletStorage.Add(targetBullet);
   }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            audio.Play();
            GameManager.instance.ScoreAdd();
            Object.Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("car")) {
            //  iTween.MoveTo(other.gameObject,iTween.Hash('x',8,"easetype"))
            
            other.gameObject.GetComponent<iTweenPositionTo>().iTweenPlay();
            Object.Destroy(gameObject);
        }
    }
}
