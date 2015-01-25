using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Server
{
    public class Server : IDisposable
    {
        [ImportMany(typeof(IController))]
        public IEnumerable<Lazy<IController, IControllerData>> controllers;
        public List<Tuple<String, String>> ControllerInfo {
            get {
                List<Tuple<String,String>> controllerInfo = new List<Tuple<string,string>>();
                foreach (Lazy<IController, IControllerData> cont in controllers)
                {
                    controllerInfo.Add(new Tuple<string,string>(cont.Metadata.Name,cont.Value.Initialised? "active":"inactive"));
                }
                return controllerInfo;
            }
        }
        public delegate void ControllersInitialisedEventHandler(object sender, List<Tuple<String, String>> controllerInfo);
        public event ControllersInitialisedEventHandler ControllersInitialised;
        public event EventHandler SocketOpened;
        public event EventHandler SocketClosed;

        public void Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(Environment.CurrentDirectory + "/Controllers/"));
            var container = new CompositionContainer(catalog);

            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
                Console.ReadLine();
            }
            
            using (var server = new WebSocketServer("ws://127.0.0.1:51343"))
            {
                server.Start(socket =>
                {
                    socket.OnOpen = () => {
                        if (SocketOpened != null)
                        {
                            SocketOpened(this, new EventArgs());
                        }
                        SendData(socket); 
                    };
                    socket.OnClose = () => { 
                        if (SocketOpened != null) 
                        { 
                            SocketClosed(this, new EventArgs()); 
                        } 
                    };
                    socket.OnMessage = message => socket.Send(message);
                });
                while (true)
                {
                    InitControllers();
                    if (ControllersInitialised != null)
                    {
                        ControllersInitialised(this, ControllerInfo);
                    }
                    System.Threading.Thread.Sleep(5000);
                }
            }
        }

        void InitControllers()
        {
            foreach (Lazy<IController, IControllerData> cont in controllers)
            {
                if (!cont.Value.Initialised)
                {
                    cont.Value.Init();
                }
            }

        }

        void SendData(IWebSocketConnection socket)
        {
            StringBuilder sb = new StringBuilder();
            while (socket.IsAvailable)
            {
                foreach(Lazy<IController, IControllerData> cont in controllers) 
                {
                    if (cont.Value.Initialised)
                    {
                        sb.Append("\"");
                        sb.Append(cont.Metadata.Name);
                        sb.Append("\":");
                        sb.Append(cont.Value.GetLiveInfo());
                        sb.Append(",");
                    }
                }
                string message = sb.ToString();
                sb.Clear();
                message = message.Trim(',');
                socket.Send("{" + message + "}");
                System.Threading.Thread.Sleep(10);
            }
        }

        public void Dispose()
        {
            foreach (Lazy<IController, IControllerData> cont in controllers)
            {
                if (cont.Value.Initialised)
                {
                    cont.Value.Close();
                }
            }
        }
    }
}
