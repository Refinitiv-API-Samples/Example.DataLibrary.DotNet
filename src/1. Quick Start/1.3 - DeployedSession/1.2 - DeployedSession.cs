﻿using Configuration;
using Refinitiv.Data;
using Refinitiv.Data.Core;
using System;

namespace _1._3___DeployedSession
{
    class Program
    {
        static void Main(string[] args)
        {
            // Programmatically override the default log level defined for the Refinitiv Data Library.
            Log.Level = NLog.LogLevel.Debug;

            // Create a session into a deployed ADS providing steaming data onlhy
            var session = PlatformSession.Definition().Host(Credentials.ADSHost)
                                                      .GetSession().OnState((s, state, msg) => Console.WriteLine($"State: {state}. {msg}"))
                                                                   .OnEvent((s, eventCode, msg) => Console.WriteLine($"Event: {eventCode}. {msg}"));

            if (session.Open() == Session.State.Opened)
                Console.WriteLine("Session successfully opened");
            else
                Console.WriteLine("Session failed to open");
        }
    }
}
