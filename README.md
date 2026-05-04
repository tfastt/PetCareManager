# PetCareManager
ách vận hành & sử dụng ứng dụng PetCareManager
1. Cần cài gì trước

Người dùng cần có:

Microsoft SQL Server
SQL Server Management Studio
Visual Studio (để chạy project)
2. Chuẩn bị database (làm 1 lần)
Bước 1: Mở SSMS
Mở SSMS
Nhấn Connect ((localdb)\MSSQLLocalDBl)
Bước 2: Tạo database
Click phải Databases → New Database
Đặt tên:
PetCareManager
Bước 3: Tạo bảng
Copy toàn bộ script SQL bạn đã viết (User, Pet, Vaccine, …)
Dán vào SSMS → bấm Execute

👉 Xong bước này là DB đã sẵn sàng

3. Chạy ứng dụng
Bước 1:
Mở project bằng Visual Studio
Bước 2:
Nhấn F5 (Run)

👉 Ứng dụng sẽ mở ra

4. Cách sử dụng trong app
➤ Thêm thú cưng
Nhập:
Pet Name
Species
Breed
Weight
Gender
Nhấn Add
➤ Sửa thông tin
Click vào pet trong bảng
Thông tin sẽ hiện lên form
Sửa lại
Nhấn Update
➤ Xóa
Chọn pet
Nhấn Delete
➤ Tìm kiếm
Nhập Pet ID
Nhấn Search
➤ Quản lý vaccine
Chọn pet
Nhấn Edit Vaccine
Thêm lịch tiêm
5. Lưu ý quan trọng
Phải mở SQL Server trước khi chạy app
Database phải tên đúng: PetCareManager
Không sửa cấu trúc bảng nếu không sửa code
