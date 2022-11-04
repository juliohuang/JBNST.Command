using System.Data;

namespace JBNST.Command
{
    public partial class CommandExtend
    {
        /// <summary>
        ///     执行
        /// </summary>
        /// <param name="command"></param>
        /// <param name="paras"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static bool Exec(this Command command, object paras, IDbTransaction? transaction = null)
        {
            var dictionary = ToDictionary(command, paras);
            return command.Exec(dictionary, transaction);
        }
    }
}