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
    public class ApplicantSkillRepository :
        IDataRepository<ApplicantSkillPoco>
    {
        public void Add(params ApplicantSkillPoco[] items)
        {

            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantSkillPoco pocos in items)
            {
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Skills]
                                           ([Id]
                                           ,[Applicant]
                                           ,[Skill]
                                           ,[Skill_Level]
                                           ,[Start_Month]
                                           ,[Start_Year]
                                           ,[End_Month]
                                           ,[End_Year])
                                     VALUES
                                           (@Id
                                           ,@Applicant
                                           ,@Skill
                                           ,@Skill_Level
                                           ,@Start_Month
                                           ,@Start_Year
                                           ,@End_Month
                                           ,@End_Year)";

                cmd.Parameters.AddWithValue("@Id", pocos.Id);
                cmd.Parameters.AddWithValue("@Applicant", pocos.Applicant);
                cmd.Parameters.AddWithValue("@Skill", pocos.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", pocos.SkillLevel);
                cmd.Parameters.AddWithValue("@Start_Month", pocos.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", pocos.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", pocos.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", pocos.EndYear);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"Select * from [dbo].[Applicant_Skills]";

            conn.Open();
            int x = 0;
            SqlDataReader rdr = cmd.ExecuteReader();
            ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[1000];

            while (rdr.Read())
            {
                ApplicantSkillPoco poco = new ApplicantSkillPoco();
                poco.Id = rdr.GetGuid(0);
                poco.Applicant = rdr.GetGuid(1);
                poco.Skill = rdr.GetString(2);
                poco.SkillLevel = rdr.GetString(3);
                poco.StartMonth = rdr.GetByte(4);
                poco.StartYear = rdr.GetInt32(5);
                poco.EndMonth = rdr.GetByte(6);
                poco.EndYear = rdr.GetInt32(7);
                poco.TimeStamp = (byte[])rdr[8];

                pocos[x] = poco;
                x++;
            }

            conn.Close();
            return pocos.Where(p => p !=null).ToList();
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantSkillPoco pocos in items)
            {
                cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Skills]
                                    WHERE Id= @Id";

                cmd.Parameters.AddWithValue("@Id", pocos.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            SqlConnection conn = new SqlConnection(BaseADO.connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantSkillPoco pocos in items)
            {
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Skills]
                                       SET [Applicant] = @Applicant
                                          ,[Skill] = @Skill
                                          ,[Skill_Level] = @Skill_Level
                                          ,[Start_Month] = @Start_Month
                                          ,[Start_Year] = @Start_Year
                                          ,[End_Month] = @End_Month
                                          ,[End_Year] = @End_Year
                                     WHERE Id= @Id";

                cmd.Parameters.AddWithValue("@Id", pocos.Id);
                cmd.Parameters.AddWithValue("@Applicant", pocos.Applicant);
                cmd.Parameters.AddWithValue("@Skill", pocos.Skill);
                cmd.Parameters.AddWithValue("@Skill_Level", pocos.SkillLevel);
                cmd.Parameters.AddWithValue("@Start_Month", pocos.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", pocos.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", pocos.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", pocos.EndYear);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
