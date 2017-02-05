using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models
{
    public interface ISearchable
    {
        string ToString();
        string SearchString { get; }
    }
}
