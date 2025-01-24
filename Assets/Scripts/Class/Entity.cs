using UnityEngine;

public class Entity : GenericObject
{
    [SerializeField] protected float weight = 1;
    [SerializeField] protected float baseDamage = 1;
    [SerializeField] protected float attackSpeed = 1;

    public float Weight => weight;
    public float BaseDamage => baseDamage;
    public float AttackSpeed => attackSpeed;
}