using AutoMapper;
using BusinessLogic.AutoMapperConfig;
using BusinessLogic.Service.Interface;
using BusinessObject;
using DataAccess.Infrastructure;
using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class UserService : IUserService
    {
        public async Task<int> UpdateRefreshToken(string maTaiKhoan, string refreshToken)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.UpdateRefreshToken(maTaiKhoan, refreshToken);
                    dal.UnitOfWork.Commit();
                } catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<List<UserBO>> GetAllUsers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();

            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetAllUser();
                return mapper.Map<List<UserBO>>(result);
            }
        }

        public async Task<UserBO> GetUserByUserName(string userName)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetUserByUserName(userName);
                return MapperHelper.Map<UserDO, UserBO>(result);
            }
        }

        public async Task<UserBO> GetThongTinTaiKhoanKhachHang(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetThongTinTaiKhoanKhachHang(maTaiKhoan);
                return MapperHelper.Map<UserDO, UserBO>(result);
            }
        }

        public async Task<UserBO> GetUserByUserNamePassword(string userName, string password)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetUserByUserNamePassword(userName, password);
                return mapper.Map<UserBO>(result);
            }
        }

        public async Task<UserBO> GetUserByTenDangNhap(string tenDangNhap)
        {
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetUserByTenDangNhap(tenDangNhap);
                return MapperHelper.Map<UserDO, UserBO>(result);
            }
        }

        public async Task<UserBO> GetThongTinTaiKhoan(string maTaiKhoan)
        {
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetThongTinTaiKhoan(maTaiKhoan);
                return MapperHelper.Map<UserDO, UserBO>(result);
            }
        }

        public async Task<int> DoiMatKhau(string maTaiKhoan, string matKhauMoi)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.DoiMatKhau(maTaiKhoan, matKhauMoi);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public string GetPasswordByMaTk(string maTaiKhoan)
        {
            using (DalSession dal = new DalSession())
            {
                var result = dal.UnitOfWork.UserRepository.GetPasswordByMaTk(maTaiKhoan);
                return result;
            }
        }

        public async Task<int> QuenMatKhau(string tenDangNhap, string email, string matKhauMoi)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.QuenMatKhau(tenDangNhap, email, matKhauMoi);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<UserBO> GetThongTinTaiKhoanBySoTaiKhoan(string soTaiKhoan)
        {
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetThongTinTaiKhoanBySoTaiKhoan(soTaiKhoan);
                return MapperHelper.Map<UserDO, UserBO>(result);
            }
        }

        public async Task<int> UpdateSoDuSauKhiChuyenKhoanNoiBo(string taiKhoanGui, string taiKhoanNhan, int soTienGui)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.UpdateSoDuSauKhiChuyenKhoanNoiBo(taiKhoanGui, taiKhoanNhan, soTienGui);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<List<UserBO>> TimKiemThongTinTaiKhoan(string key)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();

            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.TimKiemThongTinTaiKhoan(key);
                return mapper.Map<List<UserBO>>(result);
            }
        }

        public async Task<UserBO> GetThongTinTaiKhoanAdmin(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();

            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetThongTinTaiKhoanAdmin(maTaiKhoan);
                return mapper.Map<UserBO>(result);
            }
        }

        public async Task<int> ThemTaiKhoanDangNhap(TaiKhoanDangNhapBO taiKhoanDangNhap)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanDangNhapBO, TaiKhoanDangNhapDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<TaiKhoanDangNhapDO>(taiKhoanDangNhap);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.ThemTaiKhoanDangNhap(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<int> ThemThongTinTaiKhoanKhachHang(TaiKhoanKhachHangBO taiKhoanKhachHang)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanKhachHangBO, TaiKhoanKhachHangDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<TaiKhoanKhachHangDO>(taiKhoanKhachHang);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.ThemThongTinTaiKhoanKhachHang(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<int> UpdateThongTinTaiKhoanKhachHang(TaiKhoanKhachHangBO taiKhoanKhachHang)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanKhachHangBO, TaiKhoanKhachHangDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<TaiKhoanKhachHangDO>(taiKhoanKhachHang);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.UpdateThongTinTaiKhoanKhachHang(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<int> UpdateThongTinTaiKhoanNhanVien(TaiKhoanNhanVienBO taiKhoanNhanVien)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanNhanVienBO, TaiKhoanNhanVienDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<TaiKhoanNhanVienDO>(taiKhoanNhanVien);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.UpdateThongTinTaiKhoanNhanVien(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<int> XoaTaiKhoan(string maTaiKhoan)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.XoaTaiKhoan(maTaiKhoan);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<List<TaiKhoanNhanVienBO>> GetDanhSachTaiKhoanAdmin()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanNhanVienDO, TaiKhoanNhanVienBO>();
            });
            var mapper = config.CreateMapper();

            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetDanhSachTaiKhoanAdmin();
                return mapper.Map<List<TaiKhoanNhanVienBO>>(result);
            }
        }

        public async Task<int> ThemTaiKhoanNhanVien(TaiKhoanNhanVienBO taiKhoanNhanVien)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanNhanVienBO, TaiKhoanNhanVienDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<TaiKhoanNhanVienDO>(taiKhoanNhanVien);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.ThemTaiKhoanNhanVien(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }

        public async Task<string> GetRefreshTokenByMaTk(string maTaiKhoan)
        {
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetRefreshTokenByMaTk(maTaiKhoan);
                return result;
            }
        }

        public async Task<int> UpdateSoDuGiaoDichKhacNganHang(string soTaiKhoan, int soTien, bool loaiGiaoDich)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.UserRepository.UpdateSoDuGiaoDichKhacNganHang(soTaiKhoan, soTien, loaiGiaoDich);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException(ex);
                }
                return result;
            }
        }
    }
}
