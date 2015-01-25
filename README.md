<h1>ControllerServer</h1>
ControllerServer is a pluggable websocket server that you can run on your local machine which can inform the browser of what your peripheral devices are doing.
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
