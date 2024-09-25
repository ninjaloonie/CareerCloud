﻿using CareerCloud.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CareerCloud.EntityFrameworkDataAccess;

public class CareerCloudContextFactory(ICareerCloudConfigResolver careerCloudConfigResolver) : IDbContextFactory<CareerCloudContext>
{
    private readonly ICareerCloudConfigResolver _careerCloudConfigResolver = careerCloudConfigResolver;

    public CareerCloudContext CreateDbContext()
    {
        return new CareerCloudContext(_careerCloudConfigResolver);
    }
}
