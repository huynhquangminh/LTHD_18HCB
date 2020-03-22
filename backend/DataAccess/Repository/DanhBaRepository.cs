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
    public class DanhBaRepository : DataProvider, IDanhBaRepository
    {
        public DanhBaRepository(IDbConnection dbConnection, IDbTransaction transaction)
        : base(dbConnection, transaction)
        {

        }

        public async Task<int> SuaDanhBa(DanhBaDO danhBa)
        {
            var param = new DynamicParameters();
            param.Add("@id", danhBa.Id);
            param.Add("@matk", danhBa.MaTk);
            param.Add("@tengoinho", danhBa.TenGoiNho);
            param.Add("@tennganhang", danhBa.TenNganHang);
            param.Add("@sotaikhoan", danhBa.SoTaiKhoan);

            var result = await ExecuteCommandAsync(StoredProcedure.DANHBA_SUA, param);
            return result;
        }

        public async Task<List<DanhBaDO>> GetDanhSachDanhBa(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandAsyncWithParam<DanhBaDO>(StoredProcedure.DANHBA_GETDANHSACH, param);
            return result.ToList();
        }

        public async Task<int> ThemDanhBa(DanhBaDO danhBa)
        {
            var param = new DynamicParameters();
            param.Add("@matk", danhBa.MaTk);
            param.Add("@tengoinho", danhBa.TenGoiNho);
            param.Add("@tennganhang", danhBa.TenNganHang);
            param.Add("@sotaikhoan", danhBa.SoTaiKhoan);
            param.Add("@idnganhanglienket", danhBa.idNganHangLienKet);

            var result = await ExecuteCommandAsync(StoredProcedure.DANHBA_THEM, param);
            return result;
        }

        public async Task<int> XoaDanhBa(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);

            var result = await ExecuteCommandAsync(StoredProcedure.DANHBA_XOA, param);
            return result;
        }
    }
}
