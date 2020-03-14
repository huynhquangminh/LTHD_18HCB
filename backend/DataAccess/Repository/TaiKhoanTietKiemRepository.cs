using Dapper;
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
    public class TaiKhoanTietKiemRepository : DataProvider, ITaiKhoanTietKiemRepository
    {
        public TaiKhoanTietKiemRepository(IDbConnection dbConnection, IDbTransaction transaction)
       : base(dbConnection, transaction)
        {
        }

        public async Task<List<TaiKhoanTietKiemDO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandAsyncWithParam<TaiKhoanTietKiemDO>(StoredProcedure.TAIKHOANTIETKIEM_GET_BY_MATAIKHOAN, param);
            return result.ToList();
        }
    }
}
