# UnityNetwork

## Description

The aime of this project is to show how to use Unity3D Network Manager to obtain a master/slave application: the master part can control the environment of the slave. It shows how to use ***RPC*** and ***SyncVar***. *RPC* enables to call functions on client side while *SyncVar* synchronize a variable on all clients.

## Instructions

### Launching the application

Build and run an instance of the programme, choose *LAN Host(H)*.

Run an instance in editor, choose *LAN Client(C)*.

the host's button changes cube's color for the client. 

### Changing network managing technique
We can choose to use either *RPC* or *SyncVar* by changing the button `onClick` action, which should be linked to a `changeColor()` function.
Scripts for both techniques are available at [`Assets/scripts/RpcScript.cs`](Assets/scripts/RpcScript.cs) and at [`Assets/scripts/SyncVarScript.cs`](Assets/scripts/SyncVarScript.cs).

See [Simple Multiplayer Example](https://unity3d.com/fr/learn/tutorials/topics/multiplayer-networking/introduction-simple-multiplayer-example?playlist=29690) for more explaination on Network Manager's set up.
