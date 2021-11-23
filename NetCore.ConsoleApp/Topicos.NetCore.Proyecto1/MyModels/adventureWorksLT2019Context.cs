using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Topicos.NetCore.Proyecto1.MyModels
{
    public partial class adventureWorksLT2019Context : DbContext
    {
        public adventureWorksLT2019Context()
        {
        }

        public adventureWorksLT2019Context(DbContextOptions<adventureWorksLT2019Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=adventureWorksLT2019;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "SalesLT");

                entity.HasComment("Products sold or used in the manfacturing of sold products.");

                entity.HasIndex(e => e.Name, "AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid, "AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasComment("Primary key for Product records.");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasComment("Product color.");

                entity.Property(e => e.DiscontinuedDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was discontinued.");

                entity.Property(e => e.ListPrice)
                    .HasColumnType("money")
                    .HasComment("Selling price.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Name of the product.");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("ProductCategoryID")
                    .HasComment("Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. ");

                entity.Property(e => e.ProductModelId)
                    .HasColumnName("ProductModelID")
                    .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComment("Unique product identification number.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.Property(e => e.SellEndDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was no longer available for sale.");

                entity.Property(e => e.SellStartDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the product was available for sale.");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .HasComment("Product size.");

                entity.Property(e => e.StandardCost)
                    .HasColumnType("money")
                    .HasComment("Standard cost of the product.");

                entity.Property(e => e.ThumbNailPhoto).HasComment("Small image of the product.");

                entity.Property(e => e.ThumbnailPhotoFileName)
                    .HasMaxLength(50)
                    .HasComment("Small image file name.");

                entity.Property(e => e.Weight)
                    .HasColumnType("decimal(8, 2)")
                    .HasComment("Product weight.");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductCategoryId);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory", "SalesLT");

                entity.HasComment("High-level product categorization.");

                entity.HasIndex(e => e.Name, "AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid, "AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("ProductCategoryID")
                    .HasComment("Primary key for ProductCategory records.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Category description.");

                entity.Property(e => e.ParentProductCategoryId)
                    .HasColumnName("ParentProductCategoryID")
                    .HasComment("Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.HasOne(d => d.ParentProductCategory)
                    .WithMany(p => p.InverseParentProductCategory)
                    .HasForeignKey(d => d.ParentProductCategoryId)
                    .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId })
                    .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

                entity.ToTable("SalesOrderDetail", "SalesLT");

                entity.HasComment("Individual products associated with a specific sales order. See SalesOrderHeader.");

                entity.HasIndex(e => e.Rowguid, "AK_SalesOrderDetail_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.ProductId, "IX_SalesOrderDetail_ProductID");

                entity.Property(e => e.SalesOrderId)
                    .HasColumnName("SalesOrderID")
                    .HasComment("Primary key. Foreign key to SalesOrderHeader.SalesOrderID.");

                entity.Property(e => e.SalesOrderDetailId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SalesOrderDetailID")
                    .HasComment("Primary key. One incremental unique number per product sold.");

                entity.Property(e => e.LineTotal)
                    .HasColumnType("numeric(38, 6)")
                    .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                    .HasComment("Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.OrderQty).HasComment("Quantity ordered per product.");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .HasComment("Product sold to customer. Foreign key to Product.ProductID.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasComment("Selling price of a single product.");

                entity.Property(e => e.UnitPriceDiscount)
                    .HasColumnType("money")
                    .HasComment("Discount amount.");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SalesOrder)
                    .WithMany(p => p.SalesOrderDetails)
                    .HasForeignKey(d => d.SalesOrderId);
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId)
                    .HasName("PK_SalesOrderHeader_SalesOrderID");

                entity.ToTable("SalesOrderHeader", "SalesLT");

                entity.HasComment("General sales order information.");

                entity.HasIndex(e => e.SalesOrderNumber, "AK_SalesOrderHeader_SalesOrderNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid, "AK_SalesOrderHeader_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerId, "IX_SalesOrderHeader_CustomerID");

                entity.Property(e => e.SalesOrderId)
                    .HasColumnName("SalesOrderID")
                    .HasComment("Primary key.");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(15)
                    .HasComment("Financial accounting number reference.");

                entity.Property(e => e.BillToAddressId)
                    .HasColumnName("BillToAddressID")
                    .HasComment("The ID of the location to send invoices.  Foreign key to the Address table.");

                entity.Property(e => e.Comment).HasComment("Sales representative comments.");

                entity.Property(e => e.CreditCardApprovalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasComment("Approval code provided by the credit card company.");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasComment("Customer identification number. Foreign key to Customer.CustomerID.");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the order is due to the customer.");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Shipping cost.");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Date and time the record was last updated.");

                entity.Property(e => e.OnlineOrderFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 = Order placed by sales person. 1 = Order placed online by customer.");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("Dates the sales order was created.");

                entity.Property(e => e.PurchaseOrderNumber)
                    .HasMaxLength(25)
                    .HasComment("Customer purchase order number reference. ");

                entity.Property(e => e.RevisionNumber).HasComment("Incremental number to track changes to the sales order over time.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())")
                    .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

                entity.Property(e => e.SalesOrderNumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", false)
                    .HasComment("Unique sales order identification number.");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("datetime")
                    .HasComment("Date the order was shipped to the customer.");

                entity.Property(e => e.ShipMethod)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Shipping method. Foreign key to ShipMethod.ShipMethodID.");

                entity.Property(e => e.ShipToAddressId)
                    .HasColumnName("ShipToAddressID")
                    .HasComment("The ID of the location to send goods.  Foreign key to the Address table.");

                entity.Property(e => e.Status)
                    .HasDefaultValueSql("((1))")
                    .HasComment("Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.");

                entity.Property(e => e.TaxAmt)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.00))")
                    .HasComment("Tax amount.");

                entity.Property(e => e.TotalDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                    .HasComment("Total due from customer. Computed as Subtotal + TaxAmt + Freight.");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
