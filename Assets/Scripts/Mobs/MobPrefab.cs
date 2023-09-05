using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MobPrefab : MonoBehaviour
{
    public Mob mob;
    public Mob[] potentialMobs;

    public float FramesPerSecond = 20;  // adjust to suit
    public Light2D glow;

    private void Awake()
    {
        mob = potentialMobs[Random.Range(0, potentialMobs.Length)];
        glow = GetComponent<Light2D>();
        glow.color = mob.glowColor;
    }

    // poor man's cheesy-sprite sequencer. Put this on the GameObject with the SpriteRenderer
    void Update()
    {
        AnimateSprite();
    }

    private void AnimateSprite()
    {
        if (mob != null)
        {
            int frame = (int)(Time.time * FramesPerSecond);

            frame %= mob.sprites.Length;

            var renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = mob.sprites[frame];
        }
    }
}
