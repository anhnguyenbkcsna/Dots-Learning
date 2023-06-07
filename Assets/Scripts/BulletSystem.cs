using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial struct BulletSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        // move the bullet
        if(Input.GetKeyDown(KeyCode.W)){ // move up
            foreach (var (transform, bullet) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
            {
                // move up the bullet
                transform.ValueRW = transform.ValueRO.Translate(bullet.ValueRO.speed * Vector3.up * deltaTime);
            }
        }
        else if(Input.GetKeyDown(KeyCode.D)){ // move right
            foreach (var (transform, bullet) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
            {
                // move up the bullet
                transform.ValueRW = transform.ValueRO.Translate(bullet.ValueRO.speed * Vector3.right * deltaTime);
            }
        }
        else if(Input.GetKeyDown(KeyCode.S)){ // move down
            foreach (var (transform, bullet) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
            {
                // move up the bullet
                transform.ValueRW = transform.ValueRO.Translate(bullet.ValueRO.speed * Vector3.down * deltaTime);
            }
        }
        else if(Input.GetKeyDown(KeyCode.A)){ // move left
            foreach (var (transform, bullet) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
            {
                // move up the bullet
                transform.ValueRW = transform.ValueRO.Translate(bullet.ValueRO.speed * Vector3.left * deltaTime);
            }
        }
        
        // Fire the bullet
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            // bool isFire = false -> if isFire => move until collision            
            // Query bullet entity
            foreach (var (transform, bullet) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<Bullet>>())
            {
                // move up the bullet
                transform.ValueRW = transform.ValueRO.Translate(bullet.ValueRO.speed * Vector3.up * deltaTime);
            }
        }

    }
}