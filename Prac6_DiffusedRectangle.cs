//DiffusedRectangle

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace DiffusedRectangles
{
    public partial class Form1 : Form
    {
        Microsoft.DirectX.Direct3D.Device MyDevice;
        private CustomVertex.PositionNormalColored[] MyVertex = new CustomVertex.PositionNormalColored[6];

        public Form1()
        {
            InitializeComponent();
            InitDevice();

        }

        public void InitDevice()
        {
            PresentParameters MyWindow = new PresentParameters();
            MyWindow.Windowed = true;
            MyWindow.SwapEffect = SwapEffect.Discard;
            MyDevice = new Device(0, DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, MyWindow);

            MyDevice.Transform.Projection = Microsoft.DirectX.Matrix.PerspectiveFovLH(3.14f / 4, MyDevice.Viewport.Width / MyDevice.Viewport.Height, 1f, 100f);
            MyDevice.Transform.View = Microsoft.DirectX.Matrix.LookAtLH(new Vector3(0, 0, 10), new Vector3(), new Vector3(0, 1, 0));

            MyDevice.RenderState.Lighting = true;
            MyDevice.Lights[0].Type = LightType.Directional;
            MyDevice.Lights[0].Diffuse = Color.White;
            MyDevice.Lights[0].Direction = new Vector3(0.8f, 0, -1);
            MyDevice.Lights[0].Enabled = true;



            MyVertex[0] = new CustomVertex.PositionNormalColored(new Vector3(0, 2, 1), new Vector3(1, 0, 1), Color.Red.ToArgb());
            MyVertex[1] = new CustomVertex.PositionNormalColored(new Vector3(0, -2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb());
            MyVertex[2] = new CustomVertex.PositionNormalColored(new Vector3(2, -2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb());
            MyVertex[3] = new CustomVertex.PositionNormalColored(new Vector3(2, -2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb());
            MyVertex[4] = new CustomVertex.PositionNormalColored(new Vector3(2, 2, 1), new Vector3(-1, 0, 1), Color.Red.ToArgb());
            MyVertex[5] = new CustomVertex.PositionNormalColored(new Vector3(0, 2, 1), new Vector3(1, 0, 1), Color.Red.ToArgb());


        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyDevice.Clear(ClearFlags.Target, Color.Purple, 1.0f, 0);
            MyDevice.BeginScene();
            MyDevice.VertexFormat = CustomVertex.PositionNormalColored.Format;
            MyDevice.DrawUserPrimitives(PrimitiveType.TriangleList, MyVertex.Length / 3, MyVertex);
            MyDevice.EndScene();
            MyDevice.Present();


        }
    }
}

