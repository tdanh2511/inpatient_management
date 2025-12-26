# ✅ ĐÃ HOÀN THÀNH: LỌC DỮ LIỆU COMBOBOX

## 🎯 Mục tiêu đã đạt được:

### FormKhamBenh
- ✅ ComboBox **Hồ sơ** chỉ hiển thị hồ sơ **CHƯA được sử dụng** trong khám bệnh
- ✅ Khi **thêm mới**: Chỉ hiển thị hồ sơ chưa dùng
- ✅ Khi **sửa**: Hiển thị hồ sơ chưa dùng + hồ sơ đang được chọn

### FormHoSo
- ✅ ComboBox **Bệnh nhân** chỉ hiển thị bệnh nhân **CHƯA có hồ sơ**
- ✅ Khi **thêm mới**: Chỉ hiển thị bệnh nhân chưa có hồ sơ
- ✅ Khi **sửa**: Hiển thị bệnh nhân chưa có hồ sơ + bệnh nhân đang được chọn

---

## 📝 Chi tiết thay đổi:

### 1. **KhamBenhDAO.cs**

```csharp
// Method MỚI: Lọc hồ sơ đã dùng
public List<HoSo> GetAllHoSo(string maHoSoDangChon = null)
{
    if (string.IsNullOrEmpty(maHoSoDangChon))
    {
// THÊM MỚI: Chỉ lấy hồ sơ chưa dùng
        WHERE hs.MaHoSo NOT IN (SELECT DISTINCT MaHoSo FROM khambenh WHERE MaHoSo IS NOT NULL)
    }
    else
    {
        // SỬA: Lấy hồ sơ chưa dùng HOẶC hồ sơ đang được chọn
  WHERE hs.MaHoSo NOT IN (...) OR hs.MaHoSo = @MaHoSoDangChon
    }
}
```

### 2. **HoSoDAO.cs**

```csharp
// Method MỚI: Lọc bệnh nhân đã có hồ sơ
public List<BenhNhan> GetAllBenhNhan(string maBenhNhanDangChon = null)
{
    if (string.IsNullOrEmpty(maBenhNhanDangChon))
 {
        // THÊM MỚI: Chỉ lấy bệnh nhân chưa có hồ sơ
        WHERE bn.MaBenhNhan NOT IN (SELECT DISTINCT MaBenhNhan FROM hoso)
    }
    else
    {
  // SỬA: Lấy bệnh nhân chưa có hồ sơ HOẶC bệnh nhân đang được chọn
        WHERE bn.MaBenhNhan NOT IN (...) OR bn.MaBenhNhan = @MaBenhNhanDangChon
    }
}
```

### 3. **FormKhamBenh.cs**

```csharp
// Load ComboBox với tham số
private void LoadComboBoxes(string maHoSoDangChon = null)
{
    var danhSachHoSo = khamBenhBUS.LayDanhSachHoSo(maHoSoDangChon);
    // Chỉ hiển thị hồ sơ chưa dùng (hoặc hồ sơ đang chọn khi sửa)
}

// Khi click vào DataGridView (SỬA)
private void DataGridView1_CellClick(...)
{
    string maHoSo = row.Cells["MaHoSo"].Value?.ToString() ?? "";
 LoadComboBoxes(maHoSo); // Load với hồ sơ đang chọn
}
```

### 4. **FormHoSo.cs**

```csharp
// Load ComboBox với tham số
private void LoadComboBoxes(string maBenhNhanDangChon = null)
{
    var danhSachBenhNhan = hoSoBUS.LayDanhSachBenhNhan(maBenhNhanDangChon);
    // Chỉ hiển thị bệnh nhân chưa có hồ sơ (hoặc bệnh nhân đang chọn khi sửa)
}

// Khi click vào DataGridView (SỬA)
private void DataGridView1_CellClick(...)
{
    string maBenhNhan = row.Cells["MaBenhNhan"].Value?.ToString() ?? "";
    LoadComboBoxes(maBenhNhan); // Load với bệnh nhân đang chọn
}
```

---

## 🎨 Kịch bản sử dụng:

### FormKhamBenh - Trường hợp 1: THÊM MỚI

```
1. Mở FormKhamBenh
2. ComboBox "Hồ sơ" hiển thị:
   - HS0001 - Nguyễn Văn A - Đang điều trị ✅
   - HS0003 - Trần Thị C - Đang điều trị ✅
   (HS0002 KHÔNG hiển thị vì đã được sử dụng ❌)
3. Chọn hồ sơ và thêm khám bệnh
4. Sau khi thêm, hồ sơ vừa chọn biến mất khỏi ComboBox ✅
```

### FormKhamBenh - Trường hợp 2: SỬA

```
1. Click vào khám bệnh có hồ sơ HS0002
2. ComboBox "Hồ sơ" hiển thị:
   - HS0001 - Nguyễn Văn A ✅ (chưa dùng)
   - HS0002 - Trần Thị B ✅ (đang được chọn - vẫn hiển thị)
   - HS0003 - Lê Văn C ✅ (chưa dùng)
3. Có thể sửa hồ sơ hoặc giữ nguyên
```

### FormHoSo - Trường hợp 1: THÊM MỚI

