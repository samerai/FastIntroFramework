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

        public void addScene(Scene scene)
        {
            Scenelist.AddLast(scene);
        }

        public Scene getScene(double Time)
        {
            double currentTime = 0;
            foreach (Scene scene in Scenelist) {
                currentTime += scene.Duration;
                if (Time < currentTime) return scene;
            }
            return null;
        }
        
    }
}
