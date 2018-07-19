using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RosPublisher<T>
    where T : IRosClassInterface, new()
{

    public bool connected { get; private set; }

    private Queue<T> SendQueue;

    public string name { get; private set; }
    public string RosTopic { get; private set; }
    public string RosType { get; private set; }
    public int QueueSize { get; private set; }

    public RosPublisher(String nodeName,
                        String rosTopic,
                        float rate = 20,
                        int queueSize = 10)
    {

        connected = false;
        name = nodeName;
        RosTopic = rosTopic;
        RosType = typeof(T).ToString();
        RosType = RosType.Substring(4, RosType.Length - 4).Replace(".", "/");
        QueueSize = queueSize;
        SendQueue = new Queue<T>();

        RosMessenger.Instance.Advertise(RosTopic, RosType);
        Debug.Log("[" + name + "] Advertised successfully");
        connected = true;

    }

    public void Terminate()
    {
        RosMessenger.Instance.Unadvertise(RosTopic);
    }

    public void SendMessage(T data)
    {
        if (connected)
        {
            // Custom parser to interpret the JSON data into Unity datatypes
            if (SendQueue.Count > 0)
            {
                String msg = RosMsg.Encode(SendQueue.Dequeue());
                RosMessenger.Instance.Publish(RosTopic, msg);

                Debug.Log("[" + name + "] Publishing: " + msg);
            }

            String processed = RosMsg.Encode(data);
            RosMessenger.Instance.Publish(RosTopic, processed);

            Debug.Log("[" + name + "] Publishing: " + processed);
        }
        else
        {
            SendQueue.Enqueue(data);
            while (SendQueue.Count > QueueSize)
            {
                SendQueue.Dequeue();
            }
        }
    }
}