```
1. Mở FormHoSo
2. ComboBox "Bệnh nhân" hiển thị:
   - BN000001 - Nguyễn Văn A ✅ (chưa có hồ sơ)
   - BN000003 - Lê Thị C ✅ (chưa có hồ sơ)
   (BN000002 KHÔNG hiển thị vì đã có hồ sơ ❌)
3. Chọn bệnh nhân và thêm hồ sơ
4. Sau khi thêm, bệnh nhân vừa chọn biến mất khỏi ComboBox ✅
```

### FormHoSo - Trường hợp 2: SỬA

```
1. Click vào hồ sơ của bệnh nhân BN000002
2. ComboBox "Bệnh nhân" hiển thị:
   - BN000001 ✅ (chưa có hồ sơ)
   - BN000002 ✅ (đang được chọn - vẫn hiển thị)
   - BN000003 ✅ (chưa có hồ sơ)
3. Có thể sửa hoặc giữ nguyên
```

---

## 🔍 Query Database được sử dụng:

### Lọc hồ sơ chưa dùng (FormKhamBenh):
```sql
SELECT hs.MaHoSo, hs.MaBenhNhan, hs.MaBacSi, hs.TrangThai,
       bn.HoTen as TenBenhNhan,
       bs.HoTen as TenBacSi
FROM hoso hs
LEFT JOIN benhnhan bn ON hs.MaBenhNhan = bn.MaBenhNhan
LEFT JOIN bacsi bs ON hs.MaBacSi = bs.MaBacSi
WHERE hs.MaHoSo NOT IN (SELECT DISTINCT MaHoSo FROM khambenh WHERE MaHoSo IS NOT NULL)
ORDER BY hs.STT DESC
```

### Lọc bệnh nhân chưa có hồ sơ (FormHoSo):
```sql
SELECT bn.MaBenhNhan, bn.HoTen 
FROM benhnhan bn
WHERE bn.MaBenhNhan NOT IN (SELECT DISTINCT MaBenhNhan FROM hoso)
ORDER BY bn.MaBenhNhan DESC
```

---

## ✅ Lợi ích:

| Tính năng | Trước đây | Bây giờ |
|-----------|-----------|---------|
| Thêm hồ sơ | Có thể chọn bệnh nhân đã có hồ sơ → Lỗi | Chỉ hiển thị bệnh nhân chưa có hồ sơ ✅ |
| Thêm khám bệnh | Có thể chọn hồ sơ đã dùng → Trùng lặp | Chỉ hiển thị hồ sơ chưa dùng ✅ |
| Sửa hồ sơ | Mất dữ liệu đang chọn | Vẫn hiển thị dữ liệu đang chọn ✅ |
| Sửa khám bệnh | Mất dữ liệu đang chọn | Vẫn hiển thị dữ liệu đang chọn ✅ |

---

## 🧪 Cách test:

### Test 1: FormHoSo - Thêm mới
1. Mở FormHoSo
2. Click ComboBox "Bệnh nhân"
3. ✅ Kiểm tra: Chỉ hiển thị bệnh nhân CHƯA có hồ sơ
4. Chọn 1 bệnh nhân và thêm hồ sơ
5. Click ComboBox "Bệnh nhân" lại
6. ✅ Kiểm tra: Bệnh nhân vừa thêm KHÔNG hiển thị nữa

### Test 2: FormHoSo - Sửa
1. Click vào 1 hồ sơ trong DataGridView
2. Click ComboBox "Bệnh nhân"
3. ✅ Kiểm tra: Bệnh nhân đang được chọn VẪN hiển thị
4. ✅ Kiểm tra: Các bệnh nhân khác chưa có hồ sơ cũng hiển thị

### Test 3: FormKhamBenh - Thêm mới
1. Mở FormKhamBenh
2. Click ComboBox "Hồ sơ"
3. ✅ Kiểm tra: Chỉ hiển thị hồ sơ CHƯA được dùng
4. Chọn 1 hồ sơ và thêm khám bệnh
5. Click ComboBox "Hồ sơ" lại
6. ✅ Kiểm tra: Hồ sơ vừa chọn KHÔNG hiển thị nữa

### Test 4: FormKhamBenh - Sửa
1. Click vào 1 khám bệnh có hồ sơ
2. Click ComboBox "Hồ sơ"
3. ✅ Kiểm tra: Hồ sơ đang được chọn VẪN hiển thị
4. ✅ Kiểm tra: Các hồ sơ chưa dùng cũng hiển thị

---

## 📊 Tổng kết:

| Form | ComboBox | Tình trạng |
|------|----------|------------|
| FormKhamBenh | Hồ sơ | ✅ Chỉ hiển thị hồ sơ chưa dùng |
| FormKhamBenh | Bệnh nhân | ✅ Disable khi chọn hồ sơ |
| FormKhamBenh | Bác sĩ | ✅ Disable khi chọn hồ sơ |
| FormHoSo | Bệnh nhân | ✅ Chỉ hiển thị bệnh nhân chưa có hồ sơ |
| FormHoSo | Bác sĩ | ✅ Hiển thị tất cả (không filter) |

**Build thành công!** 🎉
**Không còn dữ liệu trùng lặp!** ✅
