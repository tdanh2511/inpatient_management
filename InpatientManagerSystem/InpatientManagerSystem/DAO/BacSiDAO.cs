using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;

namespace InpatientManagerSystem.DAO
{
    public class BacSiDAO
    {
        private DBConnection dbConnection = new DBConnection();

        // Lấy tất cả bác sĩ
        public List<BacSi> GetAll()
        {
            List<BacSi> list = new List<BacSi>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT bs.STT, bs.MaBacSi, bs.MaNguoiDung, bs.HoTen, bs.NgaySinh, 
        bs.GioiTinh, bs.CCCD, bs.DiaChi, bs.KinhNghiem, bs.ChuyenKhoa,
        nd.TenDangNhap as TenNguoiDung
              FROM bacsi bs
         LEFT JOIN nguoidung nd ON bs.MaNguoiDung = nd.MaNguoiDung
   ORDER BY bs.STT ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BacSi bs = new BacSi
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : (DateTime?)null,
                                GioiTinh = reader["GioiTinh"].ToString(),
                                CCCD = reader["CCCD"]?.ToString() ?? "",
                                DiaChi = reader["DiaChi"]?.ToString() ?? "",
                                KinhNghiem = reader["KinhNghiem"] != DBNull.Value ? Convert.ToInt32(reader["KinhNghiem"]) : (int?)null,
                                ChuyenKhoa = reader["ChuyenKhoa"]?.ToString() ?? "",
                                TenNguoiDung = reader["TenNguoiDung"]?.ToString() ?? ""
                            };
                            list.Add(bs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách bác sĩ: " + ex.Message);
            }
            return list;
        }

