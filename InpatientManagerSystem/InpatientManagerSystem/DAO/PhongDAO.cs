using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;

namespace InpatientManagerSystem.DAO
{
    public class PhongDAO
    {
        private DBConnection dbConnection = new DBConnection();

        // Lấy tất cả phòng
        public List<Phong> GetAll()
        {
            List<Phong> list = new List<Phong>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT STT, MaPhong, TenPhong, LoaiPhong FROM phong ORDER BY MaPhong ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Phong p = new Phong
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaPhong = reader["MaPhong"].ToString(),
                                TenPhong = reader["TenPhong"].ToString(),
                                LoaiPhong = reader["LoaiPhong"].ToString()
                            };
                            list.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách phòng: " + ex.Message);
            }
            return list;
        }

        // Thêm phòng
        public bool Insert(Phong phong)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO phong (TenPhong, LoaiPhong) VALUES (@TenPhong, @LoaiPhong)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
                        cmd.Parameters.AddWithValue("@LoaiPhong", phong.LoaiPhong);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm phòng: " + ex.Message);
            }
        }

        // Cập nhật phòng
        public bool Update(Phong phong)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE phong SET TenPhong = @TenPhong, LoaiPhong = @LoaiPhong WHERE MaPhong = @MaPhong";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", phong.MaPhong);
                        cmd.Parameters.AddWithValue("@TenPhong", phong.TenPhong);
                        cmd.Parameters.AddWithValue("@LoaiPhong", phong.LoaiPhong);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật phòng: " + ex.Message);
            }
        }

        // Xóa phòng
        public bool Delete(string maPhong)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM phong WHERE MaPhong = @MaPhong";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa phòng: " + ex.Message);
            }
        }

        // Tìm kiếm phòng
        public List<Phong> Search(string keyword)
        {
            List<Phong> list = new List<Phong>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT STT, MaPhong, TenPhong, LoaiPhong 
                        FROM phong 
                        WHERE MaPhong LIKE @keyword 
                        OR TenPhong LIKE @keyword 
                        OR LoaiPhong LIKE @keyword
                        ORDER BY MaPhong ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Phong p = new Phong
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaPhong = reader["MaPhong"].ToString(),
                                TenPhong = reader["TenPhong"].ToString(),
                                LoaiPhong = reader["LoaiPhong"].ToString()
                            };
                            list.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm phòng: " + ex.Message);
            }
            return list;
        }

        // Lấy phòng theo mã
        public Phong GetByMa(string maPhong)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT STT, MaPhong, TenPhong, LoaiPhong FROM phong WHERE MaPhong = @MaPhong";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Phong
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaPhong = reader["MaPhong"].ToString(),
                                TenPhong = reader["TenPhong"].ToString(),
                                LoaiPhong = reader["LoaiPhong"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin phòng: " + ex.Message);
            }
            return null;
        }

        // Kiểm tra tên phòng đã tồn tại
        public bool CheckTenPhongExists(string tenPhong, string maPhong = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM phong WHERE TenPhong = @TenPhong";
                    if (!string.IsNullOrEmpty(maPhong))
                    {
                        query += " AND MaPhong != @MaPhong";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                    if (!string.IsNullOrEmpty(maPhong))
                    {
                        cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra tên phòng: " + ex.Message);
            }
        }
    }
}
