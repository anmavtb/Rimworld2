using UnityEngine;
using System.Collections.Generic;

public class GenericObject : MonoBehaviour
{
    [SerializeField] protected string objectName;
    [SerializeField] protected string description;
    [SerializeField] protected float hitPoints = 1;
    [SerializeField] protected bool isPlayerOwned = false;
    [SerializeField] protected Dictionary<EntityObject, int> drops;
    [SerializeField] protected float value = 1;
    [SerializeField] protected float maxTemp;
    [SerializeField] protected float minTemp;
    [SerializeField] protected float beauty;

    public string ObjectName => objectName;
    public string Description => description;
    public float HitPoints => hitPoints;
    public bool IsPlayerOwned => isPlayerOwned;
    public Dictionary<EntityObject, int> Drops => drops;
    public float Value => value;
    public float MaxTemp => maxTemp;
    public float MinTemp => minTemp;
    public float Beauty => beauty;
}