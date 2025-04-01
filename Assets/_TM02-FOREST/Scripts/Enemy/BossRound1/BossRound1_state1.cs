using UnityEngine;

public class BossRound1_state1 : StateMachineBehaviour
{
    private float speed = 5f;
    public float attackRange = 3f;
    private int cnt;
    Transform player;
    Rigidbody2D rb; 
    BossRound1_Manager boss;
    private float rangeXR;
    private float rangeXL;
    private EnemyHealth _enemyHealth;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossRound1_Manager>();
        _enemyHealth = animator.GetComponent<EnemyHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // speed = _enemyHealth.GetSpeed();
        // //boss.LookAtPlayer();
        // Vector2 target = new Vector2(player.position.x, rb.position.y);
        // Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        // rb.MovePosition(newPos);
        // if(Vector2.Distance(player.position, rb.position) <= attackRange)
        // {
        //     animator.SetTrigger("Attack");
        // }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
