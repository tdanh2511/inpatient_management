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
                    string query = "SELECT * FROM nguoidung ORDER BY MaND ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NguoiDung nd = new NguoiDung
                            {
                                MaNguoiDung = Convert.ToInt32(reader["MaND"]),
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                Email = reader["Email"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
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

        // Hàm thêm người dùng
        public bool Insert(NguoiDung nguoiDung)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, VaiTro, Email, SoDienThoai, TrangThai, NgayTao) " +
                                   "VALUES (@TenDangNhap, @MatKhau, @HoTen, @VaiTro, @Email, @SoDienThoai, @TrangThai, @NgayTao)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", nguoiDung.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", nguoiDung.MatKhau);
                        cmd.Parameters.AddWithValue("@HoTen", nguoiDung.HoTen);
                        cmd.Parameters.AddWithValue("@VaiTro", nguoiDung.VaiTro);
                        cmd.Parameters.AddWithValue("@Email", nguoiDung.Email);
                        cmd.Parameters.AddWithValue("@SoDienThoai", nguoiDung.SoDienThoai);
                        cmd.Parameters.AddWithValue("@TrangThai", nguoiDung.TrangThai ? 1 : 0);
                        cmd.Parameters.AddWithValue("@NgayTao", nguoiDung.NgayTao);
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
    }
}
