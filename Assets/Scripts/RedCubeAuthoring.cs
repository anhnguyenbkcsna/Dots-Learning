using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

public class RedCubeAuthoring : MonoBehaviour
{
    public float speed;

    class Baker : Baker<RedCubeAuthoring>
    {
        public override void Bake(RedCubeAuthoring authoring)
        {
            // var transform = GetComponent<Transform>();
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new RedCube { 
                // The red cube's direction is left
                rotatingSpeed = authoring.speed, direction = Vector3.left
            });
        }
    }
}
public struct RedCube : IComponentData
{
    public float rotatingSpeed;
    public Vector3 direction;
}