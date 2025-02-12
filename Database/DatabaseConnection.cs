﻿using System;
using System.Data;

using MySql.Data.MySqlClient;

using TrioServer.Database.Interfaces;
using TrioServer.Database.Adapter;


namespace TrioServer.Database
{
    public class DatabaseConnection : IDatabaseClient, IDisposable
    {
        private readonly IQueryAdapter _adapter;
        private readonly MySqlConnection _con;

        public DatabaseConnection(string ConnectionStr)
        {
            this._con = new MySqlConnection(ConnectionStr);
            this._adapter = new NormalQueryReactor(this);
        }

        public void Dispose()
        {
            if (this._con.State == ConnectionState.Open)
            {
                this._con.Close();
            }

            this._con.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Connect()
        {
            this.Open();
        }

        public void Disconnect()
        {
            this.Close();
        }

        public IQueryAdapter GetQueryReactor()
        {
            return this._adapter;
        }

        public void Prepare()
        {
            // nothing here
        }

        public void ReportDone()
        {
            Dispose();
        }

        public MySqlCommand CreateNewCommand()
        {
            return _con.CreateCommand();
        }

        public void Open()
        {
            if (_con.State == ConnectionState.Closed)
            {
                try
                {
                    _con.Open();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void Close()
        {
            if (_con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }
    }
}