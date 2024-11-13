using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// CORS��������|���V�[��ǉ�
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()       // �S�ẴI���W��������
              .AllowAnyMethod()       // �S�Ă�HTTP���\�b�h������
              .AllowAnyHeader();      // �S�Ẵw�b�_�[������
    });
});

// DbContext�̒ǉ�
builder.Services.AddDbContext<PCRentalMGRContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// �T�[�r�X�̒ǉ�
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


// �A�v���P�[�V�����̃r���h
var app = builder.Build();

// �J�����̏ꍇ�̏���
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// CORS�̐ݒ�
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// �G���h�|�C���g�̃}�b�s���O
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// �f�[�^�x�[�X�̏�����
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PCRentalMGRContext>();
        DbInitializer.Initialize(context); // �V�[�h�f�[�^�̑}��
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "�f�[�^�x�[�X�̃V�[�h���ɃG���[���������܂����B");
    }
}

// �A�v���P�[�V�����̎��s
app.Run();
