using UnityEngine;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine.AI;
using System.Collections;

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

    protected void Init()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = size;
    }

    public IEnumerator Move(Vector3 _destination)
    {
        agent.SetDestination(_destination);
        Debug.Log(1);
        Debug.Log($"pos : {this.transform.position} | dest : {agent.pathEndPosition} | stopdist : {agent.stoppingDistance}");
        if (!agent.pathPending && DestinationReached(agent, _destination)) yield return new WaitForSeconds(10f);
    }

    protected bool DestinationReached(NavMeshAgent _agent, Vector3 _destination)
    {
        Debug.Log(2);
        Debug.Log($"pos : {this.transform.position} | dest : {agent.pathEndPosition} | stopdist : {agent.stoppingDistance}");
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
        if (HasReach(this.transform.position, _target.transform.position))
        {
            float _random = (Random.value * Random.Range(-1f, 1f)) * 10;
            float _finalDamages = baseDamage + _random;
            Debug.Log($"random : {_random} | baseDamage : {baseDamage} | finalDamage : {_finalDamages}");
            _target.IsHit(_finalDamages);
        }
        else
        {
            StartCoroutine(Move(_target.transform.position));
        }
    }

    protected bool HasReach(Vector3 _selfPosition, Vector3 _targetPosition)
    {
        if (Vector3.Distance(_selfPosition,_targetPosition) <= (size+1))
        {
            return true;
        }
        else return false;
    }
}