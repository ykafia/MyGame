using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xenko.Core.Mathematics;
using Xenko.Input;
using Xenko.Engine;
using Xenko.Core.Diagnostics;

namespace MyGame
{
    public class UpdateAfterAnim : AsyncScript
    {
        // Declared public member fields and properties will show in the game studio

        public override async Task Execute()
        {
            Log.ActivateLog(LogMessageType.Debug);
            var anim = this.Entity.Get<AnimationComponent>();
            var sk = this.Entity.Get<ModelComponent>().Skeleton;
            var trf = sk.NodeTransformations[0].Transform.Position;
            while(Game.IsRunning)
            {
                // Do stuff everytime the first playing animations has ended
                
                if(anim.IsPlaying("Walk")){
                    var curr = anim.PlayingAnimations.First();
                    await anim.Ended(curr);
                    Log.Debug("First\n" + Entity.Transform.Position.ToString());
                    Log.Debug("Node Position\n"+trf.ToString());
                }
                await Script.NextFrame();
            }
        }
    }
}
