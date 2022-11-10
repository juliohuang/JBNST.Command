using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;

namespace JBNST.Command.Test
{
    [TestClass]
    public class UnitTest1
    {
 

        
        [TestInitialize]
        public void Init( )
        {
 
           Commands.AddDb("main", "Server=localhost;Uid=root;Pwd=123456;convert zero datetime=true;", typeof(MySqlConnection));
        }

        [TestMethod]
        public void TestValueTuple()
        {
            var item = GetCommand()
                .Read<(int id, string code, string name)>(new { id = 1 });

            Console.WriteLine("{0},{1},{2}", item.id, item.code, item.name);
        }

        [TestMethod]
        public void TestModel()
        {
            var item = GetCommand()
                .Read<CompanyModel>(new { id = 1 });

            Console.WriteLine("{0},{1},{2}", item.id, item.code, item.name);
        }

        [TestMethod]
        public void TestValueTupleList()
        {
            var list = GetCommand2()
                .Read<List<(int id, string code, string name)>>();

            // var item = list[0];
            foreach (var item in list)
            {
                Console.WriteLine("{0},{1},{2}", item.id, item.code, item.name);
            }

        }

        [TestMethod]
        public void TestModelList()
        {
            var list = GetCommand2()
                .Read<List<CompanyModel>>();


            foreach (var item in list)
            {
                Console.WriteLine("{0},{1},{2}", item.id, item.code, item.name);
            }


        }

        [TestMethod]
        public void TestTuple()
        {
            var item = GetCommand()
                .Read<Tuple<int, string, string>>(new { id = 1 });

            Console.WriteLine("{0},{1},{2}", item.Item1, item.Item2, item.Item3);
        }

        [TestMethod]
        public void TestTupleList()
        {
            var list = GetCommand()
                .Read<List<Tuple<int, string, string>>>(new { id = 1 });

            var item = list[0];
            
            Console.WriteLine("{0},{1},{2}", item.Item1, item.Item2, item.Item3);
        }

        [TestMethod]
        public void TestDictionaryList()
        {
            var list = GetCommand()
                .Read<List<Dictionary<string, object>>>(new { id = 1 });

            var map = list[0];

            Console.WriteLine("{0},{1},{2}", map["id"], map["code"], map["name"]);
        }

        [TestMethod]
        public void TestDictionary()
        {
            var map = GetCommand3()
                .Read<Dictionary<string, object>>(new { id = 1 });


            Console.WriteLine("{0},{1},{2},{3}", map["id"], map["code"], map["name"], map["entityId"]);
        }

        private static Command GetCommand()
        {
            

            return Commands.GetCommand("select 1 id, 'jbnst' code, '½³±¶' name");
        }

        private static Command GetCommand2()
        {
            return Commands.GetCommand("select 1 id, 'jbnst' code, '½³±¶' name\r\nunion all\r\nselect 2 id, 'jbnst2' code, '½³±¶2' name");
        }

        private static Command GetCommand3()
        {


            return Commands.GetCommand("select 1 id, 'jbnst' code, '½³±¶' name, 9 entityId");
        }
    }
}
