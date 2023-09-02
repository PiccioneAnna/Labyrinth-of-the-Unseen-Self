using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPositioning : MonoBehaviour
{
    public Transform followTarget;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
    }
}
