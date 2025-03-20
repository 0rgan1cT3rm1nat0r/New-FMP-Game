using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WATER : MonoBehaviour
{
    private float velocity = 0;
    private float force = 0;
    //current height
    private float height = 0f;
    //normal height
    private float target_height = 0f;
}
public void WaveSpringUpdate( float springStiffness )
{
    height = tranform.localPosition.y;
    // maximum extension
    var x = height - target_height;

    force  = - springStiffness * x;
    velocity += force;
    Transform.localPosition = new Vector3(tranform.localPosition.x, y+velocity,tranform.localPosition.z);
}
[SerializeField]
private float springStiffness = 0.1f;
[SerializeField]
private List<WaterSpring> springs = new();

void FixedUpdate()
{
    foreach(WaterSpring WaterSpringComponent in springs) {
        WaterSpringComponent.WaveSpringUpdate(springStiffness);
    }
public void WaterSpringUpdate( float springStiffness, float dampening ) {
        height = tranform.localPosition.y;
        // maximum extension
        var x = height - target_height;
        var loss = -dampening * velocity;

        force = - springStiffness * x + loss;
        velocity += force;
        var y = tranform.localPosition.y;
        tranform.localPosition = new Vector3(tranform.localPosition.x, y+velocity, tranform.localPosition.z);
    }
}