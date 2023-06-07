// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Unity.Burst;
// using Unity.Entities;
// using Unity.Mathematics;

// public class CubeAuthoring : MonoBehaviour
// {
//     public float speed;

//     class Baker : Baker<CubeAuthoring>
//     {
//         public override void Bake(CubeAuthoring authoring)
//         {
//             // var transform = GetComponent<Transform>();
//             var entity = GetEntity(TransformUsageFlags.Dynamic);
//             AddComponent(entity, new RotatingSpeed { 
//                 rotatingSpeed = authoring.speed 
//             });
//             AddComponent(entity, new MovingSpeed {
//                 movingSpeed = authoring.speed
//             });
//         }
//     }
// }
// public struct RotatingSpeed : IComponentData
// {
//     public float rotatingSpeed;
// }
// public struct MovingSpeed : IComponentData
// {
//     public float movingSpeed;
// }
// public struct Redcube : IComponentData
// {
//     public float movingSpeed = 5;
// }
// public struct BlueCube : IComponentData
// {
//     public float rotatingSpeed = 5;
//     public float movingSpeed = 5;
// }