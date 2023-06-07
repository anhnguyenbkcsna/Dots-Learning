using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

namespace cube
{
    public partial struct CubeSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            // add a component to single entity
            var entity = state.EntityManager.CreateEntity();
            state.EntityManager.AddComponent<RedCube>(entity);
        }

        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            // assume that the edge is 5 for collision 
            float edge = 5;

            // Loop over every entity having a LocalTransform component and RotatingSpeed component.
            // In each iteration, transform is assigned a read-write reference to the LocalTransform,
            // and speed is assigned a read-only reference to the RotatingSpeed component.

            // Query for BlueCube
            foreach (var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<BlueCube>>())
            {
                // ValueRW and ValueRO both return a ref to the actual component value.
                // ValueRO does a safety check for read-only access.
                
                // Rotate the transform by the speed value.
                // If the entities do not rotate, check out the speed of script in Unity
                transform.ValueRW = transform.ValueRO.RotateY(speed.ValueRO.rotatingSpeed * deltaTime);
                
                // Translate object in direction
                if(transform.ValueRW.Position.x > edge || transform.ValueRW.Position.x < -edge)
                {
                    // reverse direction (left - right)
                    speed.ValueRW.direction = -speed.ValueRW.direction;
                }
                transform.ValueRW = transform.ValueRW.Translate(speed.ValueRO.direction * deltaTime);
            }

            // Query for RedCube
            foreach (var (transform, speed) in SystemAPI.Query<RefRW<LocalTransform>, RefRW<RedCube>>())
            {
                // Translate object in direction
                if(transform.ValueRW.Position.x > edge || transform.ValueRW.Position.x < -edge)
                {
                    // reverse direction (left - right)
                    speed.ValueRW.direction = -speed.ValueRW.direction;
                }
                transform.ValueRW = transform.ValueRW.Translate(speed.ValueRO.direction * deltaTime);
            }
        }
    }
} 