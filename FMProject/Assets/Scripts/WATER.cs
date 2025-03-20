using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
/*
public class WATER : MonoBehaviour
{
    private float velocity = 0;
    private float force = 0;
    //current height
    private float height = 0f;
    //normal height
    private float target_height = 0f;


    public void WaveSpringUpdate(float springStiffness)
    {
        height = transform.localPosition.y;
        // maximum extension
        var x = height - target_height;

        force = -springStiffness * x;
        velocity += force;
        var y = transform.localPosition.y;
        transform.localPosition = new Vector3(transform.localPosition.x, y + velocity, transform.localPosition.z);
    }

    [SerializeField]
    private float springStiffness = 0.1f;
    
    [SerializeField]
    private List<WaterSpring> springs = new();

    [SerializeField]
    private float dampening = 0.03f;

    void FixedUpdate()
    {
        foreach (WaterSpring waterSpringComponent in springs)
        {
            waterSpringComponent.WaveSpringUpdate(springStiffness);
        }
    }
        public void WaterSpringUpdate(float springStiffness, float dampening)
        {
            height = transform.localPosition.y;
            // maximum extension
            var x = height - target_height;
            var loss = -dampening * velocity;

            force = -springStiffness * x + loss;
            velocity += force;
            var y = transform.localPosition.y;
            transform.localPosition = new Vector3(transform.localPosition.x, y + velocity, transform.localPosition.z);
            // Slowing the movement over time
        }
    public float spread = 0.006f;

    private void UpdateSprings()
    {
        int count = springs.Count;
        float[] left_deltas = new float[count];
        float[] right_deltas = new float[count];
        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                left_deltas[i] = spread * (springs[i].height - springs[i - 1].height);
                springs[i - 1].velocity += left_deltas[i];
            }
            if (i < springs.Count - 1)
            {
                right_deltas[i] = spread * (springs[i].height - springs[i + 1].height);
                springs[i+1].velocity += right_deltas[i];
            }
        }

        void FixedUpdate()
        {

        }
    }


    
}*/