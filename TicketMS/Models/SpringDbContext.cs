using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketMS.Models;

public partial class SpringDbContext : DbContext
{
    public SpringDbContext()
    {
    }

    public SpringDbContext(DbContextOptions<SpringDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<TicketCategory> TicketCategories { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:TicketsDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("PK__customer__B61ED7F58206945A");

            entity.ToTable("customer");

            entity.HasIndex(e => e.Email, "UK_dwk6cx0afu8bs9o4t536v1j5v").IsUnique();

            entity.Property(e => e.Customerid)
               // .ValueGeneratedNever()
                .HasColumnName("customerid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Eventid).HasName("PK__event__2DC8B1116E0A7279");

            entity.ToTable("event");

            entity.Property(e => e.Eventid)
               // .ValueGeneratedNever()
                .HasColumnName("eventid");
            entity.Property(e => e.EndDate)
                .HasPrecision(6)
                .HasColumnName("end_date");
            entity.Property(e => e.EventDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_description");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("event_name");
            entity.Property(e => e.EventTypeid).HasColumnName("event_typeid");
            entity.Property(e => e.StartDate)
                .HasPrecision(6)
                .HasColumnName("start_date");
            entity.Property(e => e.Venueid).HasColumnName("venueid");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeid)
                .HasConstraintName("FKefmt1km8bokemo4vs40raqqbg");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.Venueid)
                .HasConstraintName("FKi6e9q306tqiiddx808ul8hn5d");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.EventTypeid).HasName("PK__event_ty__098CC97D025ED2C2");

            entity.ToTable("event_type");

            entity.Property(e => e.EventTypeid)
               // .ValueGeneratedNever()
                .HasColumnName("event_typeid");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PK__orders__080E37752ABF5437");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid)
              //  .ValueGeneratedNever()
                .HasColumnName("orderid");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.NumberOfTickets).HasColumnName("number_of_tickets");
            entity.Property(e => e.OrderAt)
                .HasPrecision(6)
                .HasColumnName("order_at");
            entity.Property(e => e.TicketCategoryid).HasColumnName("ticket_categoryid");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("FKbhieamq65ke02r8ijfso5tivn");

            entity.HasOne(d => d.TicketCategory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TicketCategoryid)
                .HasConstraintName("FK8ayya0p1uhlh8owxqdxe2osbc");
        });

        modelBuilder.Entity<TicketCategory>(entity =>
        {
            entity.HasKey(e => e.TicketCategoryid).HasName("PK__ticket_c__45D44DCA4E4E2FFE");

            entity.ToTable("ticket_category");

            entity.Property(e => e.TicketCategoryid)
               // .ValueGeneratedNever()
                .HasColumnName("ticket_categoryid");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Event).WithMany(p => p.TicketCategories)
                .HasForeignKey(d => d.Eventid)
                .HasConstraintName("FKpclsgt6dy7y5r1tuntx9sk2a5")
                .OnDelete(DeleteBehavior.Cascade);

        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Venueid).HasName("PK__venue__4DC0ABE79CA8000A");

            entity.ToTable("venue");

            entity.Property(e => e.Venueid)
            //    .ValueGeneratedNever()
                .HasColumnName("venueid");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });
        modelBuilder.HasSequence("customer_seq").IncrementsBy(50);
        modelBuilder.HasSequence("event_seq").IncrementsBy(50);
        modelBuilder.HasSequence("event_type_seq").IncrementsBy(50);
        modelBuilder.HasSequence("order_seq").IncrementsBy(50);
        modelBuilder.HasSequence("orders_seq").IncrementsBy(50);
        modelBuilder.HasSequence("ticket_category_seq").IncrementsBy(50);
        modelBuilder.HasSequence("venue_seq").IncrementsBy(50);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}