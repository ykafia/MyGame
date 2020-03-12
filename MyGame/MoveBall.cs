using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenko.Core.Mathematics;
using Xenko.Input;
using Xenko.Engine;
using Xenko.Physics;

namespace MyGame
{
    public class MoveBall : SyncScript
    {
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            var chrt = this.Entity.Get<CharacterComponent>();
            // Do stuff every new frame
            if(Input.IsKeyDown(Keys.Z)) {
                chrt.SetVelocity(new Vector3(0,0,-1));
            }
            if(Input.IsKeyDown(Keys.S)) {
                chrt.SetVelocity(new Vector3(0,0,1));
            }
            if(Input.IsKeyDown(Keys.Q)) {
                chrt.SetVelocity(new Vector3(-1,0,0));
            }
            if(Input.IsKeyDown(Keys.D)) {
                chrt.SetVelocity(new Vector3(1f,0,0));
            }
        }
    }
}
