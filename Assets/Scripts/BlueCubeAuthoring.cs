using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

public class BlueCubeAuthoring : MonoBehaviour
{
    public float speed;

    class Baker : Baker<BlueCubeAuthoring>
    {
        public override void Bake(BlueCubeAuthoring authoring)
        {
            // var transform = GetComponent<Transform>();
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new BlueCube { 
                // The red cube's direction is right
                rotatingSpeed = authoring.speed, direction = Vector3.right
            });
        }
    }
}
public struct BlueCube : IComponentData
{
    public float rotatingSpeed;
    public Vector3 direction;
}