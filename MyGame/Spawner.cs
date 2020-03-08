using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenko.Core.Mathematics;
using Xenko.Input;
using Xenko.Engine;
using Xenko.Rendering;
using Xenko.Physics;
using Xenko.Graphics.GeometricPrimitives;

namespace MyGame
{
    public class Spawner : SyncScript
    {
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            Random rand = new Random();
            if(Input.IsKeyDown(Keys.T)){
                
                var entity = new Entity();
                entity.Transform.Position = new Vector3(rand.Next(-4,5),rand.Next(1,5),rand.Next(-4,5));
                entity.GetOrCreate<ModelComponent>().Model = Content.Load<Model>("Sphere");
                var rb = entity.GetOrCreate<RigidbodyComponent>();
                // rb.OverrideGravity = true;
                // rb.Gravity = Vector3.Zero;
                rb.ColliderShape = new SphereColliderShape(false,0.5f);
                SceneSystem.SceneInstance.RootScene.Entities.Add(entity);
                
            }
            if(Input.IsKeyDown(Keys.B)){
                var source = new Vector3(rand.Next(-4,5),rand.Next(1,5),rand.Next(-4,5));
                var entities = SceneSystem.SceneInstance.RootScene.Entities;
                foreach(var e in entities) {
                    try 
                    {
                        e.Get<RigidbodyComponent>().ApplyImpulse(12*(e.Transform.Position - source));
                    }
                    catch(Exception)
                    {

                    }
                }
            }
        }
    }
}
