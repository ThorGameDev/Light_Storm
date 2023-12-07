using UnityEngine;
using UnityEngine.AI;

public class SpiderBehavior : MonoBehaviour
{
    [Header("Global")]
    public GameObject player;
	public NavMeshAgent spiderMotionManager;
	public Animator spiderAnimator;
	public SpiderState currentState = SpiderState.init;
    private SpiderState priorState = SpiderState.init;
    public float clock;
    public AudioSource footstepManager;
    public AudioClip[] footsteps;
    private float lastFootstep;
    public float footstepRate;

    [Header("ExploreState")]
	public float wanderSpeed;
	public float playerChaseRange;
    public float wanderNottice;
    public Transform[] positions;
    public Vector3 target;

    [Header("Chase")]
	public float chaseSpeed;
	public float playerIgnoreRange;

    [Header("IdleState")]
    public float minWait;
    public float maxWait;
    private float wait;

    void Start()
    {
       player = FindObjectOfType<PlayerBehavior>().gameObject; 
       currentState = SpiderState.idle;
    }
    
    void Update()
    {
        if(player == null)
        {
            return;
        }
        clock += Time.deltaTime;
        switch (currentState)
        {
            case SpiderState.explore:
                ExploreState(); 
                break;
            case SpiderState.idle:
                IdleState(); 
                break;
            case SpiderState.chase:
                ChaseState(); 
                break;
            default:
                break;
        }
        if(currentState != priorState)
        {
            priorState = currentState;
            clock = 0;
            switch (currentState)
            {
                case SpiderState.explore:
                    ExploreInit(); 
                    break;
                case SpiderState.idle:
                    IdleInit(); 
                    break;
                case SpiderState.chase:
                    ChaseInit(); 
                    break;
                default:
                    break;
            }
        }
        lastFootstep += Time.deltaTime;
        if(lastFootstep > footstepRate)
        {
            lastFootstep -= footstepRate;
            footstepManager.PlayOneShot( footsteps[Random.Range(0, footsteps.Length)] );
        }
    }
    private void ExploreInit()
    {
        target = positions[Random.Range(0, positions.Length)].position;
        spiderMotionManager.destination = target;
        spiderMotionManager.speed = wanderSpeed;
    }
    private void ExploreState()
    {
        // if close to player
        if(Vector3.Distance(player.transform.position,this.transform.position) < playerChaseRange)
        {
            currentState = SpiderState.chase;
            return;
        }
        // if close to target or has been exploring for over 60 seconds
        if(Vector3.Distance(target ,transform.position) < wanderNottice || clock > 60)
        {
            currentState = SpiderState.idle;
        }
    }
    private void IdleInit()
    {
        spiderMotionManager.speed = 0;
        wait = Random.Range(minWait,maxWait);
        spiderMotionManager.destination = transform.position;
    }
    private void IdleState()
    {
        // if close to player
        if(Vector3.Distance(player.transform.position,this.transform.position) < playerChaseRange)
        {
            currentState = SpiderState.chase;
            return;
        }
        // if waited a while
        if( clock > wait)
        {
            currentState = SpiderState.explore;
        }
    }
    private void ChaseInit()
    {
        spiderMotionManager.speed = chaseSpeed;
    }
    private void ChaseState()
    {
        if(Vector3.Distance(player.transform.position,this.transform.position) > playerIgnoreRange)
        {
            currentState = SpiderState.idle;
            return;
        }
        spiderMotionManager.destination = player.transform.position; 
    }
    public void OnCollisionEnter(Collision collision)
    {

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<GameManager>().Loss();
        }
    }
}
[System.Serializable]
public enum SpiderState
{
    init,
	explore,
	idle,
	chase,
}
