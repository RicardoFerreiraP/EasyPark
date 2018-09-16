using System;
using System.Collections.Generic;
using EasyPark.Models;
using System.Linq;
using System.Data.Entity;

namespace EasyPark.DAL
{
    public class ClienteDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static Cliente BuscarClientePorID(int id)
        {
             return ctx.Clientes.Find(id);
        }
        public static Cliente BuscarClientePorCPF(string cliente)
        {
            return ctx.Clientes.FirstOrDefault(x => x.CPF.Equals(cliente));
        }

        public static bool CadastrarCliente(Cliente cliente)
        {
            if (BuscarClientePorCPF(cliente.CPF) == null)
            {
                ctx.Clientes.Add(cliente);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Cliente> ListarTodosClientes()
        {
            return ctx.Clientes.ToList();
        }

        public static void AlterarCliente(Cliente cliente)
        {           
             ctx.Entry(cliente).State = EntityState.Modified;
             ctx.SaveChanges();            
        }

        public static void RemoverCliente(int id)
        {
            ctx.Clientes.Remove(BuscarClientePorID(id));
            ctx.SaveChanges();
        }

        
    }
}