﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TrioServer.Radios
{
    public interface IRadioTrio
    {
        int Id { get; }
        int SerialNumber { get; }
        string Desc { get; }
        RadioType Type { get; }
        OperationMode OpMode { get; }
        bool Initialized { get; }
        DateTime TimeStamp { get; set; }
        int CommStatus { get; set; }

        int MasterId { get; }
        int ChannelId { get; }


        void Initialize();
        void Update();
        void Close();
        byte[] SerialNumberParse();
    }
}
