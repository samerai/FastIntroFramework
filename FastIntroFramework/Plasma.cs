using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;

namespace FastIntroFramework
{
    class Plasma : Scene
    {
        private readonly double[,] cols;
        private const double PI = 3.14d;
        public Plasma()
        {
            cols = new double[3,256];
            for (int i = 0; i < 256; i++)
            {
                cols[0, i] = Math.Abs(128 - 127*Math.Sin(i*PI/32));
                cols[1, i] = Math.Abs(128 - 127*Math.Sin(i*PI/64));
                cols[2, i] = Math.Abs(128 - 127*Math.Sin(i*PI/128));
            }
        }

        private int mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

        public override void OnRenderFrame(OpenTK.FrameEventArgs e, GameWindow window)
        {

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, 1280, 0,720,0,1);
            GL.Disable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.ClearColor(0.2f , 0.2f, 0.2f, 0);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            for (int y=0;y<720;y++)
            {
                for (int x = 0; x < 1280; x++)
                {
                    var c = (int) (Math.Floor(Math.Sin(x/35d)*128 + Math.Sin(y/28d)*32f + Math.Sin((x + y)/16d)*64));
                    c = mod(c, 256);
                    var r = cols[0, c] % 256;
                    var g = cols[1, c] % 256;
                    var b = cols[2, c] % 256;
                    GL.Color3(r/256, g/256, b/256);
                    GL.Begin(BeginMode.Points);
                        GL.Vertex2(x, y);
                    GL.End();
                }
                
            }
            window.SwapBuffers();
        }

    }

}
