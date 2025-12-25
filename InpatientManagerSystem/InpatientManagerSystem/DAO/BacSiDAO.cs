using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    public class BacSiDAO
    {
        private readonly DBConnection dbConnection = new DBConnection();

        // Lấy tất cả bác sĩ
        public List<BacSi> GetAll()
        {
            List<BacSi> list = new List<BacSi>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM bacsi ORDER BY MaBacSi ASC";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BacSi bs = new BacSi
                            {
                                Stt = Convert.ToInt32(reader["STT"]),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                Cccd = reader["CCCD"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                ChuyenKhoa = reader["ChuyenKhoa"].ToString()
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

        // Thêm bác sĩ
        public bool Insert(BacSi bs)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        @"INSERT INTO bacsi (MaNguoiDung, HoTen, NgaySinh, GioiTinh, CCCD, DiaChi, KinhNghiem, ChuyenKhoa)
                          VALUES(@MaNguoiDung, @HoTen, @NgaySinh, @GioiTinh, @CCCD, @DiaChi, @KinhNghiem, @ChuyenKhoa)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNguoiDung", bs.MaNguoiDung);
                        cmd.Parameters.AddWithValue("@HoTen", bs.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", bs.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", bs.GioiTinh);
                        cmd.Parameters.AddWithValue("@CCCD", bs.Cccd);
                        cmd.Parameters.AddWithValue("@DiaChi", bs.DiaChi);
                        cmd.Parameters.AddWithValue("@KinhNghiem", bs.KinhNghiem);
                        cmd.Parameters.AddWithValue("@ChuyenKhoa", bs.ChuyenKhoa);

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

        // Cập nhật bác sĩ
        public bool Update(BacSi bs)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        @"UPDATE bacsi 
                          SET MaNguoiDung = @MaNguoiDung,
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
                        cmd.Parameters.AddWithValue("@MaBacSi", bs.MaBacSi);
                        cmd.Parameters.AddWithValue("@MaNguoiDung", bs.MaNguoiDung);
                        cmd.Parameters.AddWithValue("@HoTen", bs.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", bs.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", bs.GioiTinh);
                        cmd.Parameters.AddWithValue("@CCCD", bs.Cccd);
                        cmd.Parameters.AddWithValue("@DiaChi", bs.DiaChi);
                        cmd.Parameters.AddWithValue("@KinhNghiem", bs.KinhNghiem);
                        cmd.Parameters.AddWithValue("@ChuyenKhoa", bs.ChuyenKhoa);

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

        // Tìm kiếm bác sĩ theo keyword
        public List<BacSi> Search(string keyword)
        {
            List<BacSi> list = new List<BacSi>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        @"SELECT * FROM bacsi 
                          WHERE MaBacSi LIKE @keyword
                             OR HoTen LIKE @keyword
                             OR CCCD LIKE @keyword
                             OR ChuyenKhoa LIKE @keyword
                          ORDER BY MaBacSi ASC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BacSi bs = new BacSi
                                {
                                    Stt = Convert.ToInt32(reader["STT"]),
                                    MaBacSi = reader["MaBacSi"].ToString(),
                                    MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                    HoTen = reader["HoTen"].ToString(),
                                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Cccd = reader["CCCD"].ToString(),
                                    DiaChi = reader["DiaChi"].ToString(),
                                    KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                    ChuyenKhoa = reader["ChuyenKhoa"].ToString()
                                };
                                list.Add(bs);
                            }
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
                    string query = "SELECT * FROM bacsi WHERE MaBacSi = @MaBacSi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new BacSi
                                {
                                    Stt = Convert.ToInt32(reader["STT"]),
                                    MaBacSi = reader["MaBacSi"].ToString(),
                                    MaNguoiDung = Convert.ToInt32(reader["MaNguoiDung"]),
                                    HoTen = reader["HoTen"].ToString(),
                                    NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    Cccd = reader["CCCD"].ToString(),
                                    DiaChi = reader["DiaChi"].ToString(),
                                    KinhNghiem = Convert.ToInt32(reader["KinhNghiem"]),
                                    ChuyenKhoa = reader["ChuyenKhoa"].ToString()
                                };
                            }
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

        // Kiểm tra CCCD đã tồn tại (phục vụ insert/update)
        public bool CheckCCCDExists(string cccd, string maBacSi = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM bacsi WHERE CCCD = @CCCD";
                    if (!string.IsNullOrEmpty(maBacSi))
                        query += " AND MaBacSi != @MaBacSi";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CCCD", cccd);

                        if (!string.IsNullOrEmpty(maBacSi))
                            cmd.Parameters.AddWithValue("@MaBacSi", maBacSi);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra CCCD: " + ex.Message);
            }
        }
    }
}
