using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Mob")]
public class Mob : ScriptableObject
{
    [Header("Internal")]
    public float speed = .5f;
    public int damage = 1;
    public float timeToAttack = 2f;

    [Header("External")]
    public string id;
    public Sprite[] sprites;
}
