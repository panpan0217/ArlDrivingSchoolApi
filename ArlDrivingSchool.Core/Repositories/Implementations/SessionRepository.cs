using ArlDrivingSchool.Core.Models;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class SessionRepository : DapperRepository, ISessionRepository
    {
        private IConfiguration Configuration { get; }

        public SessionRepository(IConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
        }
    }
}
