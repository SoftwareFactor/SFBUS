﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFBUS.Interfaces
{
    public interface ILogger
    {
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarn(string message);
        void LogError(string message);
    }
}
