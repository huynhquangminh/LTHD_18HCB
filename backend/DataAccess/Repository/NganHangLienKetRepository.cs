using DataAccess.Constant;
using DataAccess.Repository.Interface;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class NganHangLienKetRepository : DataProvider, INganHangLienKetRepository
    {
        public NganHangLienKetRepository(IDbConnection dbConnection, IDbTransaction transaction)
        : base(dbConnection, transaction)
        {
        }

        public async Task<List<NganHangLienKetDO>> GetDanhSach()
        {
            var result = await QueryCommandAsync<NganHangLienKetDO>(StoredProcedure.NGANHANGLIENKET_GETALL);
            return result.ToList();
        }
    }
}
