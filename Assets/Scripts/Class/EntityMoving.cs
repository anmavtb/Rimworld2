using UnityEngine;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine.AI;
using System.Collections;
using static UnityEngine.EventSystems.EventTrigger;

public class EntityMoving : Entity
{
    [SerializeField] protected string species;
    [SerializeField] protected float age = 1;
    [SerializeField] protected float speed = 1;
    [SerializeField] protected float size = 1;
    [SerializeField] protected float hunger = 1;
    [SerializeField] protected float carryWeight = 1;
    [SerializeField] protected List<Food> foodDiet;
    [SerializeField] protected bool canReproduce = true;
    [SerializeField] protected float gestationDuration = 1;
    [SerializeField] protected float growthSpeed = 1;
    [SerializeField] protected List<GameObject> healthPanel;
    [SerializeField][SerializedDictionary("Object", "Number")] protected SerializedDictionary<EntityObject, int> inventory;

    [SerializeField] protected NavMeshAgent agent;

    [SerializeField] protected string TEST = "TEST";
    [SerializeField] protected bool IsMoving;

    public string Species => species;
    public float Age => age;
    public float Speed => speed;
    public float Size => size;
    public float Hunger => hunger;
    public float CarryWeight => carryWeight;
    public List<Food> FoodDiet => foodDiet;
    public bool CanReproduce => canReproduce;
    public float GestationDuration => gestationDuration;
    public float GrowthSpeed => growthSpeed;
    public List<GameObject> HealthPanel => healthPanel;
    public SerializedDictionary<EntityObject, int> Inventory => inventory;

    protected void Start()
    {
        Init();
    }

    private void Update()
    {
        IsMoving = agent.pathPending || agent.remainingDistance > agent.stoppingDistance;
    }

    protected void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = size;
        
    }

    public void Move(Vector3 _destination)
    {
        agent.SetDestination(_destination);
    }

    public IEnumerator MoveAndAttack(GenericObject _target, Vector3 _targetPosition)
    {
        Move(_targetPosition);
        yield return new WaitForSeconds(0.1f);
        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
        {
            yield return null;
        }
        Attack(_target);
    }

    protected bool DestinationReached(NavMeshAgent _agent, Vector3 _destination)
    {
        if (agent.pathPending)
        {
            return Vector3.Distance(this.transform.position, agent.pathEndPosition) <= agent.stoppingDistance;
        }
        else
        {
            return (agent.remainingDistance <= agent.stoppingDistance);
        }
    }

    public void Attack(GenericObject _target)
    {
        Debug.Log(HasReach(this.transform.position, _target.transform.position));
        if (HasReach(this.transform.position, _target.transform.position))
        {
            float _random = (Random.value * Random.Range(-1f, 1f)) * 10;
            float _finalDamages = baseDamage + _random;
            Debug.Log($"random : {_random} | baseDamage : {baseDamage} | finalDamage : {_finalDamages}");
            _target.IsHit(_finalDamages);
        }
    }

    protected bool HasReach(Vector3 _selfPosition, Vector3 _targetPosition)
    {
        if (Vector3.Distance(_selfPosition,_targetPosition) <= (size+1.5))
        {
            return true;
        }
        else return false;
    }
}