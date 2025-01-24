using UnityEngine;

public class Block : GenericObject
{
    [SerializeField] protected bool isWalkableOn;
    [SerializeField] protected float walkSpeedMultiplier;

    public bool IsWalkableOn => isWalkableOn;
    public float WalkSpeedMultiplier => walkSpeedMultiplier;
}