﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
    {           
        public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
        {
        }

        public override void Add(CompanyJobPoco[] pocos)
        {
            base.Add(pocos);
        }

        public override void Update(CompanyJobPoco[] pocos)
        {
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobPoco[] pocos)
        {
            base.Verify(pocos);
        }
    }
}
