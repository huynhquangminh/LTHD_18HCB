using Dapper;
using DataAccess.Constant;
using DataAccess.Repository.Interface;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
