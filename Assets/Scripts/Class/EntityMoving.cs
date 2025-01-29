using UnityEngine;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;

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

    protected void Attack(GenericObject _target)
    {
        float _random = (Random.value * Random.Range(-1f, 1f)) * 10;
        float _finalDamages = baseDamage + _random;
        Debug.Log($"random : {_random} | baseDamage : {baseDamage} | finalDamage : {_finalDamages}");
        _target.IsHit(_finalDamages);
    }
}