var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 1. THÊM DỊCH VỤ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ChoPhepInfinityFree",
        policy =>
        {
            policy.AllowAnyOrigin()  // Cho phép mọi tên miền gọi vào
                  .AllowAnyMethod()  // Cho phép GET, POST, PUT...
                  .AllowAnyHeader(); // Cho phép mọi Header
        });
});

var app = builder.Build();

// ... (Các dòng cấu hình khác giữ nguyên)

app.UseHttpsRedirection();

// 2. KÍCH HOẠT CORS (Đặt trước UseAuthorization)
app.UseCors("ChoPhepInfinityFree"); 

app.UseAuthorization();
app.MapControllers();
app.Run();