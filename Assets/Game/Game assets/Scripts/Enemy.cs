using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SWS;

public class Enemy : MonoBehaviour {
    
	public NavMeshAgent agent;
	public Animator anim;
	
	
	
	public float jumpAttackDistance;
	
	public float walkspeed;
	public float runspeed;
	
	
	
	Transform player;
	 MoveArea area;
	
	//bool spawned;
	public bool angry;
	
	Vector3 randomTarget;
	NavMeshPath path;
	Renderer rend;
	
	void Start(){
        path = new NavMeshPath();
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        //gameObject.GetComponent<splineMove>().moveToPath = true;

        angry = false;
    }
	
	void Update(){



        if (angry && player != null)
        {
            agent.CalculatePath(player.position, path);

            agent.destination = player.position;

            if (anim.GetInteger("State") != 2)
            {
                anim.SetInteger("State", 2);
                agent.speed = runspeed;
                agent.stoppingDistance = jumpAttackDistance;
            }

            if (Vector3.Distance(transform.position, player.position) < agent.stoppingDistance + 0.1f)
            {
                agent.isStopped = true;
                transform.LookAt(player.position);
                anim.SetInteger("State", 3);

                StartCoroutine(Attack());
            }
        }
        else if (player == null)
        {
          //  Debug.Log("NULL");
            angry = false;
            anim.SetInteger("State", 3);

            //    gameObject.GetComponent<splineMove>().Resume();

            //    gameObject.GetComponent<splineMove>().Resume();
            //  gameObject.GetComponent<NavMeshAgent>().enabled = false;

        }
        else {
            //
        }
    }
	

	
	
	
	
	
	IEnumerator Attack(){
        GameManager.instance.GameOver(player);
        GameManager.instance.attacked = true;
        yield return new WaitForSeconds(0.5f);
		
		if( Vector3.Distance(transform.position, player.position) > agent.stoppingDistance + 0.1f){
			agent.isStopped = false;
			anim.SetInteger("State", 2);
		//	spawned = true;
		}
		else{
		//	manager.GameOver();
			//ContinueWalking();
		}
	}
}
