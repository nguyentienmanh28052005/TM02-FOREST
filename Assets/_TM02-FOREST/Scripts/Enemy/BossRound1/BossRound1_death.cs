using UnityEngine;

public class BossRound1_death : StateMachineBehaviour
{
    private GameObject _camBound;

    private GameObject _noSkip;

    private GameObject _key;
    private GameObject _data;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _camBound = GameObject.Find("CameraBound");
        _noSkip = GameObject.Find("NoSkip");
        _data = GameObject.Find("Data");
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPosition = _camBound.transform.position;
        newPosition.x += 10;
        _camBound.transform.position = Vector2.MoveTowards(_camBound.transform.position, newPosition, 8f * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_data.GetComponent<SaveDataPlayer>().Value(201) == 0)
        {
            _key = GameObject.Find("Key");
            GameObject key = Instantiate(_key, animator.transform.position, animator.transform.rotation);
        }
        _noSkip.SetActive(false);
        Destroy(animator.gameObject);
        //_camBound.transform.position = newPosition;
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
