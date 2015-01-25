<h1>ControllerServer</h1>
ControllerServer is a pluggable websocket server that you can run on your local machine which can inform the browser of what your peripheral devices are doing. The server currently reports to port 51343 although this will be made configurable.
Currently there are the following plugins found in the the Controllers folder. 
<h2>Plugins</h2>

<b>Oculus Rift DK2</b> - in the format;

```JSON
{
  "w":0.123,
  "x":0.123,
  "y":0.123,
  "z":0.123,
  "px":0.123,
  "py":0.123,
  "pz":0.123
}
```
where the first four parameters refer to the orientation quaternion and the last three refer to the 3 dimensional positioning of the device.

Credit to Oculus Rift team for a great SDK and wwwtyro @ https://github.com/wwwtyro for the starting point with this.

<b>Xbox 360 controller</b> - in the format; 
```JSON
{
  "PacketNumber":2,
  "IsConnected":true,
  "Buttons":
  {
    "Start":1,
    "Back":1,
    "LeftStick":1,
    "RightStick":1,
    "LeftShoulder":1,
    "RightShoulder":1,
    "Guide":1,
    "A":1,
    "B":1,
    "X":1,
    "Y":1
  },
  "DPad":
  {
    "Up":1,
    "Down":1,
    "Left":1,
    "Right":1
  },
  "Triggers":
  {
    "Left":0,
    "Right":0
  },
  "ThumbSticks":
  {
    "Left":
    {
      "X":0,
      "Y":0
    },
    "Right":
    {
      "X":0,
      "Y":0
    }
  }
}
```
Credit to speps @ https://github.com/speps/XInputDotNet for a great library for accessing Xbox 360 controller input. 

<h3>How to make your own plugins</h3>
Just download the latest release from the releases page and create a .net project referencing the Server executable (Server.exe). After this please implement the API  ```IController``` and also decorate it with the MEF attributes required. i.e.
```C#
    [Export(typeof(IController))]
    [ExportMetadata("Name", "Xbox360Controller")]
    public class XboxController : IController
    {
```
The Name attribute in the meta data will be what the section in the JSON data will read and how it appears in the GUI.
Once you are done just drop this (and any dependencies) in the Controllers folder next to the Controller Sever executable and restart the server.
<h4>BTW...</h4>
I am aware of the fact that some browser vendors are currently adding direct access to these devices through javascript. The purpose of this project is to provide an easy way to hook up device drivers to a websockets server, so that any old random device can be programmed against! Anyone got a guitar hero guitar I can borrow?
