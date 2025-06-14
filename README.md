# G-Scores - Hệ thống Quản lý Điểm thi THPT

## 📋 Mô tả

G-Scores là một ứng dụng web ASP.NET Core được phát triển để quản lý và phân tích điểm thi THPT (Trung học Phổ thông). Ứng dụng cho phép lưu trữ, truy vấn và phân tích điểm thi của học sinh với các môn học khác nhau.

## 🚀 Tính năng

- **Quản lý điểm thi**: Lưu trữ và quản lý điểm thi của học sinh
- **Phân tích dữ liệu**: Thống kê và phân tích điểm thi theo nhiều tiêu chí
- **API RESTful**: Cung cấp API để tích hợp với các hệ thống khác
- **Giao diện web**: Giao diện người dùng thân thiện
- **Biểu đồ trực quan**: Hiển thị dữ liệu dưới dạng biểu đồ với ChartJS

## 🛠️ Công nghệ sử dụng

- **Backend**: ASP.NET Core 8.0
- **Database**: Microsoft Azure SQL Database
- **ORM**: Entity Framework Core 9.0
- **API Documentation**: Swagger/OpenAPI
- **CORS**: Hỗ trợ Cross-Origin Resource Sharing

## 📊 Cấu trúc dữ liệu

### Model Student
Ứng dụng quản lý thông tin điểm thi với các trường:
- `Id`: Khóa chính
- `sbd`: Số báo danh
- `toan`: Điểm Toán
- `ngu_van`: Điểm Ngữ văn
- `ngoai_ngu`: Điểm Ngoại ngữ
- `vat_li`: Điểm Vật lý
- `hoa_hoc`: Điểm Hóa học
- `sinh_hoc`: Điểm Sinh học
- `lich_su`: Điểm Lịch sử
- `dia_li`: Điểm Địa lý
- `gdcd`: Điểm Giáo dục công dân
- `ma_ngoai_ngu`: Mã ngoại ngữ
- `TotalScore`: Tổng điểm (tính toán)

## 📁 Cấu trúc thư mục và vị trí file

```
G-Scores/
├── Controllers/
│   ├── StudentController.cs      # API endpoints cho quản lý học sinh
│   └── HomeController.cs         
├── Data/
│   └── ApplicationDbContext.cs   # DbContext cho Entity Framework
├── Models/
│   ├── Student.cs                # Model Student với các trường điểm thi
│   └── ErrorViewModel.cs         
├── Services/
│   └── DataSeeder.cs             # Service để import dữ liệu từ CSV
├── Views/                        
├── wwwroot/                      
├── Migrations/                   # Entity Framework migrations
├── Properties/                   # Project properties
├── Program.cs                    # Entry point và cấu hình ứng dụng
├── appsettings.json              # Configuration và connection string
├── diem_thi_thpt_2024.csv        # File dữ liệu điểm thi (41MB)
└── G-Scores.csproj               # Project file
```

## 🚀 Cài đặt và Chạy

### Yêu cầu hệ thống
- .NET 8.0 SDK
- Microsoft Azure SQL Database
- Visual Studio 2022 hoặc VS Code

### Bước 1: Clone repository
```bash
git clone <repository-url>
cd G-Scores
```

### Bước 2: Cấu hình Database
1. Cập nhật connection string trong `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:your-server.database.windows.net,1433;Database=your-database;User Id=your-username;Password=your-password;TrustServerCertificate=True;"
  }
}
```

2. Chạy migration để tạo database:
```bash
dotnet ef database update
```

### Bước 3: Chạy ứng dụng
```bash
dotnet run
```

Ứng dụng sẽ chạy tại: `https://localhost:5001` hoặc `http://localhost:5000`

## 📚 API Documentation

Sau khi chạy ứng dụng, bạn có thể truy cập Swagger UI tại:
- Development: `https://localhost:5001/swagger`
- Production: `/swagger`

### Các API endpoints chính:

#### Student API (`/api/Student`)
- `GET /api/Student/{sbd}` - Lấy thông tin học sinh theo số báo danh
- `GET /api/Student/TopAStudents` - Lấy top 10 học sinh có điểm cao nhất (tổng điểm Toán + Vật lý + Hóa học)
- `GET /api/Student/ScoreStatistics` - Lấy thống kê điểm theo từng môn học (phân loại theo 4 mức: ≥8, 6-8, 4-6, <4)


## 🔧 Cấu hình

### Environment Variables
- `ASPNETCORE_ENVIRONMENT`: Môi trường chạy (Development/Production)
- `ConnectionStrings__DefaultConnection`: Connection string cho database

### CORS Policy
Ứng dụng được cấu hình với CORS policy "AllowAll" để cho phép truy cập từ mọi origin.

## 📈 Tính năng phân tích

- **Thống kê điểm theo môn học**: Phân loại điểm thành 4 mức độ
- **Top học sinh xuất sắc**: Tìm 10 học sinh có tổng điểm cao nhất
- **Tìm kiếm theo số báo danh**: Tra cứu thông tin học sinh nhanh chóng
- **Import dữ liệu từ CSV**: Tự động import dữ liệu từ file `diem_thi_thpt_2024.csv`
