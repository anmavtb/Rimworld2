using UnityEngine;
using System.Collections.Generic;

public class Plant : Block
{
    [SerializeField] protected float growth;
    [SerializeField] protected float growthSpeed = 1;
    [SerializeField] protected List<GameObject> growthSeason;

    public float Growth => growth;
    public float GrowthSpeed => growthSpeed;
    public List<GameObject> GrowthSeason => growthSeason;
}