using UnityEngine;

public class Food : EntityMaterial
{
    [SerializeField] protected string foodType;
    [SerializeField] protected float foodValue = 1;

    public string FoodType => foodType;
    public float FoodValue => foodValue;
}