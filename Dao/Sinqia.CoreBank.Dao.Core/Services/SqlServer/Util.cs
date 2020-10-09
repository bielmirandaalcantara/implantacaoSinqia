using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Services.SqlServer
{
    public static class Util
    {
        public const string paramPrefixo = "@";

        public static string GerarQueryInsert(object entity)
        {
            StringBuilder query = new StringBuilder();
            string campos = string.Empty;
            string paramValues = string.Empty;

            Type objType = entity.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (string.IsNullOrEmpty(campos))
                {
                    campos = prop.Name;
                    paramValues = paramPrefixo + prop.Name;
                }
                else
                {
                    campos = campos + ", " + prop.Name;
                    paramValues = paramValues + ", " + paramPrefixo + prop.Name;
                }
            }

            query.AppendFormat(" insert into {0} ", objType.Name);
            query.AppendFormat(" ({0}) ", campos);
            query.AppendFormat(" values ({0}) ", paramValues);

            return query.ToString();
        }

        public static string GerarQueryUpdate(object entity, string where, List<string> camposSelecionados = null)
       {
            StringBuilder query = new StringBuilder();

            Type objType = entity.GetType();
            PropertyInfo[] properties = objType.GetProperties();            
            string sets = string.Empty;
            foreach (PropertyInfo prop in properties)
            {
                if (camposSelecionados != null && !camposSelecionados.Any(c => c.Equals(prop.Name))) continue;
               
                if (string.IsNullOrEmpty(sets))
                    sets = $" {prop.Name} = {paramPrefixo + prop.Name} ";
                else
                    sets = sets + $" ,  {prop.Name} = {paramPrefixo + prop.Name} ";                                              
            }

            query.AppendFormat(" update {0} set {1} ", objType.Name, sets);
            if (!string.IsNullOrEmpty(where))  query.AppendFormat("  where {2} ", objType.Name, sets, where);

            return query.ToString();
        }

        public static string GerarQuerySelect(object entity, string where)
        {
            StringBuilder query = new StringBuilder();
            string campos = string.Empty;

            Type objType = entity.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (string.IsNullOrEmpty(campos))
                    campos = prop.Name;
                else
                    campos = campos + ", " + prop.Name;
            }

            query.AppendFormat(" select {0} ", campos);
            query.AppendFormat(" from {0} ", objType.Name);
            if(!string.IsNullOrEmpty(where)) query.AppendFormat(" where {0} ", where);

            return query.ToString();
        }

        public static string GerarQueryDelete(object entity, string where)
        {
            StringBuilder query = new StringBuilder();
            string campos = string.Empty;

            Type objType = entity.GetType();
            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                if (string.IsNullOrEmpty(campos))
                    campos = prop.Name;
                else
                    campos = campos + ", " + prop.Name;
            }

            //trava para o delete sem where
            if (string.IsNullOrEmpty(where))
                throw new ApplicationException("Não é permitido um delete sem filtro pela aplicação");

            query.AppendFormat(" delete from {0} ", objType.Name);
            if (!string.IsNullOrEmpty(where)) query.AppendFormat(" where {0} ", where);

            return query.ToString();
        }
    }
}
