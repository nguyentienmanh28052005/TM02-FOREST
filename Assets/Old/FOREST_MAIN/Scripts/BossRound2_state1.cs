using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRound2_state1 : StateMachineBehaviour
{

    public float speed = 0f;
    public float attackRange = 3f;
    private int cnt;
    Transform player;
    Rigidbody2D rb; 
    BossRound2Main boss2;
    private float delayTime = 0;
    private int Numrd;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss2 = animator.GetComponent<BossRound2Main>();
        boss2.SetSpeed(8);
        //Numrd = Random.Range(1, 6);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2.LookAtPlayer();
        //boss2.Move();
        // Vector2 target = new Vector2(player.position.x, rb.position.y);
        //  Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        //  rb.MovePosition(newPos);
        // if(Vector2.Distance(player.position, rb.position) <= attackRange)
        // {
        //     animator.SetTrigger("Attack");
        // }
         delayTime += Time.deltaTime;
        if (delayTime > 1f)
        {
            Numrd = Random.Range(4, 7);
            if (Numrd == 1)
            {
                animator.SetTrigger("atk"); 
            }
            else if (Numrd == 2)
            {
                animator.SetTrigger("atk1");
            }
            else if(Numrd == 3)
            {
                animator.SetTrigger("atk2");
            }   
            else if (Numrd == 4)
            {
                AudioManager.Instance.PlaySFX("atk3");
                animator.SetTrigger("atk3");
            }
            else if(Numrd == 5)
            {
                boss2.StartDash();
                animator.SetTrigger("superatk");
            }
            else if(Numrd == 6)
            {
                boss2.SetSpeed(20);
                animator.SetTrigger("Roll");
            }
            Debug.Log(Numrd);
            delayTime = 0;
        }
        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Numrd = Random.Range(1, 6);
        boss2.SetSpeed(0);
    }
}

// using UnityEngine;
//
// public class BossRound2_state1 : StateMachineBehaviour
// {
//     public float speed = 5f;
//     public float attackRange = 3f;
//     private int cnt;
//     Transform player;
//     Rigidbody2D rb; 
//     BossRound1 boss;
//     private float rangeXR;
//     private float rangeXL;
//
//     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         rb = animator.GetComponent<Rigidbody2D>();
//         boss = animator.GetComponent<BossRound1>();
//     }
//
//     // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//     override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         boss.LookAtPlayer();
//         Vector2 target = new Vector2(player.position.x, rb.position.y);
//         Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
//         rb.MovePosition(newPos);
//         if(Vector2.Distance(player.position, rb.position) <= attackRange)
//         {
//             animator.SetTrigger("superatk");
//         }
//     }
//
//     // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//     {
//         
//     }
// }
