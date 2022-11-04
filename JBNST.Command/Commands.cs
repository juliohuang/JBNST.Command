using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace JBNST.Command
{
    /// <summary>
    ///     Commands
    /// </summary>
    public class Commands : List<Command>
    {
        private static Dictionary<string, string> Connections=new Dictionary<string, string>();

        private static Dictionary<string, CommandConfig> Configs=new Dictionary<string, CommandConfig>();

        public static void AddDb(string name, string conn, Type type,bool snake=false)
        { 
            Connections[name]=conn;
            Configs[name] = new CommandConfig(){provider = type,snake = snake};
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static Command GetCommand(string sql, string dbName = "main")
        {
            var snake = false;
            if (Configs.TryGetValue(dbName, out var config)) snake = config.snake;
            return new Command { DbName = dbName, Text = sql, Snake = snake };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static IDbTransaction BeginTransaction(string dbName = "main")
        {
            var connection = DbConnection(dbName);
            connection.OpenIfClose();
            return connection.BeginTransaction();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IDbConnection DbConnection(string name)
        {
            var settings = Connections[name];

            // default SqlServer

            var connectionString = settings;
            Type type;
            if (Configs.TryGetValue(name, out var config))
                type = config.provider;
            else
                return null;

            Debug.Assert(type != null, "type != null");

            var instance = Activator.CreateInstance(type, connectionString);
            return instance as IDbConnection;
        }

        public static T Procedure<T>()
        {
            return default;
        }
    }
}