using System;
using UnityEngine;
using Debug = Logger.Debug;
using System.Threading;

namespace MyGame
{
    public class TestServer : MonoBehaviour
    {
        Thread inputThread;
        void Start()
        {
            Debug.Log("Program Started!");
            if (Application.isEditor)
            {
                Console.Clear();
                inputThread = new Thread(() =>
                {
                    while (true)
                    {
                        string input = Debug.ReadLine("Enter some text: ");
                        Debug.Log("Input received: " + input);
                        if (input == "quit")
                        {
                            Debug.Log("Stopped listening for input");
                            return;
                        }
                    }
                });
                inputThread.Start();
                Debug.Log("Started Input");
            }
            else Debug.Log("Input does not work in unity editor! Sorry!");
        }

        float spamTimer = 0f;
        void Update()
        {
            spamTimer += Time.deltaTime;
            if (spamTimer > 1f)
            {
                spamTimer -= 1f;
                Debug.Log("Heres some text");
            }
        }

        void OnApplicationQuit()
        {
            if (Application.isEditor)
                inputThread.Abort();
        }
    }
}
