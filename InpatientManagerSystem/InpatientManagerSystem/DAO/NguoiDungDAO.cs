using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;

namespace InpatientManagerSystem.DAO
{
    public class NguoiDungDAO
    {
        private DBConnection dbConnection = new DBConnection();

        public List<NguoiDung> GetAll()
        {
            List<NguoiDung> list = new List<NguoiDung>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
<<<<<<< HEAD
                    string query = "SELECT MaNguoiDung, TenDangNhap, MatKhau, HoTen, VaiTro, Email, SoDienThoai, TrangThai, NgayTao FROM nguoidung ORDER BY MaNguoiDung ASC";
=======
                    string query = "SELECT * FROM nguoidung ORDER BY MaNguoiDung ASC";
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung nd = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
<<<<<<< HEAD
                                Email = reader["Email"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
=======
                                Email = reader["Email"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
                                TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                            list.Add(nd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách người dùng: " + ex.Message);
            }
            return list;
        }

<<<<<<< HEAD
        // Thêm người dùng
=======
        // Hàm thêm người dùng
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
        public bool Insert(NguoiDung nguoiDung)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
<<<<<<< HEAD
                    string query = "INSERT INTO nguoidung (TenDangNhap, MatKhau, HoTen, VaiTro, Email, SoDienThoai, TrangThai, NgayTao) " +
                                   "VALUES (@TenDangNhap, @MatKhau, @HoTen, @VaiTro, @Email, @SoDienThoai, @TrangThai, @NgayTao)";
=======
                    string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, Email, SoDienThoai, TrangThai) " +
                                   "VALUES (@TenDangNhap, @MatKhau, @HoTen, @VaiTro, @Email, @SoDienThoai, @TrangThai)";
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", nguoiDung.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", nguoiDung.MatKhau);
                        cmd.Parameters.AddWithValue("@HoTen", nguoiDung.HoTen);
                        cmd.Parameters.AddWithValue("@VaiTro", nguoiDung.VaiTro);
<<<<<<< HEAD
                        cmd.Parameters.AddWithValue("@Email", nguoiDung.Email ?? "");
                        cmd.Parameters.AddWithValue("@SoDienThoai", nguoiDung.SoDienThoai ?? "");
                        cmd.Parameters.AddWithValue("@TrangThai", nguoiDung.TrangThai ? 1 : 0);
                        cmd.Parameters.AddWithValue("@NgayTao", nguoiDung.NgayTao);

=======
                        cmd.Parameters.AddWithValue("@Email", nguoiDung.Email);
                        cmd.Parameters.AddWithValue("@SoDienThoai", nguoiDung.SoDienThoai);
                        cmd.Parameters.AddWithValue("@TrangThai", nguoiDung.TrangThai ? 1 : 0);
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm người dùng: " + ex.Message);
            }
        }
<<<<<<< HEAD

        // Cập nhật người dùng
        public bool Update(NguoiDung nguoiDung)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE nguoidung SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, HoTen = @HoTen, " +
                                   "VaiTro = @VaiTro, Email = @Email, SoDienThoai = @SoDienThoai, TrangThai = @TrangThai " +
                                   "WHERE MaNguoiDung = @MaNguoiDung";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiDung", nguoiDung.MaNguoiDung);
                        cmd.Parameters.AddWithValue("@TenDangNhap", nguoiDung.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", nguoiDung.MatKhau);
                        cmd.Parameters.AddWithValue("@HoTen", nguoiDung.HoTen);
                        cmd.Parameters.AddWithValue("@VaiTro", nguoiDung.VaiTro);
                        cmd.Parameters.AddWithValue("@Email", nguoiDung.Email ?? "");
                        cmd.Parameters.AddWithValue("@SoDienThoai", nguoiDung.SoDienThoai ?? "");
                        cmd.Parameters.AddWithValue("@TrangThai", nguoiDung.TrangThai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật người dùng: " + ex.Message);
            }
        }

        // Xóa người dùng
        public bool Delete(int maNguoiDung)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa người dùng: " + ex.Message);
            }
        }

        // Tìm kiếm người dùng
        public List<NguoiDung> Search(string keyword)
        {
            List<NguoiDung> list = new List<NguoiDung>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MaNguoiDung, TenDangNhap, MatKhau, HoTen, VaiTro, Email, SoDienThoai, TrangThai, NgayTao 
                                     FROM nguoidung 
                                     WHERE TenDangNhap LIKE @keyword 
                                        OR HoTen LIKE @keyword 
                                        OR Email LIKE @keyword 
                                        OR SoDienThoai LIKE @keyword
                                     ORDER BY MaNguoiDung ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung nd = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                Email = reader["Email"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
                                TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                            list.Add(nd);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm người dùng: " + ex.Message);
            }
            return list;
        }

        // Lấy người dùng theo mã
        public NguoiDung GetByMa(int maNguoiDung)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaNguoiDung, TenDangNhap, MatKhau, HoTen, VaiTro, Email, SoDienThoai, TrangThai, NgayTao FROM nguoidung WHERE MaNguoiDung = @MaNguoiDung";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                Email = reader["Email"]?.ToString() ?? "",
                                SoDienThoai = reader["SoDienThoai"]?.ToString() ?? "",
                                TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin người dùng: " + ex.Message);
            }
            return null;
        }

        // Kiểm tra tên đăng nhập đã tồn tại
        public bool CheckTenDangNhapExists(string tenDangNhap, int? maNguoiDung = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM nguoidung WHERE TenDangNhap = @TenDangNhap";
                    if (maNguoiDung.HasValue)
                    {
                        query += " AND MaNguoiDung != @MaNguoiDung";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    if (maNguoiDung.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiDung", maNguoiDung.Value);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra tên đăng nhập: " + ex.Message);
            }
        }

        public List<NguoiDung> GetNguoiDungRoleBacSi()
        {
            var list = new List<NguoiDung>();

            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MaNguoiDung, TenDangNhap, HoTen, VaiTro, Email, SoDienThoai, TrangThai, NgayTao
                                     FROM nguoidung
                                     WHERE VaiTro = 'BacSi' AND TrangThai = 1
                                     ORDER BY MaNguoiDung ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                Email = reader["Email"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách người dùng vai trò bác sĩ: " + ex.Message);
            }

            return list;
        }
=======
>>>>>>> bf18f79f7e8c99d674adda1632c430a8751d12b9
    }
}
