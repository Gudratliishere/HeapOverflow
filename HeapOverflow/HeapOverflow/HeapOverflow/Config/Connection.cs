using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HeapOverflow.Config
{
    public class Connection
    {
        private string host;
        private string port;
        private string username;
        private string password;
        private string database;
        private int cryptPower;

        public string Host
        {
            get => host;
            set => host = value;
        }

        public string Port
        {
            get => port;
            set => port = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string Database
        {
            get => database;
            set => database = value;
        }

        public int CryptPower
        {
            get => cryptPower;
            set => cryptPower = value;
        }

        public override string ToString()
        {
            return String.Format("Connection({0}, {1}, {2}, {3}, {4})", host, port, username, password, cryptPower);
        }

        public string GenerateString()
        {
            var connectionString = String.Format("host = {0}; port = {1}; username = {2}; password = {3}; " +
                "database = {4}", host, port, Decrypt(username), Decrypt(password), database);
            return connectionString;
        }

        public string Encrypt(string data)
        {
            var sb = new StringBuilder();
            foreach (char c in data)
                sb.Append((char)(c + cryptPower));

            return sb.ToString();
        }

        public string Decrypt(string data)
        {
            var sb = new StringBuilder();
            foreach (char c in data)
                sb.Append((char)(c - cryptPower));

            return sb.ToString();
        }
    }
}