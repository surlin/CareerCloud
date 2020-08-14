using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
    {
        public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }

        public override void Update(CompanyProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            foreach (CompanyProfilePoco poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyWebsite))
                {
                    exceptions.Add(new ValidationException(600, "Valid websites must end with the following extensions – .ca, .com, .biz"));
                }
                else if (!Regex.Match(poco.CompanyWebsite, @"^.*\.(ca|com|biz)$").Success)
                {
                    exceptions.Add(new ValidationException(600, "Valid websites must end with the following extensions – .ca, .com, .biz"));
                }

                if (string.IsNullOrEmpty(poco.ContactPhone))
                {
                    exceptions.Add(new ValidationException(601, "Must correspond to a valid phone number"));
                }
                else
                {
                    if (!Regex.Match(poco.ContactPhone, @"^[1-9]\d{3}-[1-9]\d{3}-\d{4}$").Success)
                    {
                        exceptions.Add(new ValidationException(601, "Must correspond to a valid phone number"));
                    }
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
