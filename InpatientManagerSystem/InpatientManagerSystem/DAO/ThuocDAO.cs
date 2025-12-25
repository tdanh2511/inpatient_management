using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    internal class ThuocDAO
    {
        private DBConnection dbConnection = new DBConnection();

        public List<ThuocDTO> GetAll()
        {
            List<ThuocDTO> list = new List<ThuocDTO>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT STT, MaThuoc, TenThuoc, DonViTinh, DonGia, SoLuongTon, HangSanXuat, CongDung, NgayHetHan, TrangThai FROM thuoc ORDER BY MaThuoc ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThuocDTO thuoc = new ThuocDTO
                            {
                                maThuoc = reader["MaThuoc"].ToString(),
                                tenThuoc = reader["TenThuoc"].ToString(),
                                donViTinh = reader["DonViTinh"].ToString(),
                                donGia = Convert.ToDecimal(reader["DonGia"]),
                                soLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                hangSanXuat = reader["HangSanXuat"]?.ToString() ?? "",
                                congDung = reader["CongDung"]?.ToString() ?? "",
                                ngayHetHan = reader["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(reader["NgayHetHan"]) : DateTime.MinValue,
                                trangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                            list.Add(thuoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách thuốc: " + ex.Message);
            }
            return list;
        }

        public bool Insert(ThuocDTO thuoc)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO thuoc (TenThuoc, DonViTinh, DonGia, SoLuongTon, HangSanXuat, CongDung, NgayHetHan, TrangThai) " +
                                   "VALUES (@TenThuoc, @DonViTinh, @DonGia, @SoLuongTon, @HangSanXuat, @CongDung, @NgayHetHan, @TrangThai)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenThuoc", thuoc.tenThuoc);
                        cmd.Parameters.AddWithValue("@DonViTinh", thuoc.donViTinh);
                        cmd.Parameters.AddWithValue("@DonGia", thuoc.donGia);
                        cmd.Parameters.AddWithValue("@SoLuongTon", thuoc.soLuongTon);
                        cmd.Parameters.AddWithValue("@HangSanXuat", thuoc.hangSanXuat ?? "");
                        cmd.Parameters.AddWithValue("@CongDung", thuoc.congDung ?? "");
                        cmd.Parameters.AddWithValue("@NgayHetHan", thuoc.ngayHetHan != DateTime.MinValue ? (object)thuoc.ngayHetHan : DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", thuoc.trangThai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm thuốc: " + ex.Message);
            }
        }

        public bool Update(ThuocDTO thuoc)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE thuoc SET TenThuoc = @TenThuoc, DonViTinh = @DonViTinh, DonGia = @DonGia, " +
                                   "SoLuongTon = @SoLuongTon, HangSanXuat = @HangSanXuat, CongDung = @CongDung, " +
                                   "NgayHetHan = @NgayHetHan, TrangThai = @TrangThai " +
                                   "WHERE MaThuoc = @MaThuoc";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThuoc", thuoc.maThuoc);
                        cmd.Parameters.AddWithValue("@TenThuoc", thuoc.tenThuoc);
                        cmd.Parameters.AddWithValue("@DonViTinh", thuoc.donViTinh);
                        cmd.Parameters.AddWithValue("@DonGia", thuoc.donGia);
                        cmd.Parameters.AddWithValue("@SoLuongTon", thuoc.soLuongTon);
                        cmd.Parameters.AddWithValue("@HangSanXuat", thuoc.hangSanXuat ?? "");
                        cmd.Parameters.AddWithValue("@CongDung", thuoc.congDung ?? "");
                        cmd.Parameters.AddWithValue("@NgayHetHan", thuoc.ngayHetHan != DateTime.MinValue ? (object)thuoc.ngayHetHan : DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", thuoc.trangThai ? 1 : 0);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật thuốc: " + ex.Message);
            }
        }

        public bool Delete(string maThuoc)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM thuoc WHERE MaThuoc = @MaThuoc";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa thuốc: " + ex.Message);
            }
        }

        public List<ThuocDTO> Search(string keyword)
        {
            List<ThuocDTO> list = new List<ThuocDTO>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT STT, MaThuoc, TenThuoc, DonViTinh, DonGia, SoLuongTon, HangSanXuat, CongDung, NgayHetHan, TrangThai 
                                     FROM thuoc 
                                     WHERE MaThuoc LIKE @keyword 
                                     OR TenThuoc LIKE @keyword 
                                     OR HangSanXuat LIKE @keyword 
                                     OR CongDung LIKE @keyword
                                     ORDER BY MaThuoc ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThuocDTO thuoc = new ThuocDTO
                            {
                                maThuoc = reader["MaThuoc"].ToString(),
                                tenThuoc = reader["TenThuoc"].ToString(),
                                donViTinh = reader["DonViTinh"].ToString(),
                                donGia = Convert.ToDecimal(reader["DonGia"]),
                                soLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                hangSanXuat = reader["HangSanXuat"]?.ToString() ?? "",
                                congDung = reader["CongDung"]?.ToString() ?? "",
                                ngayHetHan = reader["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(reader["NgayHetHan"]) : DateTime.MinValue,
                                trangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                            list.Add(thuoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm thuốc: " + ex.Message);
            }
            return list;
        }

        public ThuocDTO GetByMa(string maThuoc)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT STT, MaThuoc, TenThuoc, DonViTinh, DonGia, SoLuongTon, HangSanXuat, CongDung, NgayHetHan, TrangThai FROM thuoc WHERE MaThuoc = @MaThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ThuocDTO
                            {
                                maThuoc = reader["MaThuoc"].ToString(),
                                tenThuoc = reader["TenThuoc"].ToString(),
                                donViTinh = reader["DonViTinh"].ToString(),
                                donGia = Convert.ToDecimal(reader["DonGia"]),
                                soLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                hangSanXuat = reader["HangSanXuat"]?.ToString() ?? "",
                                congDung = reader["CongDung"]?.ToString() ?? "",
                                ngayHetHan = reader["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(reader["NgayHetHan"]) : DateTime.MinValue,
                                trangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin thuốc: " + ex.Message);
            }
            return null;
        }

        public List<ThuocDTO> GetMedicinesByExpiry(DateTime? from = null, DateTime? to = null)
        {
            List<ThuocDTO> list = new List<ThuocDTO>();
            using (MySqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT STT, MaThuoc, TenThuoc, DonViTinh, DonGia, SoLuongTon, HangSanXuat, CongDung, NgayHetHan, TrangThai 
                         FROM thuoc 
                         WHERE NgayHetHan IS NOT NULL";
                if (from.HasValue) query += " AND NgayHetHan >= @from";
                if (to.HasValue) query += " AND NgayHetHan <= @to";
                query += " ORDER BY NgayHetHan ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (from.HasValue) cmd.Parameters.AddWithValue("@from", from.Value.Date);
                    if (to.HasValue) cmd.Parameters.AddWithValue("@to", to.Value.Date);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ThuocDTO
                            {
                                maThuoc = reader["MaThuoc"].ToString(),
                                tenThuoc = reader["TenThuoc"].ToString(),
                                donViTinh = reader["DonViTinh"].ToString(),
                                donGia = Convert.ToDecimal(reader["DonGia"]),
                                soLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                hangSanXuat = reader["HangSanXuat"]?.ToString() ?? "",
                                congDung = reader["CongDung"]?.ToString() ?? "",
                                ngayHetHan = Convert.ToDateTime(reader["NgayHetHan"]),
                                trangThai = Convert.ToBoolean(reader["TrangThai"])
                            });
                        }
                    }
                }
            }
            return list;
        }


        public bool CheckMedicineExpired(string maThuoc)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT NgayHetHan FROM thuoc WHERE MaThuoc = @MaThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        DateTime ngayHetHan = Convert.ToDateTime(result);
                        return ngayHetHan < DateTime.Now.Date;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra hạn sử dụng thuốc: " + ex.Message);
            }
        }

        public List<ThuocDTO> GetLowStockMedicines(int threshold)
        {
            List<ThuocDTO> list = new List<ThuocDTO>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT STT, MaThuoc, TenThuoc, DonViTinh, DonGia, SoLuongTon, HangSanXuat, CongDung, NgayHetHan, TrangThai 
                                     FROM thuoc 
                                     WHERE SoLuongTon <= @threshold AND TrangThai = 1
                                     ORDER BY SoLuongTon ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@threshold", threshold);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ThuocDTO thuoc = new ThuocDTO
                            {
                                maThuoc = reader["MaThuoc"].ToString(),
                                tenThuoc = reader["TenThuoc"].ToString(),
                                donViTinh = reader["DonViTinh"].ToString(),
                                donGia = Convert.ToDecimal(reader["DonGia"]),
                                soLuongTon = Convert.ToInt32(reader["SoLuongTon"]),
                                hangSanXuat = reader["HangSanXuat"]?.ToString() ?? "",
                                congDung = reader["CongDung"]?.ToString() ?? "",
                                ngayHetHan = reader["NgayHetHan"] != DBNull.Value ? Convert.ToDateTime(reader["NgayHetHan"]) : DateTime.MinValue,
                                trangThai = Convert.ToBoolean(reader["TrangThai"])
                            };
                            list.Add(thuoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách thuốc sắp hết: " + ex.Message);
            }
            return list;
        }

        public bool UpdateStock(string maThuoc, int soLuongThayDoi)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE thuoc SET SoLuongTon = SoLuongTon + @soLuongThayDoi WHERE MaThuoc = @MaThuoc";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaThuoc", maThuoc);
                        cmd.Parameters.AddWithValue("@soLuongThayDoi", soLuongThayDoi);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật tồn kho thuốc: " + ex.Message);
            }
        }
    }
}
