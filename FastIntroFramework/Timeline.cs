using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastIntroFramework
{
    //Class that manages the timeline of the intro, scene order, rendering order, sound playback order etc
    public class Timeline
    {
        public LinkedList<Scene> Scenelist
        {
            get;
            private set;
        }
        public Timeline()
        {
            Scenelist = new LinkedList<Scene>();
        }

        public void AddScene(Scene scene)
        {
            Scenelist.AddLast(scene);
        }

        //return scene at time Time. Assumes that time is linear along the linkedlist. If the time is larger than the total duration of the scenelist the last scene is returned
        public Scene GetScene(double time)
        {
            double currentTime = 0;
            foreach (Scene scene in Scenelist) {
                currentTime += scene.Duration;
                if (time < currentTime) return scene;
            }
            return Scenelist.Last();
        }
        
    }
}
