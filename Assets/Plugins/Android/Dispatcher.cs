using System.Collections.Generic;
using UnityEngine;
using System;

public class Dispatcher : MonoBehaviour {

    private List<Action> queue;
    private List<Action> dequeue;

	// Use this for initialization
	void Start () {
        queue = new List<Action>();
        dequeue = new List<Action>();
    }

    // Update is called once per frame
    void Update () {
		
        lock (queue)
        {
            dequeue.AddRange(queue);
            queue.Clear();
        }

        for (int i = 0, size = dequeue.Count; i < size; ++i)
        {
            try
            {
                dequeue[i]();
            }
            finally { }
        }
        dequeue.Clear();
    }

    public void Dispatch(Action action)
    {
        lock (queue)
        {
            queue.Add(action);
        }
    }
}
