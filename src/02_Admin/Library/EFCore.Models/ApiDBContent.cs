using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace EFCore.Models.Models
{
    public partial class ApiDBContent : DbContext
    {
        private DBConnectionOption _readAndWrite = null;

        public ApiDBContent(IOptionsMonitor<DBConnectionOption> options)
        {
            this._readAndWrite = options.CurrentValue;
        }

        private static int _iSeed = 0;//应该long
        public ApiDBContent ToRead()
        {
            //int num = new Random(_iSeed++).Next(0, this._readAndWrite.ReadConnectionList.Count);
            this.Database.GetDbConnection().ConnectionString = this._readAndWrite.ReadConnectionList[_iSeed++ % this._readAndWrite.ReadConnectionList.Count];//轮询
            //其实可以加入负载均衡策略---
            return this;
        }
        public ApiDBContent ToWrite()
        {
            this.Database.GetDbConnection().ConnectionString = this._readAndWrite.WriteConnection;
            return this;
        }
        public virtual DbSet<BaseLeave> BaseLeave { get; set; }
        public virtual DbSet<BaseUser> BaseUser { get; set; }
        public virtual DbSet<GoodsInfo> GoodsInfo { get; set; }
        public virtual DbSet<GoodsRdDetail> GoodsRdDetail { get; set; }
        public virtual DbSet<GoodsRecommend> GoodsRecommend { get; set; }
        public virtual DbSet<GoodsType> GoodsType { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._readAndWrite.WriteConnection);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseLeave>(entity =>
            {
                entity.HasComment("留言");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cdate)
                    .HasColumnName("CDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("创建时间");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("留言内容");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("姓名");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasComment("电话");
            });

            modelBuilder.Entity<BaseUser>(entity =>
            {
                entity.HasComment("用户信息");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("登陆账户");

                entity.Property(e => e.Age).HasComment("年龄");

                entity.Property(e => e.Card)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasComment("身份证");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser)
                    .HasDefaultValueSql("((0))")
                    .HasComment("创建人");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("邮箱");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("名称");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("密码");

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .HasComment("备注");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser).HasComment("修改人");
            });

            modelBuilder.Entity<GoodsInfo>(entity =>
            {
                entity.HasComment("物品主表");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Free)
                    .HasMaxLength(200)
                    .HasComment("附送");

                entity.Property(e => e.GoodsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("物品名称");

                entity.Property(e => e.Heat)
                    .HasMaxLength(50)
                    .HasComment("热度");

                entity.Property(e => e.Hotline)
                    .HasMaxLength(200)
                    .HasComment("热线");

                entity.Property(e => e.Introduce).HasComment("商品介绍");

                entity.Property(e => e.MarketPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("市场价");

                entity.Property(e => e.Remark)
                    .HasMaxLength(2000)
                    .HasComment("备注");

                entity.Property(e => e.Send)
                    .HasMaxLength(200)
                    .HasComment("配送");

                entity.Property(e => e.TradePrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasDefaultValueSql("((0))")
                    .HasComment("批发价");
            });

            modelBuilder.Entity<GoodsRdDetail>(entity =>
            {
                entity.HasComment("推荐明细物品");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GoodsId).HasColumnName("GoodsID");
            });

            modelBuilder.Entity<GoodsRecommend>(entity =>
            {
                entity.HasComment("首页商品推荐");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser).HasComment("创建人");

                entity.Property(e => e.SortId).HasColumnName("SortID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser).HasComment("修改人");
            });

            modelBuilder.Entity<GoodsType>(entity =>
            {
                entity.HasComment("物品主分类");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abridge).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("创建时间");

                entity.Property(e => e.CreateUser).HasComment("创建人");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .HasComment("图标");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("名称");

                entity.Property(e => e.Rank)
                    .HasDefaultValueSql("((0))")
                    .HasComment("分类等级");

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .HasComment("备注");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.UpdateUser).HasComment("修改人");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
