using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PCRentalMGR.Models;

public class PCRentalMGRContext : DbContext
{
    public PCRentalMGRContext(DbContextOptions<PCRentalMGRContext> options)
    : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }  // ここでDeviceを追加
    public DbSet<Rental> Rentals { get; set; }  // ここでDeviceを追加
    public DbSet<Employee> Employees { get; set; }  // Employeeエンティティを登録

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.User)
            .WithMany() // 一人のユーザーが複数のレンタルを持つ場合
            .HasForeignKey(r => r.UserId);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Device)
            .WithMany() // 複数の貸出データに対応する場合
            .HasForeignKey(r => r.DeviceId);
    }
}