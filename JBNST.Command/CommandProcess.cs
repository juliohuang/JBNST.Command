using System.Data;

namespace JBNST.Command
{
    public delegate void CommandProcess(IDbCommand command);

    public delegate T CommandProcess<T>(IDbCommand command, T result);
}