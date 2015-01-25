using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControllerServer
{
    public partial class ControllerServer : Form
    {
        private delegate void RefreshControllers(List<Tuple<string,string>> controllerInfo);
        RefreshControllers RefreshControllersHandler;
        Image inactiveImage = (Image)Properties.Resources.ResourceManager.GetObject("inactive");
        Image activeImage = (Image)Properties.Resources.ResourceManager.GetObject("active");
        public ControllerServer()
        {
            InitializeComponent();
            InitialiseListView();
            KickOffServer();
        }
        
        void InitialiseListView()
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add("inactive", inactiveImage);
            imageList.Images.Add("active", activeImage);
            lvControllers.LargeImageList = imageList;
            RefreshControllersHandler += RefreshControllerList;
        }

        private void KickOffServer()
        {
            bwServerRunner.DoWork += new DoWorkEventHandler(StartServer);
            bwServerRunner.RunWorkerAsync();
        }

        private void StartServer(object sender, DoWorkEventArgs e)
        {
            Server.Server server = new Server.Server();
            server.SocketOpened += new EventHandler(SocketOpenedEventHandler);
            server.SocketClosed += new EventHandler(SocketClosedEventHAndler);
            server.ControllersInitialised += new Server.Server.ControllersInitialisedEventHandler(ControllersInitialisedEventHandler);
            server.Init();
        }

        private void SocketOpenedEventHandler(object sender, EventArgs e)
        {
            picWebSocketsActivated.Image = activeImage;
        }

        private void SocketClosedEventHAndler(object sender, EventArgs e)
        {
            picWebSocketsActivated.Image = inactiveImage;
        }

        private void ControllersInitialisedEventHandler(object sender, List<Tuple<string, string>> controllerInfo)
        {
            Invoke(RefreshControllersHandler, controllerInfo);
        }

        private void RefreshControllerList(List<Tuple<string, string>> controllerInfo)
        {
            lvControllers.Items.Clear();
            foreach(Tuple<string,string> cont in controllerInfo)
            {
                lvControllers.Items.Add(cont.Item1, cont.Item2);
            }
        }
    }
}
