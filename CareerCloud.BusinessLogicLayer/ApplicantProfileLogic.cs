﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.BusinessLogicLayer;

public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
{
    public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
    {
    }

    protected override void Verify(ApplicantProfilePoco[] pocos)
    {
        throw new NotImplementedException();
    }
}
