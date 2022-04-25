using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
#nullable disable
namespace LibraryApplication.Database
{
    public partial class LibraryDatabaseContext : DbContext
    {
        public LibraryDatabaseContext()
        {
        }

        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Librarian> Librarians { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlite("DataSource=.\\DataBase\\LibraryDatabase.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("authors");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasMany(d => d.Books)
                    .WithMany(p => p.Authors)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookAuthor",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull),
                        j =>
                        {
                            j.HasKey("AuthorId", "BookId");

                            j.ToTable("book_authors");

                            j.IndexerProperty<long>("AuthorId").HasColumnType("INT").HasColumnName("author_id");

                            j.IndexerProperty<long>("BookId").HasColumnType("INT").HasColumnName("book_id");
                        });
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Length)
                    .HasColumnType("INT")
                    .HasColumnName("length");

                entity.Property(e => e.Publisher).HasColumnName("publisher");

                entity.Property(e => e.SeriesId)
                    .HasColumnType("INT")
                    .HasColumnName("series_id");

                entity.Property(e => e.SeriesPos)
                    .HasColumnType("INT")
                    .HasColumnName("series_pos");

                entity.Property(e => e.Subtitle).HasColumnName("subtitle");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Genre1).HasColumnName("genre");

                entity.HasMany(d => d.Books)
                    .WithMany(p => p.Genres)
                    .UsingEntity<Dictionary<string, object>>(
                        "BookGenre",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("BookId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<Genre>().WithMany().HasForeignKey("GenreId").OnDelete(DeleteBehavior.ClientSetNull),
                        j =>
                        {
                            j.HasKey("GenreId", "BookId");

                            j.ToTable("book_genres");

                            j.IndexerProperty<long>("GenreId").HasColumnType("INT").HasColumnName("genre_id");

                            j.IndexerProperty<long>("BookId").HasColumnType("INT").HasColumnName("book_id");
                        });
            });

            modelBuilder.Entity<Librarian>(entity =>
            {
                entity.ToTable("librarian");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.ToTable("orders");

                entity.Property(e => e.OrderNumber)
                    .HasColumnName("order_number")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BookId)
                    .HasColumnType("INT")
                    .HasColumnName("book_id");

                entity.Property(e => e.CheckoutDate).HasColumnName("checkout_date");

                entity.Property(e => e.LibrarianId)
                    .HasColumnType("INT")
                    .HasColumnName("librarian_id");

                entity.Property(e => e.ReturnDate).HasColumnName("return_date");

                entity.Property(e => e.UserId)
                    .HasColumnType("INT")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BookId);

                entity.HasOne(d => d.Librarian)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.LibrarianId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("series");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Name).HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
