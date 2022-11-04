using System.Data;

namespace JBNST.Command
{
    /// <summary>
    ///     Sql 命令
    /// </summary>
    public class Command
    {
        /// <summary>
        /// 
        /// </summary>
        public Command()
        {
            CommandType = CommandType.Text;
        }


        /// <summary>
        ///     ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     DataBase Name
        /// </summary>

        public string DbName { get; set; }

        /// <summary>
        ///     Command Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Command Type
        /// </summary>
        public CommandType CommandType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Snake { get; set; }
    }
}