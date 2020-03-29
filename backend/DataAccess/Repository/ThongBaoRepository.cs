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
    public class ThongBaoRepository : DataProvider, IThongBaoRepository
    {
        public ThongBaoRepository(IDbConnection dbConnection, IDbTransaction transaction)
        : base(dbConnection, transaction)
        {
        }

        public async Task<List<ThongBaoDO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandAsyncWithParam<ThongBaoDO>(StoredProcedure.THONGBAO_GETDANHSACH, param);
            return result.ToList();
        }

        public async Task<int> Them(string maTaiKhoan, string noiDung)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);
            param.Add("@noidung", noiDung);

            var result = await ExecuteCommandAsync(StoredProcedure.THONGBAO_THEM, param);
            return result;
        }

        public async Task<int> Update(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);

            var result = await ExecuteCommandAsync(StoredProcedure.THONGBAO_UPDATE, param);
            return result;
        }
    }
}
