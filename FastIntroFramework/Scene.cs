using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace FastIntroFramework
{
    // a scene is played in sequence, rendering is done within the class inheriting from scene
    class Scene
    {
        public double Duration
        {
            get;
            set;
        }

        protected void OnLoad(EventArgs e)
        {
            
        }

        protected void OnResize(EventArgs e)
        {
            
        }

        protected void OnUpdateFrame(FrameEventArgs e)
        {
            
            _time += e.Time;
            //_shader["time"] = (float)_time;
        }

        protected void OnRenderFrame(FrameEventArgs e)
        {

        }

        protected void SetupCamera()
        {
            
        }
    }
}
