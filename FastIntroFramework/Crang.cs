using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform;

namespace FastIntroFramework
{
    class Crang : GameWindow
    {
        private readonly Timeline _timeline;

        protected double Time { 
            get;
            set;
        }
        public Crang() : base(1280, 720)
        {
            //base.WindowState = WindowState.Fullscreen;
            _timeline = new Timeline();
            Time = 0.0d;

            Keyboard.KeyDown += KeyboardKeyDown;

            var scene1 = new Scene();
            _timeline.AddScene(scene1);
        }

        #region Keyboard_KeyDown

        /// <summary>
        /// Occurs when a key is pressed.
        /// </summary>
        /// <param name="sender">The KeyboardDevice which generated this event.</param>
        /// <param name="e">The key that was pressed.</param>
        void KeyboardKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            /*if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
             */
        }

        #endregion

        #region OnLoad

        /// <summary>
        /// Setup OpenGL and load resources here.
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            foreach (Scene scene in _timeline.Scenelist)
            {
                scene.OnLoad(e);
            }
            GL.ClearColor(Color.MidnightBlue);
        }

        #endregion

        #region OnResize

        /// <summary>
        /// Respond to resize events here.
        /// </summary>
        /// <param name="e">Contains information on the new GameWindow size.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnResize(EventArgs e)
        {
            /*GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);*/
            _timeline.GetScene(Time).OnResize(e);
        }

        #endregion

        #region OnUpdateFrame

        /// <summary>
        /// Add your game logic here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            _timeline.GetScene(Time).OnUpdateFrame(e);
        }

        #endregion

        #region OnRenderFrame

        /// <summary>
        /// Add your game rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        /// <remarks>There is no need to call the base implementation.</remarks>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            /*GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(BeginMode.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            this.SwapBuffers();*/
            _timeline.GetScene(Time).OnRenderFrame(e);

        }

        #endregion
        
        #region public static void Main()

        /// <summary>
        /// Entry point of this example.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (Crang crang = new Crang())
            {
                // Get the title and category  of this example using reflection.
                //Utilities. ;//SetWindowTitle(crang);
                crang.Title = "test";
                crang.Run(30.0, 0.0);
            }
        }

        #endregion

    }
}
