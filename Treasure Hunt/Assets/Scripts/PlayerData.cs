using UnityEngine;

[CreateAssetMenu(fileName ="PlayerConfig",menuName ="ScriptableObject/PlayerController",order =1)]
public class PlayerData : ScriptableObject
{
    [SerializeField, Min(0)] private float movementSpeed = 0;

    public float MovementSpeed=> movementSpeed;
}