        // Thêm bác sĩ mới
        public bool Insert(BacSi bacSi)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // Lưu ý: MaBacSi được tự động sinh bởi trigger trong DB
                    string query = @"INSERT INTO bacsi (MaBacSi, MaNguoiDung, HoTen, NgaySinh, GioiTinh, CCCD, DiaChi, KinhNghiem, ChuyenKhoa) 
    VALUES ('', @MaNguoiDung, @HoTen, @NgaySinh, @GioiTinh, @CCCD, @DiaChi, @KinhNghiem, @ChuyenKhoa)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiDung", bacSi.MaNguoiDung);
                        cmd.Parameters.AddWithValue("@HoTen", bacSi.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", bacSi.NgaySinh.HasValue ? (object)bacSi.NgaySinh.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", bacSi.GioiTinh);
                        cmd.Parameters.AddWithValue("@CCCD", bacSi.CCCD ?? "");
                        cmd.Parameters.AddWithValue("@DiaChi", bacSi.DiaChi ?? "");
                        cmd.Parameters.AddWithValue("@KinhNghiem", bacSi.KinhNghiem.HasValue ? (object)bacSi.KinhNghiem.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@ChuyenKhoa", bacSi.ChuyenKhoa ?? "");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm bác sĩ: " + ex.Message);
            }
        }

        // Cập nhật thông tin bác sĩ
        public bool Update(BacSi bacSi)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE bacsi SET 
         MaNguoiDung = @MaNguoiDung, 
     HoTen = @HoTen, 
  NgaySinh = @NgaySinh, 
         GioiTinh = @GioiTinh, 
            CCCD = @CCCD, 
  DiaChi = @DiaChi, 
      KinhNghiem = @KinhNghiem, 
       ChuyenKhoa = @ChuyenKhoa 
         WHERE MaBacSi = @MaBacSi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBacSi", bacSi.MaBacSi);
                        cmd.Parameters.AddWithValue("@MaNguoiDung", bacSi.MaNguoiDung);
                        cmd.Parameters.AddWithValue("@HoTen", bacSi.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", bacSi.NgaySinh.HasValue ? (object)bacSi.NgaySinh.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@GioiTinh", bacSi.GioiTinh);
                        cmd.Parameters.AddWithValue("@CCCD", bacSi.CCCD ?? "");
                        cmd.Parameters.AddWithValue("@DiaChi", bacSi.DiaChi ?? "");
                        cmd.Parameters.AddWithValue("@KinhNghiem", bacSi.KinhNghiem.HasValue ? (object)bacSi.KinhNghiem.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@ChuyenKhoa", bacSi.ChuyenKhoa ?? "");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật bác sĩ: " + ex.Message);
            }
        }

        // Xóa bác sĩ
        public bool Delete(string maBacSi)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM bacsi WHERE MaBacSi = @MaBacSi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa bác sĩ: " + ex.Message);
            }
        }

        // Tìm kiếm bác sĩ
        public List<BacSi> Search(string keyword)
        {
            List<BacSi> list = new List<BacSi>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT bs.STT, bs.MaBacSi, bs.MaNguoiDung, bs.HoTen, bs.NgaySinh, 
        bs.GioiTinh, bs.CCCD, bs.DiaChi, bs.KinhNghiem, bs.ChuyenKhoa,
     nd.TenDangNhap as TenNguoiDung
            FROM bacsi bs
    LEFT JOIN nguoidung nd ON bs.MaNguoiDung = nd.MaNguoiDung
    WHERE bs.MaBacSi LIKE @keyword 
             OR bs.HoTen LIKE @keyword 
   OR bs.CCCD LIKE @keyword 
               OR bs.ChuyenKhoa LIKE @keyword
OR nd.TenDangNhap LIKE @keyword
            ORDER BY bs.STT ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BacSi bs = new BacSi
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : (DateTime?)null,
                                GioiTinh = reader["GioiTinh"].ToString(),
                                CCCD = reader["CCCD"]?.ToString() ?? "",
                                DiaChi = reader["DiaChi"]?.ToString() ?? "",
                                KinhNghiem = reader["KinhNghiem"] != DBNull.Value ? Convert.ToInt32(reader["KinhNghiem"]) : (int?)null,
                                ChuyenKhoa = reader["ChuyenKhoa"]?.ToString() ?? "",
                                TenNguoiDung = reader["TenNguoiDung"]?.ToString() ?? ""
                            };
                            list.Add(bs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm bác sĩ: " + ex.Message);
            }
            return list;
        }

        // Lấy bác sĩ theo mã
        public BacSi GetByMa(string maBacSi)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT bs.STT, bs.MaBacSi, bs.MaNguoiDung, bs.HoTen, bs.NgaySinh, 
          bs.GioiTinh, bs.CCCD, bs.DiaChi, bs.KinhNghiem, bs.ChuyenKhoa,
         nd.TenDangNhap as TenNguoiDung
  FROM bacsi bs
    LEFT JOIN nguoidung nd ON bs.MaNguoiDung = nd.MaNguoiDung
       WHERE bs.MaBacSi = @MaBacSi";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BacSi
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = reader["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(reader["NgaySinh"]) : (DateTime?)null,
                                GioiTinh = reader["GioiTinh"].ToString(),
                                CCCD = reader["CCCD"]?.ToString() ?? "",
                                DiaChi = reader["DiaChi"]?.ToString() ?? "",
                                KinhNghiem = reader["KinhNghiem"] != DBNull.Value ? Convert.ToInt32(reader["KinhNghiem"]) : (int?)null,
                                ChuyenKhoa = reader["ChuyenKhoa"]?.ToString() ?? "",
                                TenNguoiDung = reader["TenNguoiDung"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin bác sĩ: " + ex.Message);
            }
            return null;
        }

        // Kiểm tra CCCD đã tồn tại
        public bool CheckCCCDExists(string cccd, string maBacSi = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM bacsi WHERE CCCD = @CCCD";
                    if (!string.IsNullOrEmpty(maBacSi))
                    {
                        query += " AND MaBacSi != @MaBacSi";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    if (!string.IsNullOrEmpty(maBacSi))
                    {
                        cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra CCCD: " + ex.Message);
            }
        }

        // Kiểm tra MaNguoiDung đã được sử dụng chưa (mỗi người dùng chỉ có 1 bác sĩ)
        public bool CheckMaNguoiDungExists(int maNguoiDung, string maBacSi = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM bacsi WHERE MaNguoiDung = @MaNguoiDung";
                    if (!string.IsNullOrEmpty(maBacSi))
                    {
                        query += " AND MaBacSi != @MaBacSi";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                    if (!string.IsNullOrEmpty(maBacSi))
                    {
                        cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra mã người dùng: " + ex.Message);
            }
        }

        // Lấy danh sách người dùng vai trò BacSi chưa được gán
        public List<NguoiDung> GetAvailableNguoiDungBacSi()
        {
            List<NguoiDung> list = new List<NguoiDung>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MaNguoiDung, TenDangNhap, HoTen, Email, SoDienThoai, VaiTro
                     FROM nguoidung
                     WHERE VaiTro = 'BacSi' 
                     AND TrangThai = 1
                     AND MaNguoiDung NOT IN (SELECT MaNguoiDung FROM bacsi)
                     ORDER BY MaNguoiDung ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung nd = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                Email = reader["Email"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
                                VaiTro = reader["VaiTro"]?.ToString() ?? ""
                            };
                            list.Add(nd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách người dùng bác sĩ: " + ex.Message);
            }
            return list;
        }

        // Lấy tất cả người dùng vai trò BacSi
        public List<NguoiDung> GetAllNguoiDungBacSi()
        {
            List<NguoiDung> list = new List<NguoiDung>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MaNguoiDung, TenDangNhap, HoTen, Email, SoDienThoai, VaiTro
                   FROM nguoidung
        WHERE VaiTro = 'BacSi' AND TrangThai = 1
       ORDER BY MaNguoiDung ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung nd = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                Email = reader["Email"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
                                VaiTro = reader["VaiTro"]?.ToString() ?? ""
                            };
                            list.Add(nd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách người dùng bác sĩ: " + ex.Message);
            }
            return list;
        }
    }
}
