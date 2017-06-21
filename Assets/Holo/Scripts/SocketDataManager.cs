using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class SocketDataManager : MonoBehaviour {

    SocketIOComponent socket;
    public GameObject handPositionHandler,gestureHandler;

	// Use this for initialization
	void Awake () {
        socket = GetComponent<SocketIOComponent>();
        StartCoroutine(ConnectToServer());
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSeconds(0.5f);
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["type"] = "Holo";
        socket.Emit("identify", new JSONObject(data));
        socket.On("leftHandPositionUpdate", OnLeftHandPositionUpdate);
        socket.On("rightHandPositionUpdate", OnRightHandPositionUpdate);
        socket.On("gestureUpdate", OnGestureUpdate);
        yield break;
    }

    void OnLeftHandPositionUpdate(SocketIOEvent evt)
    {
        handPositionHandler.SendMessage("OnLeftHandChange", new Vector3(float.Parse(evt.data.GetField("x").str), float.Parse(evt.data.GetField("y").str), float.Parse(evt.data.GetField("z").str)));
    }

    void OnRightHandPositionUpdate(SocketIOEvent evt)
    {
        handPositionHandler.SendMessage("OnRightHandChange", new Vector3(float.Parse(evt.data.GetField("x").str), float.Parse(evt.data.GetField("y").str), float.Parse(evt.data.GetField("z").str)));
    }

    void OnGestureUpdate(SocketIOEvent evt)
    {
        gestureHandler.SendMessage("OnGestureUpdate", new GestureData(evt.data.GetField("gesture").str, evt.data.GetField("hand").str));
    }

}
