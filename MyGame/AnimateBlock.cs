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
    public class AnimateBlock : SyncScript
    {
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            Log.ActivateLog(LogMessageType.Debug);
        }
        public override void Update(){
            var anim = this.Entity.Get<AnimationComponent>();
            var sk = this.Entity.Get<ModelComponent>().Skeleton;
            var trf = sk.NodeTransformations[1].Transform.Position;
            if(anim.IsPlaying("Walk")){
                Log.Debug("Position of animaton\n" + trf.ToString());
            }
            if(Input.IsKeyDown(Keys.O)) {
                anim.Play("Walk");
                
            }
        }
    }
}
