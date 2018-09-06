using EasyPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPark.DAL
{
    public class FuncionarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static Funcionario BuscarFuncionarioPorCPF(Funcionario funcionario)
        {
            return ctx.Funcionarios.FirstOrDefault(x => x.CPF.Equals(funcionario.CPF));
        }
        public static bool CadastrarFuncionario(Funcionario funcionario)
        {
            if (BuscarFuncionarioPorCPF(funcionario) == null)
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}