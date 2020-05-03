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

        public async Task<NganHangLienKetDO> GetNganHangLienKetByIdOrTenNganHang(int id, string tenNganHang)
        {
            var param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@tennganhang", tenNganHang);

            var result = await QueryCommandSingleAsync<NganHangLienKetDO>(StoredProcedure.NGANHANGLIENKET_GETBYID_TENNGANHANG, param);
            return result;
        }

        public async Task<int> Them(NganHangLienKetDO nganHangLienKet)
        {
            var param = new DynamicParameters();
            param.Add("@tennganhang", nganHangLienKet.TenNganHang);
            param.Add("@secretkey", nganHangLienKet.SecretKey);
            param.Add("@publickey", nganHangLienKet.PublicKey);

            var result = await ExecuteCommandAsync(StoredProcedure.NGANHANGLIENKET_THEM, param);
            return result;
        }

        public async Task<int> ThemThongTinGiaoDichKhacNganhang(ThongTinGiaoDichLienNganHangDO thongTinGiaoDichLienNganHang)
        {
            var param = new DynamicParameters();
            param.Add("@soTKGui", thongTinGiaoDichLienNganHang.SoTKGui);
            param.Add("@tenNganHangGui", thongTinGiaoDichLienNganHang.TenNganHangGui);
            param.Add("@soTkNhan", thongTinGiaoDichLienNganHang.SoTKNhan);
            param.Add("@tenNganHangNhan", thongTinGiaoDichLienNganHang.TenNganHangNhan);
            param.Add("@soTien", thongTinGiaoDichLienNganHang.SoTien);
            param.Add("@noiDung", thongTinGiaoDichLienNganHang.NoiDung);
            param.Add("@ngayTao", thongTinGiaoDichLienNganHang.NgayTao);

            var result = await ExecuteCommandAsync(StoredProcedure.NGANHANGLIENKET_THEMTHONGTINGIAODICHKHACNGANHANG, param);
            return result;
        }
    }
}
