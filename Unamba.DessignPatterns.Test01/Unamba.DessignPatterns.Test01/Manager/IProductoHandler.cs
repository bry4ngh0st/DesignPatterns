using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unamba.DessignPatterns.Test01.Manager
{
    public interface IProductoHandler
    {
        Producto Get(string id);
        List<Producto> GetAll();
    }
}
