using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public class BulletAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float speed;
    class Baker : Baker<BulletAuthoring>
    {
        public override void Bake(BulletAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new Bullet{
                Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                speed = authoring.speed
            });
        }
    }
}

public struct Bullet : IComponentData
{
    public Entity Prefab;
    public float speed;
}