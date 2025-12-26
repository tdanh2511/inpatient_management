using InpatientManagerSystem.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace InpatientManagerSystem.DAO
{
    internal class DonThuocDAO
    {
        private DBConnection db = new DBConnection();

        public List<DonThuocDTO> GetAll()
        {
            List<DonThuocDTO> list = new List<DonThuocDTO>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM DonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DonThuocDTO donThuoc = new DonThuocDTO
                            {
                                maDonThuoc = reader["maDonThuoc"].ToString(),
                                maKhamBenh = reader["maKhamBenh"].ToString(),
                                ngayKe = Convert.ToDateTime(reader["ngayKe"])
                            };
                            list.Add(donThuoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching DonThuoc records: " + ex.Message);
            }
            return list;
        }

        public bool Insert(DonThuocDTO donThuoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO DonThuoc (maKhamBenh, ngayKe) VALUES (@maKhamBenh, @ngayKe)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maKhamBenh", donThuoc.maKhamBenh);
                    cmd.Parameters.AddWithValue("@ngayKe", donThuoc.ngayKe);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting DonThuoc record: " + ex.Message);
                return false;
            }
        }

        public bool Delete(string maDonThuoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM DonThuoc WHERE maDonThuoc = @maDonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maDonThuoc", maDonThuoc);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting DonThuoc record: " + ex.Message);
                return false;
            }
        }

        public bool Update(DonThuocDTO donThuoc)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE DonThuoc SET maKhamBenh = @maKhamBenh, ngayKe = @ngayKe WHERE maDonThuoc = @maDonThuoc";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@maKhamBenh", donThuoc.maKhamBenh);
                    cmd.Parameters.AddWithValue("@ngayKe", donThuoc.ngayKe);
                    cmd.Parameters.AddWithValue("@maDonThuoc", donThuoc.maDonThuoc);
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating DonThuoc record: " + ex.Message);
                return false;
            }
        }

        public List<DonThuocDTO> Search(string key)
        {
            List<DonThuocDTO> list = new List<DonThuocDTO>();
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM DonThuoc WHERE maKhamBenh LIKE @KEY OR NGAYKE LIKE @KEY  OR MADONTHUOC LIKE @KEY ORDER BY MADONTHUOC ASC ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KEY", "%" + key + "%");
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DonThuocDTO donThuoc = new DonThuocDTO
                            {
                                maDonThuoc = reader["maDonThuoc"].ToString(),
                                maKhamBenh = reader["maKhamBenh"].ToString(),
                                ngayKe = Convert.ToDateTime(reader["ngayKe"])
                            };
                            list.Add(donThuoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching DonThuoc records: " + ex.Message);
            }
            return list;
        }
    }
}
