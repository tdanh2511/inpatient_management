using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    public class HoSoDAO
    {
        private DBConnection dbConnection = new DBConnection();

        // Lấy tất cả hồ sơ
        public List<HoSo> GetAll()
        {
            List<HoSo> list = new List<HoSo>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT hs.STT, hs.MaHoSo, hs.MaBacSi, hs.MaBenhNhan, 
     hs.NgayNhapVien, hs.LyDo, hs.TrangThai,
           bn.HoTen as TenBenhNhan,
    bs.HoTen as TenBacSi
  FROM hoso hs
       LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
         LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
   ORDER BY hs.STT DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoSo hs = new HoSo
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaHoSo = reader["MaHoSo"].ToString(),
                                MaBacSi = reader["MaBacSi"]?.ToString() ?? "",
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                NgayNhapVien = Convert.ToDateTime(reader["NgayNhapVien"]),
                                LyDo = reader["LyDo"]?.ToString() ?? "",
                                TrangThai = reader["TrangThai"].ToString(),
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? ""
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

        // Thêm hồ sơ mới
        public bool Insert(HoSo hoSo)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // MaHoSo tự động sinh bởi trigger
                    string query = @"INSERT INTO hoso (MaHoSo, MaBacSi, MaBenhNhan, NgayNhapVien, LyDo, TrangThai) 
   VALUES ('', @MaBacSi, @MaBenhNhan, @NgayNhapVien, @LyDo, @TrangThai)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBacSi", string.IsNullOrEmpty(hoSo.MaBacSi) ? (object)DBNull.Value : hoSo.MaBacSi);
                        cmd.Parameters.AddWithValue("@MaBenhNhan", hoSo.MaBenhNhan);
                        cmd.Parameters.AddWithValue("@NgayNhapVien", hoSo.NgayNhapVien);
                        cmd.Parameters.AddWithValue("@LyDo", hoSo.LyDo ?? "");
                        cmd.Parameters.AddWithValue("@TrangThai", hoSo.TrangThai);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hồ sơ: " + ex.Message);
            }
        }

        // Cập nhật hồ sơ
        public bool Update(HoSo hoSo)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE hoso SET 
  MaBacSi = @MaBacSi, 
  MaBenhNhan = @MaBenhNhan, 
         NgayNhapVien = @NgayNhapVien, 
  LyDo = @LyDo, 
           TrangThai = @TrangThai 
 WHERE MaHoSo = @MaHoSo";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoSo", hoSo.MaHoSo);
                        cmd.Parameters.AddWithValue("@MaBacSi", string.IsNullOrEmpty(hoSo.MaBacSi) ? (object)DBNull.Value : hoSo.MaBacSi);
                        cmd.Parameters.AddWithValue("@MaBenhNhan", hoSo.MaBenhNhan);
                        cmd.Parameters.AddWithValue("@NgayNhapVien", hoSo.NgayNhapVien);
                        cmd.Parameters.AddWithValue("@LyDo", hoSo.LyDo ?? "");
                        cmd.Parameters.AddWithValue("@TrangThai", hoSo.TrangThai);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật hồ sơ: " + ex.Message);
            }
        }

        // Xóa hồ sơ
        public bool Delete(string maHoSo)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM hoso WHERE MaHoSo = @MaHoSo";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoSo", maHoSo);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa hồ sơ: " + ex.Message);
            }
        }

        // Tìm kiếm hồ sơ
        public List<HoSo> Search(string keyword)
        {
            List<HoSo> list = new List<HoSo>();
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT hs.STT, hs.MaHoSo, hs.MaBacSi, hs.MaBenhNhan, 
   hs.NgayNhapVien, hs.LyDo, hs.TrangThai,
  bn.HoTen as TenBenhNhan,
           bs.HoTen as TenBacSi
  FROM hoso hs
   LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
   LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
     WHERE hs.MaHoSo LIKE @keyword 
   OR bn.HoTen LIKE @keyword
    OR bs.HoTen LIKE @keyword
    OR hs.LyDo LIKE @keyword
 OR hs.TrangThai LIKE @keyword
 ORDER BY hs.STT DESC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HoSo hs = new HoSo
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaHoSo = reader["MaHoSo"].ToString(),
                                MaBacSi = reader["MaBacSi"]?.ToString() ?? "",
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                NgayNhapVien = Convert.ToDateTime(reader["NgayNhapVien"]),
                                LyDo = reader["LyDo"]?.ToString() ?? "",
                                TrangThai = reader["TrangThai"].ToString(),
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? ""
                            };
                            list.Add(hs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm hồ sơ: " + ex.Message);
            }
            return list;
        }

        // Lấy hồ sơ theo mã
        public HoSo GetByMa(string maHoSo)
        {
            try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT hs.STT, hs.MaHoSo, hs.MaBacSi, hs.MaBenhNhan, 
        hs.NgayNhapVien, hs.LyDo, hs.TrangThai,
          bn.HoTen as TenBenhNhan,
 bs.HoTen as TenBacSi
FROM hoso hs
      LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
  LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
     WHERE hs.MaHoSo = @MaHoSo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoSo", maHoSo);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HoSo
                            {
                                STT = Convert.ToInt32(reader["STT"]),
                                MaHoSo = reader["MaHoSo"].ToString(),
                                MaBacSi = reader["MaBacSi"]?.ToString() ?? "",
                                MaBenhNhan = reader["MaBenhNhan"].ToString(),
                                NgayNhapVien = Convert.ToDateTime(reader["NgayNhapVien"]),
                                LyDo = reader["LyDo"]?.ToString() ?? "",
                                TrangThai = reader["TrangThai"].ToString(),
                                TenBenhNhan = reader["TenBenhNhan"]?.ToString() ?? "",
                                TenBacSi = reader["TenBacSi"]?.ToString() ?? ""
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin hồ sơ: " + ex.Message);
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

        // Lấy TẤT CẢ hồ sơ (bao gồm cả đã dùng) - dùng khi SỬA
      public List<HoSo> GetAllHoSo()
  {
       List<HoSo> list = new List<HoSo>();
     try
            {
                using (MySqlConnection conn = dbConnection.GetConnection())
   {
               conn.Open();
        string query = @"SELECT hs.MaHoSo, hs.MaBenhNhan, hs.MaBacSi, hs.TrangThai,
          bn.HoTen as TenBenhNhan,
   bs.HoTen as TenBacSi
       FROM hoso hs
       LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
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
     throw new Exception("Lỗi lấy danh sách hồ sơ: " + ex.Message);
       }
          return list;
        }

        // Lấy danh sách bệnh nhân CHƯA có hồ sơ
        public List<BenhNhan> GetBenhNhanChuaCoHoSo()
        {
    List<BenhNhan> list = new List<BenhNhan>();
   try
    {
           using (MySqlConnection conn = dbConnection.GetConnection())
          {
  conn.Open();
       // Chỉ lấy bệnh nhân chưa có trong bảng hoso
      string query = @"SELECT bn.MaBenhNhan, bn.HoTen 
            FROM benhnhan bn
      WHERE bn.MaBenhNhan NOT IN (SELECT DISTINCT MaBenhNhan FROM hoso)
ORDER BY bn.MaBenhNhan DESC";
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
              throw new Exception("Lỗi lấy danh sách bệnh nhân chưa có hồ sơ: " + ex.Message);
  }
            return list;
     }

        // Lấy danh sách bệnh nhân (bao gồm bệnh nhân đang được chọn khi sửa)
        public List<BenhNhan> GetAllBenhNhan(string maBenhNhanDangChon = null)
        {
List<BenhNhan> list = new List<BenhNhan>();
            try
            {
   using (MySqlConnection conn = dbConnection.GetConnection())
              {
    conn.Open();
            string query;
         
     if (string.IsNullOrEmpty(maBenhNhanDangChon))
{
                     // Khi THÊM MỚI: Chỉ lấy bệnh nhân chưa có hồ sơ
             query = @"SELECT bn.MaBenhNhan, bn.HoTen 
 FROM benhnhan bn
              WHERE bn.MaBenhNhan NOT IN (SELECT DISTINCT MaBenhNhan FROM hoso)
        ORDER BY bn.MaBenhNhan DESC";
       }
             else
  {
          // Khi SỬA: Lấy bệnh nhân chưa có hồ sơ HOẶC bệnh nhân đang được chọn
            query = @"SELECT bn.MaBenhNhan, bn.HoTen 
FROM benhnhan bn
     WHERE bn.MaBenhNhan NOT IN (SELECT DISTINCT MaBenhNhan FROM hoso)
  OR bn.MaBenhNhan = @MaBenhNhanDangChon
       ORDER BY bn.MaBenhNhan DESC";
    }

      MySqlCommand cmd = new MySqlCommand(query, conn);
 
         if (!string.IsNullOrEmpty(maBenhNhanDangChon))
      {
                cmd.Parameters.AddWithValue("@MaBenhNhanDangChon", maBenhNhanDangChon);
        }

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
    }
}
