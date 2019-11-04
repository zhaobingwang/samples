using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeSnippets.WebApi
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var conncetion = new SqlConnection("Server=.;Initial Catalog=master;Integrated Security=true"))
            {
                try
                {
                    conncetion.Open();
                }
                catch (SqlException)
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }

    public class SqliteHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var conncetion = new SqliteConnection("Data Source=c:/db/codesnippets.db"))
            {
                try
                {
                    conncetion.Open();
                }
                catch (SqlException)
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}
