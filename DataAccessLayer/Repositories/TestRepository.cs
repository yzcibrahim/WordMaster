using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TestRepository:RepositoryBase<Test> , ITestRepository
    {
        public TestRepository(WordMasterDbContext context):base(context)
        {

        }
    }
}
