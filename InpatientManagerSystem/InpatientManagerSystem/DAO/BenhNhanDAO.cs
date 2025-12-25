using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    public class BenhNhanDAO
    {
        private DBConnection dbConnection = new DBConnection();

        // Lấy tất cả bệnh nhân
        public List<BenhNhan> GetAll()
        {
            List<BenhNhan> list = new List<BenhNhan>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM benhnhan ORDER BY MaBenhNhan ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenhNhan bn = new BenhNhan
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                CCCD = reader["CCCD"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                BHYT = reader["BHYT"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                            list.Add(bn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách bệnh nhân: " + ex.Message);
            }
            return list;
        }

        // Thêm bệnh nhân
        public bool Insert(BenhNhan benhNhan)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO benhnhan (CCCD, HoTen, NgaySinh, GioiTinh, SoDienThoai, BHYT, DiaChi) " +
                 "VALUES (@CCCD, @HoTen, @NgaySinh, @GioiTinh, @SoDienThoai, @BHYT, @DiaChi)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CCCD", benhNhan.CCCD);
                        cmd.Parameters.AddWithValue("@HoTen", benhNhan.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", benhNhan.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", benhNhan.GioiTinh);
                        cmd.Parameters.AddWithValue("@SoDienThoai", benhNhan.SoDienThoai);
                        cmd.Parameters.AddWithValue("@BHYT", benhNhan.BHYT);
                        cmd.Parameters.AddWithValue("@DiaChi", benhNhan.DiaChi);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm bệnh nhân: " + ex.Message);
            }
        }

        // Cập nhật bệnh nhân
        public bool Update(BenhNhan benhNhan)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE benhnhan SET CCCD = @CCCD, HoTen = @HoTen, NgaySinh = @NgaySinh, " +
                    "GioiTinh = @GioiTinh, SoDienThoai = @SoDienThoai, BHYT = @BHYT, DiaChi = @DiaChi " +
                    "WHERE MaBenhNhan = @MaBenhNhan";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenhNhan", benhNhan.MaBenhNhan);
                        cmd.Parameters.AddWithValue("@CCCD", benhNhan.CCCD);
                        cmd.Parameters.AddWithValue("@HoTen", benhNhan.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", benhNhan.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", benhNhan.GioiTinh);
                        cmd.Parameters.AddWithValue("@SoDienThoai", benhNhan.SoDienThoai);
                        cmd.Parameters.AddWithValue("@BHYT", benhNhan.BHYT);
                        cmd.Parameters.AddWithValue("@DiaChi", benhNhan.DiaChi);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật bệnh nhân: " + ex.Message);
            }
        }

        // Xóa bệnh nhân
        public bool Delete(string maBenhNhan)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM benhnhan WHERE MaBenhNhan = @MaBenhNhan";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa bệnh nhân: " + ex.Message);
            }
        }

        // Tìm kiếm bệnh nhân theo nhiều tiêu chí
        public List<BenhNhan> Search(string keyword)
        {
            List<BenhNhan> list = new List<BenhNhan>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM benhnhan 
                        WHERE MaBenhNhan LIKE @keyword 
                        OR HoTen LIKE @keyword 
                        OR CCCD LIKE @keyword 
                        OR SoDienThoai LIKE @keyword 
                        OR BHYT LIKE @keyword
                        ORDER BY MaBenhNhan ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenhNhan bn = new BenhNhan
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                CCCD = reader["CCCD"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                BHYT = reader["BHYT"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                            list.Add(bn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm bệnh nhân: " + ex.Message);
            }
            return list;
        }

        // Lấy bệnh nhân theo mã
        public BenhNhan GetByMa(string maBenhNhan)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM benhnhan WHERE MaBenhNhan = @MaBenhNhan";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BenhNhan
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                CCCD = reader["CCCD"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                SoDienThoai = reader["SoDienThoai"].ToString(),
                                BHYT = reader["BHYT"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                                NgayTao = Convert.ToDateTime(reader["NgayTao"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin bệnh nhân: " + ex.Message);
            }
            return null;
        }

        // Kiểm tra CCCD đã tồn tại
        public bool CheckCCCDExists(string cccd, string maBenhNhan = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM benhnhan WHERE CCCD = @CCCD";
                    if (!string.IsNullOrEmpty(maBenhNhan))
                    {
                        query += " AND MaBenhNhan != @MaBenhNhan";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CCCD", cccd);
                    if (!string.IsNullOrEmpty(maBenhNhan))
                    {
                        cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
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

        // Kiểm tra số điện thoại đã tồn tại
        public bool CheckPhoneExists(string soDienThoai, string maBenhNhan = null)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM benhnhan WHERE SoDienThoai = @SoDienThoai";
                    if (!string.IsNullOrEmpty(maBenhNhan))
                    {
                        query += " AND MaBenhNhan != @MaBenhNhan";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                    if (!string.IsNullOrEmpty(maBenhNhan))
                    {
                        cmd.Parameters.AddWithValue("@MaBenhNhan", maBenhNhan);
                    }

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra số điện thoại: " + ex.Message);
            }
        }
    }
}
