using System.Data;

namespace JBNST.Command
{
    public delegate T PreRead<out T>(DataTable reader);
}