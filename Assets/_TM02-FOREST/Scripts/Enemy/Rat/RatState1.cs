using UnityEngine;

public class RatState1 : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    private Transform _posiPlayer;
    private float _speed = 3f;
    private int _horizontal;
    private Rat _rat;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _posiPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        // _slime = animator.GetComponent<Slime>();
        _rat = animator.GetComponent<Rat>();
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _horizontal = _rat.GetHorizontal();
        //Debug.Log(_horizontal);
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        animator.transform.Translate(_rb.velocity * Time.deltaTime * _speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
