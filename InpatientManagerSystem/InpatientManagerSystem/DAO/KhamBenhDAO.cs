using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    public class KhamBenhDAO
    {
        private DBConnection dbConnection = new DBConnection();

        // Lấy tất cả khám bệnh
        public List<KhamBenh> GetAll()
        {
            List<KhamBenh> list = new List<KhamBenh>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT kb.STT, kb.MaKhamBenh, kb.MaHoSo, kb.MaBenhNhan, kb.MaBacSi, 
            kb.NgayKham, kb.ChuanDoan,
            bn.HoTen as TenBenhNhan,
       bs.HoTen as TenBacSi
        FROM khambenh kb
                  LEFT JOIN benhnhan bn ON kb.MaBenhNhan = bn.MaBenhNhan
          LEFT JOIN bacsi bs ON kb.MaBacSi = bs.MaBacSi
     ORDER BY kb.STT DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhamBenh kb = new KhamBenh
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaKhamBenh = reader["MaKhamBenh"].ToString(),
                                MaHoSo = reader["MaHoSo"]?.ToString() ?? "",
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                                ChuanDoan = reader["ChuanDoan"].ToString(),
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? ""
                            };
                            list.Add(kb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách khám bệnh: " + ex.Message);
            }
            return list;
        }

        // Thêm khám bệnh mới
        public bool Insert(KhamBenh khamBenh)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // MaKhamBenh tự động sinh bởi trigger
                    string query = @"INSERT INTO khambenh (MaKhamBenh, MaHoSo, MaBenhNhan, MaBacSi, NgayKham, ChuanDoan) 
 VALUES ('', @MaHoSo, @MaBenhNhan, @MaBacSi, @NgayKham, @ChuanDoan)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoSo", string.IsNullOrEmpty(khamBenh.MaHoSo) ? (object)DBNull.Value : khamBenh.MaHoSo);
                        cmd.Parameters.AddWithValue("@MaBenhNhan", khamBenh.MaBenhNhan);
                        cmd.Parameters.AddWithValue("@MaBacSi", khamBenh.MaBacSi);
                        cmd.Parameters.AddWithValue("@NgayKham", khamBenh.NgayKham);
                        cmd.Parameters.AddWithValue("@ChuanDoan", khamBenh.ChuanDoan);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm khám bệnh: " + ex.Message);
            }
        }

        // Cập nhật khám bệnh
        public bool Update(KhamBenh khamBenh)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE khambenh SET 
               MaHoSo = @MaHoSo, 
            MaBenhNhan = @MaBenhNhan, 
      MaBacSi = @MaBacSi, 
          NgayKham = @NgayKham, 
            ChuanDoan = @ChuanDoan 
      WHERE MaKhamBenh = @MaKhamBenh";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhamBenh", khamBenh.MaKhamBenh);
                        cmd.Parameters.AddWithValue("@MaHoSo", string.IsNullOrEmpty(khamBenh.MaHoSo) ? (object)DBNull.Value : khamBenh.MaHoSo);
                        cmd.Parameters.AddWithValue("@MaBenhNhan", khamBenh.MaBenhNhan);
                        cmd.Parameters.AddWithValue("@MaBacSi", khamBenh.MaBacSi);
                        cmd.Parameters.AddWithValue("@NgayKham", khamBenh.NgayKham);
                        cmd.Parameters.AddWithValue("@ChuanDoan", khamBenh.ChuanDoan);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật khám bệnh: " + ex.Message);
            }
        }

        // Xóa khám bệnh
        public bool Delete(string maKhamBenh)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM khambenh WHERE MaKhamBenh = @MaKhamBenh";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhamBenh", maKhamBenh);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa khám bệnh: " + ex.Message);
            }
        }

        // Tìm kiếm khám bệnh
        public List<KhamBenh> Search(string keyword)
        {
            List<KhamBenh> list = new List<KhamBenh>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT kb.STT, kb.MaKhamBenh, kb.MaHoSo, kb.MaBenhNhan, kb.MaBacSi, 
    kb.NgayKham, kb.ChuanDoan,
          bn.HoTen as TenBenhNhan,
 bs.HoTen as TenBacSi
   FROM khambenh kb
LEFT JOIN benhnhan bn ON kb.MaBenhNhan = bn.MaBenhNhan
LEFT JOIN bacsi bs ON kb.MaBacSi = bs.MaBacSi
        WHERE kb.MaKhamBenh LIKE @keyword 
         OR kb.MaHoSo LIKE @keyword
   OR bn.HoTen LIKE @keyword
OR bs.HoTen LIKE @keyword
           OR kb.ChuanDoan LIKE @keyword
   ORDER BY kb.STT DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhamBenh kb = new KhamBenh
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaKhamBenh = reader["MaKhamBenh"].ToString(),
                                MaHoSo = reader["MaHoSo"]?.ToString() ?? "",
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                                ChuanDoan = reader["ChuanDoan"].ToString(),
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? ""
                            };
                            list.Add(kb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm khám bệnh: " + ex.Message);
            }
            return list;
        }

        // Lấy khám bệnh theo mã
        public KhamBenh GetByMa(string maKhamBenh)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT kb.STT, kb.MaKhamBenh, kb.MaHoSo, kb.MaBenhNhan, kb.MaBacSi, 
      kb.NgayKham, kb.ChuanDoan,
                bn.HoTen as TenBenhNhan,
        bs.HoTen as TenBacSi
        FROM khambenh kb
    LEFT JOIN benhnhan bn ON kb.MaBenhNhan = bn.MaBenhNhan
          LEFT JOIN bacsi bs ON kb.MaBacSi = bs.MaBacSi
   WHERE kb.MaKhamBenh = @MaKhamBenh";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKhamBenh", maKhamBenh);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhamBenh
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaKhamBenh = reader["MaKhamBenh"].ToString(),
                                MaHoSo = reader["MaHoSo"]?.ToString() ?? "",
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                MaBacSi = reader["MaBacSi"].ToString(),
                                NgayKham = Convert.ToDateTime(reader["NgayKham"]),
                                ChuanDoan = reader["ChuanDoan"].ToString(),
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin khám bệnh: " + ex.Message);
            }
            return null;
        }

        // Lấy danh sách bác sĩ
        public List<BacSi> GetAllBacSi()
        {
            List<BacSi> list = new List<BacSi>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaBacSi, HoTen FROM bacsi ORDER BY MaBacSi ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BacSi bs = new BacSi
                            {
                                MaBacSi = reader["MaBacSi"].ToString(),
                                HoTen = reader["HoTen"].ToString()
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

        // Lấy danh sách bệnh nhân
        public List<BenhNhan> GetAllBenhNhan()
        {
            List<BenhNhan> list = new List<BenhNhan>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaBenhNhan, HoTen FROM benhnhan ORDER BY MaBenhNhan DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BenhNhan bn = new BenhNhan
                            {
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                HoTen = reader["HoTen"].ToString()
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

        // Lấy danh sách hồ sơ CHƯA được khám bệnh
        public List<HoSo> GetHoSoChuaDung()
        {
            List<HoSo> list = new List<HoSo>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // Chỉ lấy hồ sơ chưa có trong bảng khambenh
                    string query = @"SELECT hs.MaHoSo, hs.MaBenhNhan, hs.MaBacSi, hs.TrangThai,
     bn.HoTen as TenBenhNhan,
   bs.HoTen as TenBacSi
         FROM hoso hs
     LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
   LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
WHERE hs.MaHoSo NOT IN (SELECT DISTINCT MaHoSo FROM khambenh WHERE MaHoSo IS NOT NULL)
     ORDER BY hs.STT DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoSo hs = new HoSo
                            {
                                MaHoSo = reader["MaHoSo"].ToString(),
                                MaBenhNhan = reader["MaBenhNhan"]?.ToString() ?? "",
                                MaBacSi = reader["MaBacSi"]?.ToString() ?? "",
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? "",
                                TrangThai = reader["TrangThai"].ToString()
                            };
                            list.Add(hs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hồ sơ chưa dùng: " + ex.Message);
            }
            return list;
        }

        // Lấy danh sách hồ sơ (bao gồm hồ sơ đang được chọn khi sửa)
        public List<HoSo> GetAllHoSo(string maHoSoDangChon = null)
        {
            List<HoSo> list = new List<HoSo>();
   try
    {
     using (MySqlConnection conn = dbConnection.GetConnection())
       {
     conn.Open();
      string query;
       
        if (string.IsNullOrEmpty(maHoSoDangChon))
     {
            // Khi THÊM MỚI: Chỉ lấy hồ sơ chưa dùng
   query = @"SELECT hs.MaHoSo, hs.MaBenhNhan, hs.MaBacSi, hs.TrangThai,
       bn.HoTen as TenBenhNhan,
         bs.HoTen as TenBacSi
          FROM hoso hs
    LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
       LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
  WHERE hs.MaHoSo NOT IN (SELECT DISTINCT MaHoSo FROM khambenh WHERE MaHoSo IS NOT NULL)
     ORDER BY hs.STT DESC";
   }
        else
     {
        // Khi SỬA: Lấy hồ sơ chưa dùng HOẶC hồ sơ đang được chọn
      query = @"SELECT hs.MaHoSo, hs.MaBenhNhan, hs.MaBacSi, hs.TrangThai,
       bn.HoTen as TenBenhNhan,
    bs.HoTen as TenBacSi
      FROM hoso hs
     LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
    LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
  WHERE hs.MaHoSo NOT IN (SELECT DISTINCT MaHoSo FROM khambenh WHERE MaHoSo IS NOT NULL)
      OR hs.MaHoSo = @MaHoSoDangChon
      ORDER BY hs.STT DESC";
          }

   MySqlCommand cmd = new MySqlCommand(query, conn);
         
     if (!string.IsNullOrEmpty(maHoSoDangChon))
       {
   cmd.Parameters.AddWithValue("@MaHoSoDangChon", maHoSoDangChon);
   }

 using (MySqlDataReader reader = cmd.ExecuteReader())
     {
     while (reader.Read())
    {
    HoSo hs = new HoSo
     {
     MaHoSo = reader["MaHoSo"].ToString(),
        MaBenhNhan = reader["MaBenhNhan"]?.ToString() ?? "",
         MaBacSi = reader["MaBacSi"]?.ToString() ?? "",
        TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
      TenBacSi = reader["TenBacSi"]?.ToString() ?? "",
     TrangThai = reader["TrangThai"].ToString()
    };
      list.Add(hs);
      }
   }
   }
 }
       catch (Exception ex)
     {
     throw new Exception("Lỗi lấy danh sách hồ sơ: " + ex.Message);
}
 return list;
        }
 }
}
