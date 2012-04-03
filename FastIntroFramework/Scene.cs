using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace FastIntroFramework
{
    // a scene is played in sequence, rendering is done within the class inheriting from scene
    public class Scene
    {
        public double Duration
        {
            get;
            set;
        }

        public void OnLoad(EventArgs e)
        {
            
        }

        public void OnResize(EventArgs e)
        {
            
        }

        public void OnUpdateFrame(FrameEventArgs e)
        {
            
            //_time += e.Time;
            //_shader["time"] = (float)_time;
        }

        public void OnRenderFrame(FrameEventArgs e)
        {

        }

        public void SetupCamera()
        {
            
        }
    }
}
