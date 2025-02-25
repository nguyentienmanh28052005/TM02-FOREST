using UnityEngine;

public class Attack : StateMachineBehaviour
{
    private float rangeXR;
    private float rangeXL;
    private int _horizontal;
    Transform player;
    private float _speed = 1.5f;
    private Rigidbody2D _rb;

    private Slime _slime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _rb = animator.GetComponent<Rigidbody2D>();
        rangeXR = animator.GetComponent<Slime>().GetrangeXR();
        rangeXL = animator.GetComponent<Slime>().GetrangeXL();
        _slime = animator.GetComponent<Slime>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _horizontal = _slime.GetHorizontal();
        //Debug.Log(_horizontal);
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        animator.transform.Translate(_rb.velocity * Time.deltaTime * _speed);
        if (player.position.x < rangeXL || player.position.x > rangeXR)
        {
            //Debug.Log("hi");
            animator.SetBool("Angry", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
