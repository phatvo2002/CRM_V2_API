# CRM_V2_API

Tài liệu ngắn gọn cho dự án CRM_V2_API (API backend) — dự án .NET 8.

Mục đích: cung cấp API cho hệ thống CRM (phiên bản 2). README này mô tả cấu trúc, cách build, chạy cục bộ, đóng gói Docker và các thông tin cấu hình cần thiết.

---

## Yêu cầu trước

- .NET 8 SDK
- Docker (nếu muốn đóng gói/triển khai bằng container)
- PowerShell (hướng dẫn lệnh ví dụ dùng PowerShell)
- (Tuỳ chọn) Docker Hub hoặc registry riêng để push image

---

## Cấu trúc dự án (tổng quan)

- src/CRM.API: project Web API chính (ví dụ path: `src/CRM.API/CRM.API.csproj`)
- Dockerfile: multi-stage Dockerfile để build và publish ứng dụng (.NET 8)
- .dockerignore: các file/thu muc không cần copy vào build context

---

## Build & chạy cục bộ (không Docker)

1. Mở terminal (PowerShell) ở thư mục gốc của repository:
   cd E:\project\CRM_V2_API

2. Build và chạy:
   dotnet build src/CRM.API/CRM.API.csproj -c Release
   dotnet run --project src/CRM.API/CRM.API.csproj -c Release

3. API thường lắng nghe trên cổng cấu hình trong appsettings hoặc biến môi trường `ASPNETCORE_URLS`.

---

## Docker — build, run, push

Dockerfile trong repository là multi-stage cho .NET 8. Các lệnh mẫu (PowerShell):

1) Build image:
   docker build -t <dockerhub-username>/crm_v2_api:latest -f Dockerfile .

2) Chạy container để kiểm thử:
   docker run -d -p 5000:80 --name crm_api -e ASPNETCORE_ENVIRONMENT=Production <dockerhub-username>/crm_v2_api:latest

3) Đăng nhập Docker Hub:
   docker login --username <dockerhub-username>

4) Push image lên registry:
   docker push <dockerhub-username>/crm_v2_api:latest

Ghi chú:
- Dockerfile hiện tại thực thi `dotnet restore` và `dotnet publish` cho `src/CRM.API/CRM.API.csproj`.
- ENTRYPOINT mặc định chạy `dotnet CRM.API.dll` — thay tên DLL nếu assembly khác.

---

## Biến môi trường & cấu hình

- ASPNETCORE_ENVIRONMENT: Development/Production
- ConnectionStrings__Default: connection string đến DB (nếu ứng dụng dùng DB). Ví dụ:
  -e ConnectionStrings__Default="Server=...;Database=...;User Id=...;Password=...;"

Nếu dùng secrets hoặc Azure Key Vault/managed identity, tích hợp theo mô hình của dự án.

---

## Mẹo debug & troubleshooting

- Nếu container crash ngay sau khi chạy: kiểm tra logs bằng `docker logs <container>`.
- Kiểm tra appsettings.json và biến môi trường để đảm bảo connection string và các setting cần thiết.
- Nếu docker build lỗi do đường dẫn project, kiểm tra lại `COPY . .` và path `src/CRM.API/CRM.API.csproj` trong Dockerfile.

---

## Tests

Nếu có test project, chạy bằng:
  dotnet test

---

## Triển khai (tham khảo nhanh)

- Docker Hub / ACR: push image rồi deploy lên môi trường (Kubernetes, App Service for Containers, Azure Container Instances,...)
- CI/CD: Thêm bước build Docker image và push trong pipeline (GitHub Actions/Azure DevOps/GitLab CI).

---

## Liên hệ

Thông tin repository: https://github.com/phatvo2002/CRM_V2_API

---

Ghi chú: README này là tài liệu tổng quát; điều chỉnh đường dẫn project, tên assembly và biến môi trường theo cấu hình thực tế của dự án.