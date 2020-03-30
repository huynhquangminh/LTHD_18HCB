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
    public class NhacNoRepository : DataProvider, INhacNoRepository
    {
        public NhacNoRepository(IDbConnection dbConnection, IDbTransaction transaction)
       : base(dbConnection, transaction)
        {

        }

        public async Task<List<NhacNoDO>> GetDanhSachNguoiNo(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandAsyncWithParam<NhacNoDO>(StoredProcedure.NHACNO_GETDANHSACHNGUOINO, param);
            return result.ToList();
        }

        public async Task<List<NhacNoDO>> GetDanhSachNo(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandAsyncWithParam<NhacNoDO>(StoredProcedure.NHACNO_GETDANHSACHNO, param);
            return result.ToList();
        }

        public async Task<int> Them(NhacNo_ThemDO nhacNo)
        {
            var param = new DynamicParameters();
            param.Add("@matktao", nhacNo.MaTkTao);
            param.Add("@matkno", nhacNo.MaTkNo);
            param.Add("@sotienno", nhacNo.SoTienNo);
            param.Add("@noidungnhacno", nhacNo.NoiDungNhacNo);
            param.Add("@ngaytao", nhacNo.NgayTao);
            param.Add("@noidunghuynhacno", nhacNo.NoiDungHuyNhacNo);
            param.Add("@trangthai", nhacNo.TrangThai);

            var result = await ExecuteCommandAsync(StoredProcedure.NHACNO_THEM, param);
            return result;
        }

        public async Task<int> UpdateTrangThai(NhacNo_UpdateDO nhacNo)
        {
            var param = new DynamicParameters();
            param.Add("@id", nhacNo.id);
            param.Add("@matk", nhacNo.MaTk);
            param.Add("@trangthai", nhacNo.TrangThai);
            param.Add("@noidunghuynhacno", nhacNo.NoiDungHuyNhacNo);

            var result = await ExecuteCommandAsync(StoredProcedure.NHACNO_UPDATETRANGTHAI, param);
            return result;
        }
    }
}
