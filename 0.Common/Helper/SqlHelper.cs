using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0.Common.Helper
{
    public static class SqlQueryExtensions
    {
        public static DbRawSqlQuery<TElement> ExtendedSqlQuery<TElement>(this Database db, string sql, params object[] parameters)
        {
            var listParameters = parameters.Where(n => n.GetType() == typeof(SqlListParameter)).ToArray();

            sql = listParameters.Aggregate(sql, (dbSql, parameter) => ApplyList(dbSql, parameter as SqlListParameter));

            parameters = parameters.Where(n => n.GetType() != typeof(SqlListParameter)).ToArray();

            return db.SqlQuery<TElement>(sql, parameters);
        }

        private static string ApplyList(string sql, SqlListParameter parameter)
        {
            var list = parameter.Value as IEnumerable<int>;

            if (list == null)
                throw new Exception("SqlListParameter value should has could be casted to IEnumerable<int>");

            var joinedListItems = string.Join(",", list);

            return sql.Replace(parameter.ParameterName, joinedListItems);
        }
    }
    public class SqlListParameter : DbParameter
    {
        private string _internalName;
        protected string InternalName
        {
            get => _internalName;
            set => _internalName = NormalizeParameterName(value);
        }

        public override DbType DbType { get; set; }
        public override ParameterDirection Direction { get; set; }
        public override bool IsNullable { get; set; }

        public override string SourceColumn { get; set; }
        public override object Value { get; set; }
        public override bool SourceColumnNullMapping { get; set; }
        public override int Size { get; set; }

        public override string ParameterName
        {
            get => InternalName;
            set => InternalName = value;
        }

        public override void ResetDbType()
        {

        }

        public SqlListParameter(string parameterName)
        {
            InternalName = parameterName;
        }

        internal static string NormalizeParameterName(string parameterName)
        {
            return string.IsNullOrWhiteSpace(parameterName) || parameterName.First() == '@'
                ? parameterName
                : "@" + parameterName;
        }
    }
}
