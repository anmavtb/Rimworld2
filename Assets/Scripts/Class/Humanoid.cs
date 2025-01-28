using UnityEngine;
using System.Collections.Generic;

public class Humanoid : EntityMoving
{
    [SerializeField] protected string surname;
    [SerializeField] protected string nickname;
    [SerializeField] protected float hapiness = 1;
    [SerializeField] protected List<GameObject> thoughts;
    [SerializeField] protected List<GameObject> skills;
    [SerializeField] protected List<GameObject> traits;

    [SerializeField] private bool ATTACK = false;
    [SerializeField] private GenericObject TARGET;

    public string Surname => surname;
    public string Nickname => nickname;
    public float Hapiness => hapiness;
    public List<GameObject> Thoughts => thoughts;
    public List<GameObject> Skills => skills;
    public List<GameObject> Traits => traits;

    public string FullName => $"{objectName} \"{nickname}\" {surname}";

    private void Update()
    {
        if (TARGET != null && ATTACK == true)
            Attack(TARGET);
    }
}