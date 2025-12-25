using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;

namespace InpatientManagerSystem.DAO
{
    public class DichVuDAO
    {
        private DBConnection dbConnection = new DBConnection();

        // Lấy tất cả dịch vụ
        public List<DichVu> GetAll()
        {
            List<DichVu> list = new List<DichVu>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaDichVu, TenDichVu, LoaiDichVu, DonGia, DonViTinh, MoTa, TrangThai FROM dichvu ORDER BY MaDichVu ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DichVu dv = new DichVu
                            {
                                MaDichVu = reader["MaDichVu"].ToString(),
                                TenDichVu = reader["TenDichVu"].ToString(),
                                LoaiDichVu = reader["LoaiDichVu"].ToString(),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                DonViTinh = reader["DonViTinh"]?.ToString() ?? "",
                                MoTa = reader["MoTa"]?.ToString() ?? "",
                                TrangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                            list.Add(dv);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách dịch vụ: " + ex.Message);
            }
            return list;
        }

        // Thêm dịch vụ
        public bool Insert(DichVu dichVu)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO dichvu (MaDichVu, TenDichVu, LoaiDichVu, DonGia, DonViTinh, MoTa, TrangThai) " +
                "VALUES (@MaDichVu, @TenDichVu, @LoaiDichVu, @DonGia, @DonViTinh, @MoTa, @TrangThai)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDichVu", dichVu.MaDichVu);
                        cmd.Parameters.AddWithValue("@TenDichVu", dichVu.TenDichVu);
                        cmd.Parameters.AddWithValue("@LoaiDichVu", dichVu.LoaiDichVu);
                        cmd.Parameters.AddWithValue("@DonGia", dichVu.DonGia);
                        cmd.Parameters.AddWithValue("@DonViTinh", dichVu.DonViTinh);
                        cmd.Parameters.AddWithValue("@MoTa", dichVu.MoTa);
                        cmd.Parameters.AddWithValue("@TrangThai", dichVu.TrangThai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm dịch vụ: " + ex.Message);
            }
        }

        // Cập nhật dịch vụ
        public bool Update(DichVu dichVu)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE dichvu SET TenDichVu = @TenDichVu, LoaiDichVu = @LoaiDichVu, " +
              "DonGia = @DonGia, DonViTinh = @DonViTinh, MoTa = @MoTa, TrangThai = @TrangThai " +
                            "WHERE MaDichVu = @MaDichVu";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDichVu", dichVu.MaDichVu);
                        cmd.Parameters.AddWithValue("@TenDichVu", dichVu.TenDichVu);
                        cmd.Parameters.AddWithValue("@LoaiDichVu", dichVu.LoaiDichVu);
                        cmd.Parameters.AddWithValue("@DonGia", dichVu.DonGia);
                        cmd.Parameters.AddWithValue("@DonViTinh", dichVu.DonViTinh);
                        cmd.Parameters.AddWithValue("@MoTa", dichVu.MoTa);
                        cmd.Parameters.AddWithValue("@TrangThai", dichVu.TrangThai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật dịch vụ: " + ex.Message);
            }
        }

        // Xóa dịch vụ
        public bool Delete(string maDichVu)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM dichvu WHERE MaDichVu = @MaDichVu";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa dịch vụ: " + ex.Message);
            }
        }

        // Tìm kiếm dịch vụ
        public List<DichVu> Search(string keyword)
        {
            List<DichVu> list = new List<DichVu>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MaDichVu, TenDichVu, LoaiDichVu, DonGia, DonViTinh, MoTa, TrangThai 
          FROM dichvu 
              WHERE MaDichVu LIKE @keyword 
          OR TenDichVu LIKE @keyword 
        OR LoaiDichVu LIKE @keyword
             ORDER BY MaDichVu ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DichVu dv = new DichVu
                            {
                                MaDichVu = reader["MaDichVu"].ToString(),
                                TenDichVu = reader["TenDichVu"].ToString(),
                                LoaiDichVu = reader["LoaiDichVu"].ToString(),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                DonViTinh = reader["DonViTinh"]?.ToString() ?? "",
                                MoTa = reader["MoTa"]?.ToString() ?? "",
                                TrangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                            list.Add(dv);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm dịch vụ: " + ex.Message);
            }
            return list;
        }

        // Lấy dịch vụ theo mã
        public DichVu GetByMa(string maDichVu)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaDichVu, TenDichVu, LoaiDichVu, DonGia, DonViTinh, MoTa, TrangThai FROM dichvu WHERE MaDichVu = @MaDichVu";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DichVu
                            {
                                MaDichVu = reader["MaDichVu"].ToString(),
                                TenDichVu = reader["TenDichVu"].ToString(),
                                LoaiDichVu = reader["LoaiDichVu"].ToString(),
                                DonGia = Convert.ToDecimal(reader["DonGia"]),
                                DonViTinh = reader["DonViTinh"]?.ToString() ?? "",
                                MoTa = reader["MoTa"]?.ToString() ?? "",
                                TrangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin dịch vụ: " + ex.Message);
            }
            return null;
        }

        // Kiểm tra mã dịch vụ đã tồn tại
        public bool CheckMaDichVuExists(string maDichVu)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM dichvu WHERE MaDichVu = @MaDichVu";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDichVu", maDichVu);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra mã dịch vụ: " + ex.Message);
            }
        }

        // Lấy mã dịch vụ tiếp theo
        public string GetNextMaDichVu()
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaDichVu FROM dichvu ORDER BY MaDichVu DESC LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string lastMa = result.ToString();
                        // Lấy số từ mã (DV001 -> 001)
                        string numberPart = lastMa.Substring(2);
                        int nextNumber = int.Parse(numberPart) + 1;
                        return "DV" + nextNumber.ToString("D3");
                    }
                    else
                    {
                        return "DV001";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy mã dịch vụ tiếp theo: " + ex.Message);
            }
        }
    }
}
