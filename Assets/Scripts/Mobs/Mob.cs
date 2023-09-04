using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Mob")]
public class Mob : ScriptableObject
{
    [Header("Internal")]
    public float speed;
    public int damage;
    public float timeToAttack;

    [Header("External")]
    public string id;
    public Sprite sprite;
    public Animation idleAnimation;
}
