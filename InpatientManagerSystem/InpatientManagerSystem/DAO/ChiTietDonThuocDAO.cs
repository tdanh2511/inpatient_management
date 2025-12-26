using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    internal class ChiTietDonThuocDAO
    {
        private DBConnection db = new DBConnection();

        public List<ChiTietDonThuocDTO> GetAll()
        {
            List<ChiTietDonThuocDTO> list = new List<ChiTietDonThuocDTO>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM ChiTietDonThuoc ORDER BY maChiTietDonThuoc ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietDonThuocDTO chiTiet = new ChiTietDonThuocDTO
                            {
                                maChiTietDonThuoc = reader["maChiTietDonThuoc"].ToString(),
                                maDonThuoc = reader["maDonThuoc"].ToString(),
                                maThuoc = reader["maThuoc"].ToString(),
                                soLuong = Convert.ToInt32(reader["soLuong"]),
                                lieuLuong = reader["lieuLuong"]?.ToString() ?? "",
                                ghiChu = reader["ghiChu"]?.ToString() ?? ""
                            };
                            list.Add(chiTiet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách chi tiết đơn thuốc: " + ex.Message);
            }
            return list;
        }

        public List<ChiTietDonThuocDTO> GetByMaDonThuoc(string maDonThuoc)
        {
            List<ChiTietDonThuocDTO> list = new List<ChiTietDonThuocDTO>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM ChiTietDonThuoc WHERE maDonThuoc = @maDonThuoc ORDER BY maChiTietDonThuoc ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maDonThuoc", maDonThuoc);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChiTietDonThuocDTO chiTiet = new ChiTietDonThuocDTO
                            {
                                maChiTietDonThuoc = reader["maChiTietDonThuoc"].ToString(),
                                maDonThuoc = reader["maDonThuoc"].ToString(),
                                maThuoc = reader["maThuoc"].ToString(),
                                soLuong = Convert.ToInt32(reader["soLuong"]),
                                lieuLuong = reader["lieuLuong"]?.ToString() ?? "",
                                ghiChu = reader["ghiChu"]?.ToString() ?? ""
                            };
                            list.Add(chiTiet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết đơn thuốc theo mã đơn: " + ex.Message);
            }
            return list;
        }

        public ChiTietDonThuocDTO GetByMa(string maChiTietDonThuoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM ChiTietDonThuoc WHERE maChiTietDonThuoc = @maChiTietDonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maChiTietDonThuoc", maChiTietDonThuoc);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ChiTietDonThuocDTO
                            {
                                maChiTietDonThuoc = reader["maChiTietDonThuoc"].ToString(),
                                maDonThuoc = reader["maDonThuoc"].ToString(),
                                maThuoc = reader["maThuoc"].ToString(),
                                soLuong = Convert.ToInt32(reader["soLuong"]),
                                lieuLuong = reader["lieuLuong"]?.ToString() ?? "",
                                ghiChu = reader["ghiChu"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy chi tiết đơn thuốc: " + ex.Message);
            }
            return null;
        }

        public bool Insert(ChiTietDonThuocDTO chiTiet)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO ChiTietDonThuoc (maDonThuoc, maThuoc, soLuong, lieuLuong, ghiChu) 
                                     VALUES (@maDonThuoc, @maThuoc, @soLuong, @lieuLuong, @ghiChu)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maDonThuoc", chiTiet.maDonThuoc);
                    cmd.Parameters.AddWithValue("@maThuoc", chiTiet.maThuoc);
                    cmd.Parameters.AddWithValue("@soLuong", chiTiet.soLuong);
                    cmd.Parameters.AddWithValue("@lieuLuong", chiTiet.lieuLuong ?? "");
                    cmd.Parameters.AddWithValue("@ghiChu", chiTiet.ghiChu ?? "");
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm chi tiết đơn thuốc: " + ex.Message);
            }
        }

        public bool Update(ChiTietDonThuocDTO chiTiet)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE ChiTietDonThuoc 
                                     SET maDonThuoc = @maDonThuoc, maThuoc = @maThuoc, soLuong = @soLuong, 
                                         lieuLuong = @lieuLuong, ghiChu = @ghiChu 
                                     WHERE maChiTietDonThuoc = @maChiTietDonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maChiTietDonThuoc", chiTiet.maChiTietDonThuoc);
                    cmd.Parameters.AddWithValue("@maDonThuoc", chiTiet.maDonThuoc);
                    cmd.Parameters.AddWithValue("@maThuoc", chiTiet.maThuoc);
                    cmd.Parameters.AddWithValue("@soLuong", chiTiet.soLuong);
                    cmd.Parameters.AddWithValue("@lieuLuong", chiTiet.lieuLuong ?? "");
                    cmd.Parameters.AddWithValue("@ghiChu", chiTiet.ghiChu ?? "");
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật chi tiết đơn thuốc: " + ex.Message);
            }
        }

        public bool Delete(string maChiTietDonThuoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM ChiTietDonThuoc WHERE maChiTietDonThuoc = @maChiTietDonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maChiTietDonThuoc", maChiTietDonThuoc);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa chi tiết đơn thuốc: " + ex.Message);
            }
        }

        public bool DeleteByMaDonThuoc(string maDonThuoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM ChiTietDonThuoc WHERE maDonThuoc = @maDonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maDonThuoc", maDonThuoc);
                    int result = cmd.ExecuteNonQuery();
                    return result >= 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa chi tiết đơn thuốc theo mã đơn: " + ex.Message);
            }
        }
    }
}
