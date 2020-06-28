using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobEducationRepository :
        IDataRepository<CompanyJobEducationPoco>
    {
        public void Add(params CompanyJobEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobEducationPoco pocos in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                                           ([Id]
                                           ,[Job]
                                           ,[Major]
                                           ,[Importance])
                                     VALUES
                                           (@Id
                                           ,@Job
                                           ,@Major
                                           ,@Importance)";

                cmd.Parameters.AddWithValue("@Id", pocos.Id);
                cmd.Parameters.AddWithValue("@Job", pocos.Job);
                cmd.Parameters.AddWithValue("@Major", pocos.Major);
                cmd.Parameters.AddWithValue("@Importance", pocos.Importance);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select * from [dbo].[Company_Job_Educations]";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[2000];

            while (rdr.Read())
            {
                CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Job = rdr.GetGuid(1);
                poco.Major = rdr.GetString(2);
                poco.Importance = rdr.GetInt16(3);
                poco.TimeStamp = (byte[])rdr[4];

                pocos[x] = poco;
                x++;
            }

            conn.Close();
            return pocos.Where(p => p !=null).ToList();
        }

        public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobEducationPoco pocos in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Educations]
                                    WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", pocos.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (CompanyJobEducationPoco pocos in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Company_Job_Educations]
                                       SET [Job] = @Job
                                          ,[Major] = @Major
                                          ,[Importance] = @Importance
                                     WHERE Id = @Id";

                cmd.Parameters.AddWithValue("@Id", pocos.Id);
                cmd.Parameters.AddWithValue("@Job", pocos.Job);
                cmd.Parameters.AddWithValue("@Major", pocos.Major);
                cmd.Parameters.AddWithValue("@Importance", pocos.Importance);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
