using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed = 3.5f;
    [SerializeField] private float _chaseSpeed = 10f;
    [SerializeField][Range(0, 3)] private float _attackRange = 2f;
    [SerializeField][Range(0, 20)] private float _minVisionRange = 10f;
    [SerializeField][Range(0, 30)] private float _maxVisionRange = 30f;
    [SerializeField] private Transform[] _patrolPoints;

    private StateMachine _stateMachine;
    private PatrolState _patrolState;
    private ChaseState _chaseState;
    private AttackState _attackState;
    private NavMeshAgent _agent;
    private Animator _animator;

    private GameObject _player;

    public PatrolState PatrolState { get => _patrolState; }
    public ChaseState ChaseState { get => _chaseState; }
    public AttackState AttackState { get => _attackState; }

    public NavMeshAgent Agent { get => _agent; }

    public GameObject Player { get => _player; }
    public Vector3 PlayerPosition { get => _player.transform.position; }
    public float PatrolSpeed { get => _patrolSpeed; }
    public float ChaseSpeed { get => _chaseSpeed; }
    public float AttackRange { get => _attackRange; }
    public float MinVisionRange { get => _minVisionRange; }
    public float MaxVisionRange { get => _maxVisionRange; }
    public Transform[] PatrolPoints { get => _patrolPoints; }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _stateMachine = new StateMachine();

        _patrolState = new PatrolState(_stateMachine, this);
        _chaseState = new ChaseState(_stateMachine, this);
        _attackState = new AttackState(_stateMachine, _animator, this);

        _stateMachine.Initialize(_patrolState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
}
