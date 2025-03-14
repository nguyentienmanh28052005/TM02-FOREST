using UnityEngine;

public class SkeletonState1 : StateMachineBehaviour
{
    public float speed = 10f;
    public float attackRange = 3f;

    private int cnt;

    Transform player;
    Rigidbody2D rb; 
    SkeletonEnemyRound2 _skeleton;
    private float rangeXR;
    private float rangeXL;
    private int _horizontal;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        _skeleton = animator.GetComponent<SkeletonEnemyRound2>();
        rangeXL = animator.GetComponent<SkeletonEnemyRound2>().GetrangeXL();
        rangeXR = animator.GetComponent<SkeletonEnemyRound2>().GetrangeXR();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.transform.position.x > rangeXL && player.transform.position.x < rangeXR)
        {
            _skeleton.LookAtPlayer();
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
            if(Vector2.Distance(player.position, rb.position) <= attackRange)
            {
                animator.SetTrigger("attack");
            }
        }
        else
        {
            _horizontal = _skeleton.GetHorizontal();
            //Debug.Log(_horizontal);
            rb.velocity = new Vector2(_horizontal, rb.velocity.y);
            animator.transform.Translate(rb.velocity * Time.deltaTime * 5);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
