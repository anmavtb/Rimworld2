using UnityEngine;

public class EntityMaterial : EntityObject
{
    [SerializeField] protected bool canRot = false;

    public bool CanRot => canRot;
}