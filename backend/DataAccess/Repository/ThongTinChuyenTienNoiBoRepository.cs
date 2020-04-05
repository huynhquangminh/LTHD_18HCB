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
    public class ThongTinChuyenTienNoiBoRepository : DataProvider, IThongTinChuyenTienNoiBoRepository
    {
        public ThongTinChuyenTienNoiBoRepository(IDbConnection dbConnection, IDbTransaction transaction)
        : base(dbConnection, transaction)
        {

        }

        public async Task<int> ChuyenKhoanNoiBo(ThongTinChuyenTienNoiBoDO thongTinChuyenTienNoiBo)
        {
            var param = new DynamicParameters();
            param.Add("@matk", thongTinChuyenTienNoiBo.MaTk);
            param.Add("@ngayGD", thongTinChuyenTienNoiBo.NgayGd);
            param.Add("@stkGui", thongTinChuyenTienNoiBo.StkGui);
            param.Add("@stkNhan", thongTinChuyenTienNoiBo.StkNhan);
            param.Add("@sotiengui", thongTinChuyenTienNoiBo.SoTienGui);
            param.Add("@noidung", thongTinChuyenTienNoiBo.NoiDung);
            param.Add("@loaitraphi", thongTinChuyenTienNoiBo.LoaiTraPhi);

            var result = await ExecuteCommandAsync(StoredProcedure.THONGTINCHUYENTIENNOIBO_CHUYENKHOANNOIBO, param);
            return result;
        }

        public async Task<List<ThongTinChuyenTienNoiBoDO>> GetDanhSachGiaoDich()
        {
            var result = await QueryCommandAsync<ThongTinChuyenTienNoiBoDO>(StoredProcedure.THONGTINCHUYENTIENNOIBO_GETDANHSACHGIAODICH);
            return result.ToList();
        }

        public async Task<List<ThongTinChuyenTienNoiBoDO>> GetGiaoDichGuiTienNoiBo(string soTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@stk", soTaiKhoan);

            var result = await QueryCommandAsyncWithParam<ThongTinChuyenTienNoiBoDO>(StoredProcedure.THONGTINCHUYENTIENNOIBO_GETGIAODICHGUITIENNOIBO, param);
            return result.ToList();
        }

        public async Task<List<ThongTinChuyenTienNoiBoDO>> GetGiaoDichNhanTienNoiBo(string soTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@sotaikhoan", soTaiKhoan);

            var result = await QueryCommandAsyncWithParam<ThongTinChuyenTienNoiBoDO>(StoredProcedure.THONGTINCHUYENTIENNOIBO_GETGIAODICHNHANTIENNOIBO, param);
            return result.ToList();
        }

        public async Task<List<ThongTinChuyenTienNoiBoDO>> TimKiemGiaoDich(string key)
        {
            var param = new DynamicParameters();
            param.Add("@key", key);

            var result = await QueryCommandAsyncWithParam<ThongTinChuyenTienNoiBoDO>(StoredProcedure.THONGTINCHUYENTIENNOIBO_TIMKIEMGIAODICH, param);

            return result.ToList();
        }

        public async Task<int> XoaGiaoDich(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);

            var result = await ExecuteCommandAsync(StoredProcedure.THONGTINCHUYENTIENNOIBO_XOA_GIAODICH, param);

            return result;
        }
    }
}
