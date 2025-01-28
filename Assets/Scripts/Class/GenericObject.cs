using UnityEngine;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine.UIElements;

public class GenericObject : MonoBehaviour
{
    [SerializeField] protected string objectName;
    [SerializeField] protected string description;
    [SerializeField] protected float hitPoints = 1;
    [SerializeField] protected bool isPlayerOwned = false;
    [SerializedDictionary("Object", "Number")] protected SerializedDictionary<EntityObject, int> drops;
    [SerializeField] protected float value = 1;
    [SerializeField] protected float maxTemp;
    [SerializeField] protected float minTemp;
    [SerializeField] protected float beauty;

    public string ObjectName => objectName;
    public string Description => description;
    public float HitPoints => hitPoints;
    public bool IsPlayerOwned => isPlayerOwned;
    public SerializedDictionary<EntityObject, int> Drops => drops;
    public float Value => value;
    public float MaxTemp => maxTemp;
    public float MinTemp => minTemp;
    public float Beauty => beauty;

    public void IsHit(float _damages)
    {
        hitPoints -= _damages;
        Debug.Log($"Remaining health : {hitPoints}");
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            IsDead();
        }
    }

    protected void IsDead()
    {
        {
            if (drops != null)
            {
                EntityObject _item;
                foreach (var _drop in drops)
                {
                    _item = _drop.Key as EntityObject;
                    _item.Number = _drop.Value;
                    Instantiate(_drop.Key, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }
}