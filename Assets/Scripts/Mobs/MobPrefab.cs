using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobPrefab : MonoBehaviour
{
    public Mob mob;
    public Mob[] potentialMobs;

    public float FramesPerSecond = 20;  // adjust to suit

    private void Start()
    {
        mob = potentialMobs[Random.Range(0, potentialMobs.Length)];
    }

    // poor man's cheesy-sprite sequencer. Put this on the GameObject with the SpriteRenderer
    void Update()
    {
        if(mob != null)
        {
            int frame = (int)(Time.time * FramesPerSecond);

            frame %= mob.sprites.Length;

            var renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = mob.sprites[frame];
        }
    }
}
