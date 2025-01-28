using UnityEngine;

public class EntityObject : Entity
{
    [SerializeField] protected int number = 1;

    [SerializeField] protected int stackSize = 0;
    [SerializeField] protected bool isDamagedOutside = false;
    [SerializeField] string weaponType;

    public int Number { get => number; set { number = value; } }
    public int StackSize => stackSize;
    public bool IsDamagedOutside => isDamagedOutside;
    public string WeaponType => weaponType;
}