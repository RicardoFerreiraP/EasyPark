using EasyPark.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static List<Funcionario> ListarTodosFuncionarios()
        {
            return ctx.Funcionarios.ToList();
        }

        public static Funcionario BuscarFuncionarioPorID(int id)
        {
            return ctx.Funcionarios.Find(id);
        }

        public static Funcionario BuscarFuncionarioLogin(Funcionario funcionario)
        {
            return ctx.Funcionarios.FirstOrDefault(x => x.CPF.Equals(funcionario.CPF) && x.Senha.Equals(funcionario.Senha));
        }
        public static void AlterarFuncionario(Funcionario funcionario)
        {
            ctx.Entry(funcionario).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}