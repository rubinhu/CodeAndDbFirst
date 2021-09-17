using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DbFirst.API.Models.PostgreSQL
{
    public partial class WZSHRContext : DbContext
    {
        public WZSHRContext()
        {
        }

        public WZSHRContext(DbContextOptions<WZSHRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountGuest> AccountGuests { get; set; }
        public virtual DbSet<AppParam> AppParams { get; set; }
        public virtual DbSet<DlEmpType> DlEmpTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<NewMview> NewMviews { get; set; }
        public virtual DbSet<PostSuitedList> PostSuitedLists { get; set; }
        public virtual DbSet<ServiceQuestionType> ServiceQuestionTypes { get; set; }
        public virtual DbSet<ServiceScRecord> ServiceScRecords { get; set; }
        public virtual DbSet<ServiceUnit> ServiceUnits { get; set; }
        public virtual DbSet<WxBdLottery> WxBdLotteries { get; set; }
        public virtual DbSet<WxErrorlog> WxErrorlogs { get; set; }
        public virtual DbSet<WxLotteryWinner> WxLotteryWinners { get; set; }
        public virtual DbSet<WxMenu> WxMenus { get; set; }
        public virtual DbSet<WxUselog> WxUselogs { get; set; }
        public virtual DbSet<WxUserprofile> WxUserprofiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // optionsBuilder.UseNpgsql("Server=10.41.21.45;Database=WZSHR;User ID=WXACCOUNT;Password=WXACCOUNT;");
                optionsBuilder.UseNpgsql(AppSettings.Configuration.GetConnectionString("DB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_stat_statements")
                .HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<AccountGuest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("account_guest", "WXACCOUNT");

                entity.Property(e => e.Accountid)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("accountid");

                entity.Property(e => e.Isvalid)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("isvalid")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("password");

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("site");
            });

            modelBuilder.Entity<AppParam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("app_param", "WXACCOUNT");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.Group)
                    .HasMaxLength(20)
                    .HasColumnName("group");

                entity.Property(e => e.Lang)
                    .HasMaxLength(20)
                    .HasColumnName("lang");
            });

            modelBuilder.Entity<DlEmpType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dl_emp_type", "WXACCOUNT");

                entity.Property(e => e.DlEmpcategory)
                    .HasMaxLength(20)
                    .HasColumnName("dl_empcategory")
                    .HasComment("DL Emp Category");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("employee", "WXACCOUNT");

                entity.Property(e => e.Adult)
                    .HasMaxLength(1)
                    .HasColumnName("adult");

                entity.Property(e => e.Atvalid)
                    .HasMaxLength(1)
                    .HasColumnName("atvalid");

                entity.Property(e => e.Calendar)
                    .HasMaxLength(20)
                    .HasColumnName("calendar");

                entity.Property(e => e.Cardid)
                    .HasMaxLength(19)
                    .HasColumnName("cardid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("cname");

                entity.Property(e => e.Company)
                    .HasMaxLength(10)
                    .HasColumnName("company");

                entity.Property(e => e.DeptEntryDt)
                    .HasColumnType("date")
                    .HasColumnName("dept_entry_dt");

                entity.Property(e => e.Deptid)
                    .HasMaxLength(20)
                    .HasColumnName("deptid");

                entity.Property(e => e.Deptn)
                    .HasMaxLength(30)
                    .HasColumnName("deptn");

                entity.Property(e => e.Descrshort)
                    .HasMaxLength(30)
                    .HasColumnName("descrshort");

                entity.Property(e => e.EmplCategory)
                    .HasMaxLength(10)
                    .HasColumnName("empl_category");

                entity.Property(e => e.Emplid)
                    .HasMaxLength(20)
                    .HasColumnName("emplid");

                entity.Property(e => e.Ename)
                    .HasMaxLength(50)
                    .HasColumnName("ename");

                entity.Property(e => e.Gradeidentifier)
                    .HasMaxLength(1)
                    .HasColumnName("gradeidentifier");

                entity.Property(e => e.Hdate)
                    .HasColumnType("date")
                    .HasColumnName("hdate");

                entity.Property(e => e.L1)
                    .HasMaxLength(20)
                    .HasColumnName("l1");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .HasColumnName("location");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .HasColumnName("mobile");

                entity.Property(e => e.Nxtapprove)
                    .HasMaxLength(20)
                    .HasColumnName("nxtapprove");

                entity.Property(e => e.OfficerLevel)
                    .HasPrecision(3)
                    .HasColumnName("officer_level");

                entity.Property(e => e.OtEtime)
                    .HasColumnType("date")
                    .HasColumnName("ot_etime");

                entity.Property(e => e.OtStime)
                    .HasColumnType("date")
                    .HasColumnName("ot_stime");

                entity.Property(e => e.Otlimit).HasColumnName("otlimit");

                entity.Property(e => e.Otvalid)
                    .HasMaxLength(1)
                    .HasColumnName("otvalid");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

                entity.Property(e => e.Plant)
                    .HasMaxLength(5)
                    .HasColumnName("plant");

                entity.Property(e => e.Proxy)
                    .HasMaxLength(20)
                    .HasColumnName("proxy");

                entity.Property(e => e.ProxyTime)
                    .HasMaxLength(10)
                    .HasColumnName("proxy_time");

                entity.Property(e => e.Ptdate)
                    .HasColumnType("date")
                    .HasColumnName("ptdate");

                entity.Property(e => e.Ptype)
                    .HasMaxLength(20)
                    .HasColumnName("ptype");

                entity.Property(e => e.RehireDt)
                    .HasColumnType("date")
                    .HasColumnName("rehire_dt");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");

                entity.Property(e => e.SiteIdA)
                    .HasMaxLength(10)
                    .HasColumnName("site_id_a");

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(20)
                    .HasColumnName("supervisor");

                entity.Property(e => e.Tcode)
                    .HasMaxLength(20)
                    .HasColumnName("tcode");

                entity.Property(e => e.Tdate)
                    .HasMaxLength(8)
                    .HasColumnName("tdate");

                entity.Property(e => e.Treason)
                    .HasMaxLength(30)
                    .HasColumnName("treason");

                entity.Property(e => e.Udate)
                    .HasColumnType("date")
                    .HasColumnName("udate");

                entity.Property(e => e.UinSgp)
                    .HasMaxLength(50)
                    .HasColumnName("uin_sgp");

                entity.Property(e => e.UpperDept)
                    .HasMaxLength(20)
                    .HasColumnName("upper_dept");

                entity.Property(e => e.Userid)
                    .HasMaxLength(20)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<NewMview>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("new_mview", "WXACCOUNT");

                entity.Property(e => e.Adult)
                    .HasMaxLength(1)
                    .HasColumnName("adult");

                entity.Property(e => e.Atvalid)
                    .HasMaxLength(1)
                    .HasColumnName("atvalid");

                entity.Property(e => e.Calendar)
                    .HasMaxLength(20)
                    .HasColumnName("calendar");

                entity.Property(e => e.Cardid)
                    .HasMaxLength(19)
                    .HasColumnName("cardid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(50)
                    .HasColumnName("cname");

                entity.Property(e => e.Company)
                    .HasMaxLength(10)
                    .HasColumnName("company");

                entity.Property(e => e.DeptEntryDt)
                    .HasColumnType("date")
                    .HasColumnName("dept_entry_dt");

                entity.Property(e => e.Deptid)
                    .HasMaxLength(20)
                    .HasColumnName("deptid");

                entity.Property(e => e.Deptn)
                    .HasMaxLength(30)
                    .HasColumnName("deptn");

                entity.Property(e => e.Descrshort)
                    .HasMaxLength(30)
                    .HasColumnName("descrshort");

                entity.Property(e => e.EmplCategory)
                    .HasMaxLength(10)
                    .HasColumnName("empl_category");

                entity.Property(e => e.Emplid)
                    .HasMaxLength(20)
                    .HasColumnName("emplid");

                entity.Property(e => e.Ename)
                    .HasMaxLength(50)
                    .HasColumnName("ename");

                entity.Property(e => e.Grade)
                    .HasMaxLength(20)
                    .HasColumnName("grade");

                entity.Property(e => e.GradeEntryDt)
                    .HasColumnType("date")
                    .HasColumnName("grade_entry_dt");

                entity.Property(e => e.Gradeidentifier)
                    .HasMaxLength(1)
                    .HasColumnName("gradeidentifier");

                entity.Property(e => e.Hdate)
                    .HasColumnType("date")
                    .HasColumnName("hdate");

                entity.Property(e => e.JobEntryDt)
                    .HasColumnType("date")
                    .HasColumnName("job_entry_dt");

                entity.Property(e => e.L1)
                    .HasMaxLength(20)
                    .HasColumnName("l1");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .HasColumnName("location");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .HasColumnName("mobile");

                entity.Property(e => e.Nxtapprove)
                    .HasMaxLength(20)
                    .HasColumnName("nxtapprove");

                entity.Property(e => e.OfficerLevel)
                    .HasPrecision(3)
                    .HasColumnName("officer_level");

                entity.Property(e => e.OtEtime)
                    .HasColumnType("date")
                    .HasColumnName("ot_etime");

                entity.Property(e => e.OtStime)
                    .HasColumnType("date")
                    .HasColumnName("ot_stime");

                entity.Property(e => e.Otlimit).HasColumnName("otlimit");

                entity.Property(e => e.Otvalid)
                    .HasMaxLength(1)
                    .HasColumnName("otvalid");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

                entity.Property(e => e.Plant)
                    .HasMaxLength(5)
                    .HasColumnName("plant");

                entity.Property(e => e.Proxy)
                    .HasMaxLength(20)
                    .HasColumnName("proxy");

                entity.Property(e => e.ProxyTime)
                    .HasMaxLength(10)
                    .HasColumnName("proxy_time");

                entity.Property(e => e.Ptdate)
                    .HasColumnType("date")
                    .HasColumnName("ptdate");

                entity.Property(e => e.Ptype)
                    .HasMaxLength(20)
                    .HasColumnName("ptype");

                entity.Property(e => e.RehireDt)
                    .HasColumnType("date")
                    .HasColumnName("rehire_dt");

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .HasColumnName("sex");

                entity.Property(e => e.SiteIdA)
                    .HasMaxLength(10)
                    .HasColumnName("site_id_a");

                entity.Property(e => e.Supervisor)
                    .HasMaxLength(20)
                    .HasColumnName("supervisor");

                entity.Property(e => e.Tcode)
                    .HasMaxLength(20)
                    .HasColumnName("tcode");

                entity.Property(e => e.Tdate)
                    .HasMaxLength(8)
                    .HasColumnName("tdate");

                entity.Property(e => e.Treason)
                    .HasMaxLength(30)
                    .HasColumnName("treason");

                entity.Property(e => e.Udate)
                    .HasColumnType("date")
                    .HasColumnName("udate");

                entity.Property(e => e.UinSgp)
                    .HasMaxLength(50)
                    .HasColumnName("uin_sgp");

                entity.Property(e => e.UpperDept)
                    .HasMaxLength(20)
                    .HasColumnName("upper_dept");

                entity.Property(e => e.Userid)
                    .HasMaxLength(20)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<PostSuitedList>(entity =>
            {
                entity.HasKey(e => new { e.Emplid, e.SubmitDate })
                    .HasName("_post_suited_list_pk");

                entity.ToTable("post_suited_list", "WXACCOUNT");

                entity.Property(e => e.Emplid)
                    .HasMaxLength(20)
                    .HasColumnName("emplid")
                    .HasComment("工号");

                entity.Property(e => e.SubmitDate)
                    .HasColumnName("submit_date")
                    .HasComment("提交时间");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cname")
                    .HasComment("姓名");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasComment("日期");

                entity.Property(e => e.Deptid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("deptid")
                    .HasComment("部门代码");

                entity.Property(e => e.Descr)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("descr")
                    .HasComment("部门名称");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone")
                    .HasComment("手机号");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("status")
                    .HasComment("状态");

                entity.Property(e => e.Submitter)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("submitter")
                    .HasComment("提交人");

                entity.Property(e => e.UinSgp)
                    .HasMaxLength(50)
                    .HasColumnName("uin_sgp")
                    .HasComment("身份证号");
            });

            modelBuilder.Entity<ServiceQuestionType>(entity =>
            {
                entity.ToTable("service_question_type", "WXACCOUNT");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Desc)
                    .HasMaxLength(200)
                    .HasColumnName("desc");

                entity.Property(e => e.Isvalid)
                    .HasMaxLength(1)
                    .HasColumnName("isvalid")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.Site)
                    .HasMaxLength(20)
                    .HasColumnName("site")
                    .HasDefaultValueSql("'default'::character varying");

                entity.Property(e => e.Udate).HasColumnName("udate");

                entity.Property(e => e.UnitId)
                    .HasMaxLength(50)
                    .HasColumnName("unit_id");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(50)
                    .HasColumnName("uuser");
            });

            modelBuilder.Entity<ServiceScRecord>(entity =>
            {
                entity.ToTable("service_sc_record", "WXACCOUNT");

                entity.HasComment("银行卡上传记录");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('service_sc_record_id_seq'::regclass)");

                entity.Property(e => e.BankCategory)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("bank_category")
                    .HasComment("银行别(工行/建行)");

                entity.Property(e => e.BankNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("bank_number")
                    .HasComment("银行卡号");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cname")
                    .HasComment("姓名");

                entity.Property(e => e.Emplid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("emplid")
                    .HasComment("工号");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date")
                    .HasComment("入职日期");

                entity.Property(e => e.IdlStaffNotes)
                    .HasMaxLength(20)
                    .HasColumnName("idl_staff_notes")
                    .HasComment("IDL新入职员工备注（WZS）");

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("img_url")
                    .HasComment("图片连接（絕對路徑 https://xx）");

                entity.Property(e => e.IsApplyQuit)
                    .HasMaxLength(4)
                    .HasColumnName("is_apply_quit")
                    .HasComment("是否为已申请离职的本月入职新人（WZS）");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone_number")
                    .HasComment("电话号码");

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("site");

                entity.Property(e => e.UploadMethod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("upload_method")
                    .HasComment("上传方式：员工/访客");

                entity.Property(e => e.UploadReason)
                    .HasMaxLength(50)
                    .HasColumnName("upload_reason")
                    .HasComment("上传卡号原因（WZS）");

                entity.Property(e => e.UploadTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("upload_time")
                    .HasComment("上传时间(API接收時間)");

                entity.Property(e => e.UploadType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("upload_type")
                    .HasComment("新增/变更");
            });

            modelBuilder.Entity<ServiceUnit>(entity =>
            {
                entity.ToTable("service_unit", "WXACCOUNT");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.Desc)
                    .HasMaxLength(200)
                    .HasColumnName("desc");

                entity.Property(e => e.Isvalid)
                    .HasMaxLength(1)
                    .HasColumnName("isvalid")
                    .HasDefaultValueSql("'Y'::character varying");

                entity.Property(e => e.Site)
                    .HasMaxLength(20)
                    .HasColumnName("site")
                    .HasDefaultValueSql("'default'::character varying");

                entity.Property(e => e.Udate).HasColumnName("udate");

                entity.Property(e => e.Unit)
                    .HasMaxLength(200)
                    .HasColumnName("unit");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(20)
                    .HasColumnName("uuser");
            });

            modelBuilder.Entity<WxBdLottery>(entity =>
            {
                entity.HasKey(e => e.LotteryId)
                    .HasName("wx_bd_lottery_pk");

                entity.ToTable("wx_bd_lottery", "WXACCOUNT");

                entity.HasComment("抽奖序列号");

                entity.HasIndex(e => e.Emplid, "wx_bd_lottery_un")
                    .IsUnique();

                entity.Property(e => e.LotteryId)
                    .HasPrecision(5)
                    .HasColumnName("lottery_id")
                    .HasComment("抽奖序号");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("cname")
                    .HasComment("姓名");

                entity.Property(e => e.Deptid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("deptid")
                    .HasComment("部门");

                entity.Property(e => e.Emplid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("emplid")
                    .HasComment("工号");

                entity.Property(e => e.Plant)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("plant")
                    .HasComment("厂别");
            });

            modelBuilder.Entity<WxErrorlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wx_errorlog", "WXACCOUNT");

                entity.Property(e => e.Exception).HasColumnName("exception");

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .HasColumnName("level");

                entity.Property(e => e.MachineName).HasColumnName("machine_name");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.MessageTemplate).HasColumnName("message_template");

                entity.Property(e => e.Properties)
                    .HasColumnType("jsonb")
                    .HasColumnName("properties");

                entity.Property(e => e.PropsTest)
                    .HasColumnType("jsonb")
                    .HasColumnName("props_test");

                entity.Property(e => e.Udate).HasColumnName("udate");
            });

            modelBuilder.Entity<WxLotteryWinner>(entity =>
            {
                entity.ToTable("wx_lottery_winner", "WXACCOUNT");

                entity.HasComment("中奖信息");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('lottery_id_seq'::regclass)")
                    .HasComment("id");

                entity.Property(e => e.Award)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("award")
                    .HasComment("奖项");

                entity.Property(e => e.AwardDes)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("award_des")
                    .HasComment("奖项描述");

                entity.Property(e => e.LotteryId)
                    .HasPrecision(5)
                    .HasColumnName("lottery_id")
                    .HasComment("中奖序号");

                entity.Property(e => e.Udate)
                    .HasColumnName("udate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("更新时间");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(20)
                    .HasColumnName("uuser")
                    .HasComment("更新人");

                entity.HasOne(d => d.Lottery)
                    .WithMany(p => p.WxLotteryWinners)
                    .HasForeignKey(d => d.LotteryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("wx_lottery_winner_wx_bd_lottery_fk");
            });

            modelBuilder.Entity<WxMenu>(entity =>
            {
                entity.HasKey(e => e.Apid)
                    .HasName("wx_menu_pkey");

                entity.ToTable("wx_menu", "WXACCOUNT");

                entity.Property(e => e.Apid)
                    .HasMaxLength(100)
                    .HasColumnName("apid")
                    .HasDefaultValueSql("NULL::character varying")
                    .HasComment("apid of WeChat's miniprogram");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .HasColumnName("icon")
                    .HasComment("图标路径");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .HasComment("应用名称");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasComment("sequence");

                entity.Property(e => e.Site)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("site")
                    .HasComment("site(以,分割) or ActiveEmp.在職員工登錄；InActiveEmp.離職員工登錄；Guest.訪客登錄");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type")
                    .HasDefaultValueSql("'webview'::character varying")
                    .HasComment("type: webview or miniprogram");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("url")
                    .HasComment("web url");
            });

            modelBuilder.Entity<WxUselog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wx_uselog", "WXACCOUNT");

                entity.Property(e => e.Api)
                    .HasMaxLength(500)
                    .HasColumnName("api");

                entity.Property(e => e.Domain)
                    .HasMaxLength(100)
                    .HasColumnName("domain");

                entity.Property(e => e.Empno)
                    .HasMaxLength(50)
                    .HasColumnName("empno");

                entity.Property(e => e.Requestip)
                    .HasMaxLength(100)
                    .HasColumnName("requestip");

                entity.Property(e => e.Responsetime)
                    .HasMaxLength(100)
                    .HasColumnName("responsetime");

                entity.Property(e => e.Site)
                    .HasMaxLength(10)
                    .HasColumnName("site");

                entity.Property(e => e.System)
                    .HasMaxLength(100)
                    .HasColumnName("system");

                entity.Property(e => e.Usetime)
                    .HasColumnName("usetime")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<WxUserprofile>(entity =>
            {
                entity.HasKey(e => e.UnionId)
                    .HasName("wx_userprofile_pkey");

                entity.ToTable("wx_userprofile", "WXACCOUNT");

                entity.HasComment("WeChat's UserProfile");

                entity.Property(e => e.UnionId)
                    .HasMaxLength(100)
                    .HasColumnName("unionId")
                    .HasComment("unionId");

                entity.Property(e => e.AvatarUrl)
                    .HasMaxLength(500)
                    .HasColumnName("avatarUrl")
                    .HasDefaultValueSql("NULL::character varying")
                    .HasComment("avatarUrl");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city")
                    .HasComment("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .HasColumnName("country")
                    .HasComment("country");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender")
                    .HasDefaultValueSql("NULL::character varying")
                    .HasComment("gender");

                entity.Property(e => e.Language)
                    .HasMaxLength(50)
                    .HasColumnName("language")
                    .HasDefaultValueSql("NULL::character varying")
                    .HasComment("language");

                entity.Property(e => e.NickName)
                    .HasMaxLength(100)
                    .HasColumnName("nickName")
                    .HasComment("nickName");

                entity.Property(e => e.OpenId)
                    .HasMaxLength(100)
                    .HasColumnName("openId")
                    .HasComment("openId");

                entity.Property(e => e.Province)
                    .HasMaxLength(100)
                    .HasColumnName("province")
                    .HasComment("province");

                entity.Property(e => e.Udate)
                    .HasColumnName("udate")
                    .HasComment("update date time");

                entity.Property(e => e.Uuser)
                    .HasMaxLength(20)
                    .HasColumnName("uuser")
                    .HasComment("update userid");
            });

            modelBuilder.HasSequence("lottery_id_seq", "WXACCOUNT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
