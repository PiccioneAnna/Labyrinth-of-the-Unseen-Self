using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    Vector2 startingPosition;
    Vector2 distanceAway => (Vector2)(transform.position - followTarget.transform.position);
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float startingZ;
    float step;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
        step = Mathf.Abs(.001f * transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(followTarget.position.x, followTarget.position.y, startingZ);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, newPosition) < 0.001f)
        {
            // Swap the position of the cylinder.
            newPosition *= -1.0f;
        }

        // Check if target is too far away
        if (Vector2.Distance(transform.position, followTarget.position) > 5f)
        {
            transform.position = newPosition;
        }
    }
}
